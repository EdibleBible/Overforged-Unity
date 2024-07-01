using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Playables;

public class UISaveInitializer : MonoBehaviour
{
    public SOSettings settings;
    public SOGameProgress progress;
    private string settingsPath;
    private string savePath;
    private void Awake()
    {
        settingsPath = Path.Combine(Application.persistentDataPath, "settings.json");
        if (File.Exists(settingsPath))
        {
            string json = File.ReadAllText(settingsPath);
            JsonUtility.FromJsonOverwrite(json, settings);
            savePath = Path.Combine(Application.persistentDataPath, "savefile" + settings.latestSaveFile + ".json");
            if (File.Exists(savePath))
            {
                string json2 = File.ReadAllText(savePath);
                JsonUtility.FromJsonOverwrite(json2, progress);
            }
        }
    }
}
