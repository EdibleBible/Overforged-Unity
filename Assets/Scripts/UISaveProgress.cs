using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;

public class UISaveProgress : MonoBehaviour
{
    public int saveFileIndex;
    public GameObject textNoFile;
    public GameObject testHasFile;
    public TMP_Text textLatestLevel;
    public TMP_Text textUnlockedSkins;
    public TMP_Text textGamemode;
    private SOGameProgress progressFile;

    private void OnEnable()
    {
        progressFile = ScriptableObject.CreateInstance<SOGameProgress>();
        if (!File.Exists(GetPath(saveFileIndex)))
        {
            textNoFile.SetActive(true);
        } else
        {
            JsonUtility.FromJsonOverwrite(File.ReadAllText(GetPath(saveFileIndex)), progressFile);
            testHasFile.SetActive(true);
            textLatestLevel.text = "Latest Level: " + ((int)progressFile.latestLevel - 5).ToString() + "/6";
            int indexer = 0;
            for (int i = 0; i < 8; i++)
            {
                if (progressFile.skinUnlocked[i]) { indexer++; }
            }
            textUnlockedSkins.text = "Unlocked Skins: " + indexer.ToString() + "/8";
            if (progressFile.toggleMultiplayer)
            {
                textGamemode.text = "Gamemode: Singleplayer";
            } else
            {
                textGamemode.text = "Gamemode: Multiplayer";
            }
        }
    }

    public string GetPath(int index)
    {
        return Path.Combine(Application.persistentDataPath, "savefile" + index + ".json");
    }
}
