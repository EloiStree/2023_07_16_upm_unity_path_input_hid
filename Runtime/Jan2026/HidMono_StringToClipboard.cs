using UnityEngine;
using UnityEngine.Events;

public class HidMono_StringToClipboard : MonoBehaviour
{

    public UnityEvent<string> m_pushedText;

    public void PushIn(string text)
    {
        GUIUtility.systemCopyBuffer = text;
    }
}
