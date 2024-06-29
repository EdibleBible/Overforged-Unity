using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using static OverForged.GameProgress;

public class UIButtonLevel : MonoBehaviour
{
    public SOGameProgress SOGameProgress;
    public static void LoadLevel(Level level)
    {
        SceneManager.LoadScene((int)level);
    }

    public static void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public static void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene((int)SOGameProgress.latestLevel);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene((int)SOGameProgress.currentLevel);
    }

    public void ResumeLevel()
    {
        Time.timeScale = 1f;
        Debug.Log(SOGameProgress.latestLevel);
        SceneManager.LoadScene((int)SOGameProgress.latestLevel);
    }

    public static void SelectLevel()
    {
        SceneManager.LoadScene(2);
    }
}
