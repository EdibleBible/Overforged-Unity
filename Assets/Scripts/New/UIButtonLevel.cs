using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using static OverForged.GameProgress;

public class UIButtonLevel : MonoBehaviour
{
    public static void LoadLevel(Level level)
    {
        SceneManager.LoadScene((int)level);
    }

    public static void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public static void NextLevel()
    {
        SceneManager.LoadScene((int)GetLevel()+1);
    }

    public static void Retry()
    {
        SceneManager.LoadScene((int)GetLevel());
    }
}
