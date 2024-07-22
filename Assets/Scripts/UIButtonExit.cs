using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UIButtonExit : MonoBehaviour
{
    public SOSettings settings;
    private string settingsPath;

    public void ExitGame()
    {
        settingsPath = Path.Combine(Application.persistentDataPath, "settings.json");
        string json = JsonUtility.ToJson(settings);
        File.WriteAllText(settingsPath, json);
        Debug.Log("Quit");
        Application.Quit();
    }
}
