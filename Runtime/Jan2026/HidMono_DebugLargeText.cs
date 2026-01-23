using UnityEngine;

public class HidMono_DebugLargeText : MonoBehaviour
{

    [TextArea(5, 20)]
    public string m_text = "";
    public int m_maxLength = 1800;

    public void SetText(string text)
    {
        if (text.Length > m_maxLength)
        {
            m_text = text.Substring(text.Length - m_maxLength, m_maxLength);
        }
        else
        {
            m_text = text;
        }
    }
}
