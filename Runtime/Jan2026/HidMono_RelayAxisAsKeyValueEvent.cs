using UnityEngine;
using UnityEngine.Events;

public class HidMono_RelayAxisAsKeyValueEvent : MonoBehaviour
{

    public UnityEvent<string, float> m_onAxisPathChanged;

    public string m_lastButtonPath;
    public float m_lastValue;
    public void PushIn(HIDAxisChangedReference button)
    {

        float value = button.m_axisThatChanged.m_value;
        string path = button.GetPathID();
        m_lastButtonPath = path;
        m_lastValue = value;
        m_onAxisPathChanged?.Invoke(path, value);
    }
}

