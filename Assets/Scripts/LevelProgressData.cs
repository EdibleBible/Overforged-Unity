using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LevelProgressData", menuName = "ScriptableObjects/LevelProgressData")]

public class LevelProgressData : ScriptableObject
{
    public Scene levelScene;
    public List<ItemTypes.ItemType> requiredItems = new List<ItemTypes.ItemType>();
    public List<int> requiredItemAmounts = new List<int>();
    public int requiredScore;
    public float levelTime;
    public bool isLevelUnlocked;
    public int highScore;
}
