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
        SceneManager.LoadScene(0);
    }

    public static void NextLevel()
    {
        SceneManager.LoadScene((int)SOGameProgress.latestLevel);
    }

    public static void Retry()
    {
        SceneManager.LoadScene((int)SOGameProgress.currentLevel);
    }

    public static void ResumeLevel()
    {
        Debug.Log(SOGameProgress.latestLevel);
        SceneManager.LoadScene((int)SOGameProgress.latestLevel);
    }

    public static void SelectLevel()
    {
        SceneManager.LoadScene(2);
    }
}
