using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private int sceneNumber;
    [SerializeField] private CurrentLevelInfo currentLevelInfo;
    public static void ExitGame()
    {
        Application.Quit();
    }

    public void GoToStage()
    {
        currentLevelInfo.currentLevel = sceneNumber;
        currentLevelInfo.currentLevelScore = 0;
        currentLevelInfo.bouquetsShipped = 0;
        currentLevelInfo.bouquetsShippedRibbon = 0;
        SceneManager.LoadScene(sceneNumber);
    }
}
