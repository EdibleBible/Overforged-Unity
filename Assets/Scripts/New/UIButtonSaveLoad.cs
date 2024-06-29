using System.IO;
using UnityEngine;

public class UIButtonSaveLoad : MonoBehaviour
{
    public SOGameProgress gameData;
    private string saveFilePath;

    private void Awake()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "savefile.json");
    }

    public void SaveGame()
    {
        SaveSystem.SaveGameData(gameData, saveFilePath);
        Debug.Log("Game Saved");
    }

    public void LoadGame()
    {
        SaveSystem.LoadGameData(gameData, saveFilePath);
        Debug.Log("Game Loaded");
    }
}
