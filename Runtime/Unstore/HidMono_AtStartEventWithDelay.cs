using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class HidMono_AtStartEventWithDelay : MonoBehaviour
{
    public UnityEvent m_onStart;
    public float m_delayInSeconds=1;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(m_delayInSeconds);
        m_onStart.Invoke();
    }
}