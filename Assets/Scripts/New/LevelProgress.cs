using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using OverForged;
using static ItemTypes;

public class LevelProgress : MonoBehaviour
{
    public Dictionary<ItemType, int> inventoryDict = new();
    public int levelScore;

    private void OnEnable()
    {
        GameProgress.ProgressEvent += UpdateProgress;
    }

    private void OnDisable()
    {
        GameProgress.ProgressEvent -= UpdateProgress;
    }

    private void UpdateProgress(ItemInteract item)
    {
        if (!inventoryDict.ContainsKey(item.info.itemType))
        {
            inventoryDict.Add(item.info.itemType, 0);
        }
        inventoryDict[item.info.itemType]++;
        levelScore += item.info.itemValue;
    }
}
