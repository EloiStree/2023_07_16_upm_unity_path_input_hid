using UnityEngine;
using UnityEngine.Events;

public class HidMono_StringToPersistanceDataFile : MonoBehaviour
{
    public string m_fileNameWithExtension="FileName.txt";
    [Header("Debug")]

    public UnityEvent<string> m_pushedText;

    public UnityEvent<string> m_currentPersistanceFolderText;
    public string m_currentFolderPath;
    public UnityEvent<string> m_currentPersistanceFileText;
    public string m_currentFilePath;

    public string GetFolderPath()
    {
        return Application.persistentDataPath;
    }

    public string GetFilePath(string fileName)
    {
        return System.IO.Path.Combine(GetFolderPath(), fileName);
    }

    public void Awake()
    {
        m_currentFolderPath = GetFolderPath();
        m_currentFilePath = GetFilePath(m_fileNameWithExtension);
        m_currentPersistanceFolderText?.Invoke(m_currentFolderPath);
        m_currentPersistanceFileText?.Invoke(m_currentFilePath);
    }

    [ContextMenu("Open Folder In Window")]
    public void OpenFolderInWindow()
    {
        Application.OpenURL(GetFolderPath());
    }

    [ContextMenu("Open File In Window")]
    public void OpenFileInWindow()
    {
        Application.OpenURL(GetFilePath(m_fileNameWithExtension));
    }

    public void PushIn(string text)
    {
        string fullPath = GetFilePath(m_fileNameWithExtension);
        System.IO.File.WriteAllText(fullPath, text);
        m_pushedText.Invoke(text);
    }
}
