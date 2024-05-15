using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "PlaySessionData", menuName = "ScriptableObjects/PlaySessionData")]

public class PlaySessionData : ScriptableObject
{
    public int recentLevelScore;
    public bool enoughProductsShipped;
    public Scene recentLevelScene;
    public LevelProgressData recentLevelProgressData;
    [NonSerialized] public bool recentLevelPassed;
    [NonSerialized] public bool isGamePaused;
    public List<LevelProgressData> listOfLevels = new List<LevelProgressData>();
    public Dictionary<ItemTypes.ItemType, int> productsShippedDict = new Dictionary<ItemTypes.ItemType, int>();

    public void IncreaseShippedProductCount(ItemTypes.ItemType itemType)
    {
        Debug.Log(productsShippedDict);
        if (!productsShippedDict.ContainsKey(itemType))
        {
            productsShippedDict.Add(itemType, 0);
        }
        productsShippedDict[itemType]++;
    }

    public void UnlockNextLevel()
    {
        listOfLevels[listOfLevels.IndexOf(recentLevelProgressData) +1].isLevelUnlocked = true;
    }

    public Scene ReturnNextLevelSceneAsset()
    {
        if (listOfLevels.Count == listOfLevels.IndexOf(recentLevelProgressData))
        {
            return recentLevelScene;
        } else
        {
            return listOfLevels[listOfLevels.IndexOf(recentLevelProgressData) + 1].levelScene;
        }
    }
}
