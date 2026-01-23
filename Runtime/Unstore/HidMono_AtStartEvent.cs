using UnityEngine;
using UnityEngine.Events;

public class HidMono_AtStartEvent : MonoBehaviour
{
    public UnityEvent m_onStart;
    void Start()
    {
        m_onStart.Invoke();
    }
}
