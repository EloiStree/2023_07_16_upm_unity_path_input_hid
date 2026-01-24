using UnityEngine;
using UnityEngine.Events;

public class HidMono_RelayButtonAsKeyValueEvent : MonoBehaviour
{

    public UnityEvent<string, bool> m_onButtonPathChanged;

    public string m_lastButtonPath;
    public bool m_lastValue;
    public void PushIn(HIDButtonChangedReference button)
    {

        bool value = button.m_booleanThatChanged.m_value;
        string path = button.GetPathID();
        m_lastButtonPath = path;
        m_lastValue = value;
        m_onButtonPathChanged?.Invoke(path, value);
    }
}

