using System.IO;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public static class SaveSystem
{
    public static void SaveGameData(SOGameProgress data, string filePath)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);
    }

    public static void LoadGameData(SOGameProgress data, string filePath)
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            JsonUtility.FromJsonOverwrite(json, data);
            SceneManager.LoadScene(0);
        }
        else
        {
            Debug.LogWarning("Save file not found");
        }
    }
}
