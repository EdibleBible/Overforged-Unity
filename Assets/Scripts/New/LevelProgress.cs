using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using OverForged;
using static ItemTypes;
using UnityEngine.SceneManagement;
using static OverForged.GameProgress;

public class LevelProgress : MonoBehaviour
{
    public bool forcePass;
    public List<ItemType> requiredItems = new();
    public List<int> requiredItemCounts = new();
    public int requiredScore;
    public float levelTime = 180f;
    public Dictionary<ItemType, int> inventoryDict = new();
    private Dictionary<ItemType, int> requiredDict = new();
    public Level level;
    public SOGameProgress progressData;
    public int levelScore;
    

    private void OnEnable()
    {
        ProgressEvent += UpdateProgress;
        GetLevelEvent += GetLevel;
        GetScoreEvent += GetScore;
        SOGameProgress.currentLevel = level;
        SceneManager.LoadScene((int)Level.LevelUI, LoadSceneMode.Additive);
        StartCoroutine(StartTimer());
    }

    private void OnDisable()
    {
        ProgressEvent -= UpdateProgress;
        GetLevelEvent -= GetLevel;
        GetScoreEvent -= GetScore;
    }

    private void Start()
    {
        for (int i = 0; i < requiredItems.Count; i++)
        {
            requiredDict.Add(requiredItems[i], requiredItemCounts[i]);
        }
    }

    private void UpdateProgress(ItemInteract item)
    {
        if (!inventoryDict.ContainsKey(item.Type()))
        {
            inventoryDict.Add(item.Type(), 0);
        }
        inventoryDict[item.Type()]++;
        levelScore += item.GetValue();
    }

    private IEnumerator StartTimer()
    {
        while (levelTime > 0f)
        {
            // Decrease the duration by deltaTime each frame
            levelTime -= Time.deltaTime;

            // Update the timer text
            GameProgress.UpdateTime(levelTime + 1);
            yield return null;
        }

        // Ensure the timer ends at 0 and update the text one last time
        levelTime = 0f;
        UpdateTime(0);
        FinishLevel();
    }

    private void FinishLevel()
    {
        SOGameProgress.currentScore = levelScore;
        if (forcePass || LevelPassed())
        {
            SOGameProgress.latestLevel = (level + 1);
            Debug.Log(SOGameProgress.latestLevel);
            SceneManager.LoadScene((int)Level.LevelFinishedUI, LoadSceneMode.Additive);
        } else
        {
            SceneManager.LoadScene((int)Level.LevelFailedUI, LoadSceneMode.Additive);
        }
    }

    public bool LevelPassed()
    {
        foreach (var item in requiredDict.Keys)
        {
            if (requiredDict[item] > inventoryDict[item])
            {
                return false;
            }
        }
        if (requiredScore > levelScore)
        {
            return false;
        }
        return true;
    }

    public Level GetLevel()
    {
        return level;
    }

    public int GetScore()
    {
        return levelScore;
    }
}
