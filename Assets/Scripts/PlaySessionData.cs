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
<<<<<<< HEAD
    public Scene recentLevelScene;
    public LevelProgressData recentLevelProgressData;
=======
    public SceneAsset recentLevelScene;
>>>>>>> 6be2f7d (Absolutely chaotic pause menu management)
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

<<<<<<< HEAD
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
=======
    public void UnlockNextLevel(LevelProgressData levelProgressData)
    {
        listOfLevels[listOfLevels.IndexOf(levelProgressData)+1].isLevelUnlocked = true;
>>>>>>> 6be2f7d (Absolutely chaotic pause menu management)
    }
}
