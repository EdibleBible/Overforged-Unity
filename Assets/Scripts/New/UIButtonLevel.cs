using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class UIButtonLevel : MonoBehaviour
{
    public static void NextLevel(int levelInt)
    {
        SceneManager.LoadScene(levelInt);
    }

    public static void Level1()
    {
        SceneManager.LoadScene(1); 
    }
}
