using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonRetryLevel : MonoBehaviour
{
    [SerializeField] private CurrentLevelInfo currentLevelInfo;
    public void Retry()
    {
        Time.timeScale = 1f;
        currentLevelInfo.currentLevelScore = 0;
        currentLevelInfo.bouquetsShipped = 0;
        currentLevelInfo.bouquetsShippedRibbon = 0;
        SceneManager.LoadScene(currentLevelInfo.currentLevel);
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        currentLevelInfo.currentLevel = 2;
        currentLevelInfo.currentLevelScore = 0;
        currentLevelInfo.bouquetsShipped = 0;
        currentLevelInfo.bouquetsShippedRibbon = 0;
        SceneManager.LoadScene(currentLevelInfo.currentLevel);
    }
}
