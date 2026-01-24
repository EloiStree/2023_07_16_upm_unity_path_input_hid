using Eloi.HID;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HidMono_ListenToDevicesAxis : MonoBehaviour
{
    public HidMono_ListenToAllDevicesInUnity m_sourceObservered;
    public Dictionary<string, HIDAxisChangedReference> m_register = new Dictionary<string, HIDAxisChangedReference>();

    public HIDAxisChangedReferenceEvent m_onAxisChanged;

    public ulong m_received;
   // public LastReceivedFloatChange m_lastReceived;

    public List<string> m_axisUniqueId = new List<string>();

    public History m_history = new History();

    [System.Serializable]
    public class History : GenericClampHistory<LastReceivedFloatChange> { }

    private void Awake()
    {
        m_sourceObservered.m_onAxisChanged += DebugAxisChanged;
    }

    private void OnDestroy()
    {

        m_sourceObservered.m_onAxisChanged -= DebugAxisChanged;
    }

    public void RefreshListOfAxis()
    {

        m_axisUniqueId = m_register.Keys.ToList();
    }

    public LastReceivedFloatChange m_lastReceived;
    [System.Serializable]
    public struct LastReceivedFloatChange
    {
        public DeviceSourceToRawValue m_deviceInfo;
        public DeviceSourceToRawValue.NamedFloatValue m_floatThatChanged;
        public float m_newValue;
        public LastReceivedFloatChange(DeviceSourceToRawValue deviceInfo, DeviceSourceToRawValue.NamedFloatValue booleanThatChanged, float newValue)
        {
            m_deviceInfo = deviceInfo;
            m_floatThatChanged = booleanThatChanged;
            m_newValue = newValue;
        }
    }
    public int m_maxToken = 100;
    public bool m_ignoreMouse =true;
    private void DebugAxisChanged(DeviceSourceToRawValue deviceInfo, DeviceSourceToRawValue.NamedFloatValue floatThatChanged, float newValue)
    {
        if (deviceInfo == null || floatThatChanged == null)
            return;
        if (m_ignoreMouse && deviceInfo.m_devicePath == "/Mouse")
            return;
        string uniqueId = HIDButtonStatic.GetID(deviceInfo, floatThatChanged);
        m_received++;
        if (!m_register.ContainsKey(uniqueId))
            m_register.Add(uniqueId, new HIDAxisChangedReference(in deviceInfo, in floatThatChanged));

        m_lastReceived.m_deviceInfo = deviceInfo;
        m_lastReceived.m_floatThatChanged = floatThatChanged;
        m_lastReceived.m_newValue = newValue;
        m_onAxisChanged.Invoke(m_register[uniqueId]);
    }
  
}
