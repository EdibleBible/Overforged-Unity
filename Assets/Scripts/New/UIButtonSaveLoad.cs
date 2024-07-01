using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonSaveLoad : MonoBehaviour
{
    public SOGameProgress gameData;
    public SOSettings settings;
    public int saveFileIndex;
    public Button loadButton;
    public GameObject selected;
    public Button otherButton1;
    public GameObject otherSelected1;
    public Button otherButton2;
    public GameObject otherSelected2;
    private string saveFilePath;
    public enum SaveLoad {None, Save, Load };
    public SaveLoad buttonType;

    private void Awake()
    {
        saveFilePath = GetPath(saveFileIndex);
    }

    private void OnEnable()
    {
        if (buttonType == SaveLoad.Load && (!File.Exists(saveFilePath) /*|| settings.latestSaveFile == saveFileIndex */))
        {
            loadButton.interactable = false;
        }
        if (buttonType == SaveLoad.Save && settings.latestSaveFile == saveFileIndex)
        {
            otherSelected1.SetActive(false);
            otherSelected2.SetActive(false);
        }
    }

    public void SaveGame()
    {
        loadButton.interactable = false;
        selected.SetActive(true);
        if (File.Exists(GetPath(otherButton1.gameObject.GetComponent<UIButtonSaveLoad>().saveFileIndex)))
        {
            otherButton1.interactable = true;
        }
        if (File.Exists(GetPath(otherButton2.gameObject.GetComponent<UIButtonSaveLoad>().saveFileIndex)))
        {
            otherButton2.interactable = true;
        }
        otherSelected1.SetActive(false);
        otherSelected2.SetActive(false);
        settings.latestSaveFile = saveFileIndex;
        SaveSystem.SaveGameData(gameData, saveFilePath);
        Debug.Log("Game Saved");
    }

    public void LoadGame()
    {
        settings.latestSaveFile = saveFileIndex;
        SaveSystem.LoadGameData(gameData, saveFilePath);
        Debug.Log("Game Loaded");
    }

    private void OnDisable()
    {
        loadButton.interactable = true;
    }

    public string GetPath(int index)
    {
        return Path.Combine(Application.persistentDataPath, "savefile" + index + ".json");
    }
}
