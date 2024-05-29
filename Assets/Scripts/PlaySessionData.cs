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
    public SceneAsset recentLevelScene;
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

    public void UnlockNextLevel(LevelProgressData levelProgressData)
    {
        listOfLevels[listOfLevels.IndexOf(levelProgressData)+1].isLevelUnlocked = true;
    }
}
