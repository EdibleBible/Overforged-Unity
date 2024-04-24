using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.SceneManagement;
=======
>>>>>>> 6be2f7d (Absolutely chaotic pause menu management)

[CreateAssetMenu(fileName = "LevelProgressData", menuName = "ScriptableObjects/LevelProgressData")]

public class LevelProgressData : ScriptableObject
{
<<<<<<< HEAD
    public Scene levelScene;
=======
    public SceneAsset levelScene;
>>>>>>> 6be2f7d (Absolutely chaotic pause menu management)
    public List<ItemTypes.ItemType> requiredItems = new List<ItemTypes.ItemType>();
    public List<int> requiredItemAmounts = new List<int>();
    public int requiredScore;
    public float levelTime;
    public bool isLevelUnlocked;
    public int highScore;
}
