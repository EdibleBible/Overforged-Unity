using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelFinished : MonoBehaviour
{
    [SerializeField] private CurrentLevelInfo currentLevelInfo;
    [SerializeField] private GameObject buttonNextLevel;
    [SerializeField] private TextMeshProUGUI textLevelComplete;
    void Awake()
    {
        if (currentLevelInfo.currentLevel == 1 && currentLevelInfo.currentLevelScore >= 400 && currentLevelInfo.bouquetsShipped > 7) 
        {
            buttonNextLevel.SetActive(true);
            textLevelComplete.text = "Level Complete";
        }
        else if (currentLevelInfo.currentLevel == 2 && currentLevelInfo.currentLevelScore >= 750 && currentLevelInfo.bouquetsShipped > 4 && currentLevelInfo.bouquetsShippedRibbon > 4)
        {
            textLevelComplete.text = "Level Complete";
        }
    }
}
