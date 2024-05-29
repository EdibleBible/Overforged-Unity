using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
    public static void SwitchPause(bool isGamePaused, Scene pauseMenu)
    {
        switch (isGamePaused)
        {
            case false:
                Time.timeScale = 0;
                SceneManager.LoadScene(pauseMenu.name);
                break;
            case true:
                Time.timeScale = 1;
                SceneManager.UnloadSceneAsync(pauseMenu.name);
                break;
        }
    }

    public static void SwitchPause(bool isGamePaused, string pauseMenu)
    {
        switch (isGamePaused)
        {
            case false:
                Time.timeScale = 0;
                SceneManager.LoadScene(pauseMenu);
                break;
            case true:
                Time.timeScale = 1;
                SceneManager.UnloadSceneAsync(pauseMenu);
                break;
        }
    }

    public static void SwitchPause(bool isGamePaused, GameObject pauseMenu)
    {
        switch (isGamePaused)
        {
            case false:
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                break;
            case true:
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                break;
        }
    }
    public static void SwitchPause(bool isGamePaused, Scene pauseMenu, LoadSceneMode loadSceneMode)
    {
        switch (isGamePaused)
        {
            case false:
                Time.timeScale = 0;
                SceneManager.LoadScene(pauseMenu.name, loadSceneMode);
                break;
            case true:
                Time.timeScale = 1;
                SceneManager.UnloadSceneAsync(pauseMenu.name);
                break;
        }
    }

    public static void SwitchPause(bool isGamePaused, string pauseMenu, LoadSceneMode loadSceneMode)
    {
        switch (isGamePaused)
        {
            case false:
                Time.timeScale = 0;
                SceneManager.LoadScene(pauseMenu, loadSceneMode);
                break;
            case true:
                Time.timeScale = 1;
                SceneManager.UnloadSceneAsync(pauseMenu);
                break;
        }
    }

    public static void SwitchPause(bool isGamePaused, int pauseMenu)
    {
        switch (isGamePaused)
        {
            case false:
                Time.timeScale = 0;
                SceneManager.LoadScene(pauseMenu);
                break;
            case true:
                Time.timeScale = 1;
                SceneManager.UnloadSceneAsync(pauseMenu);
                break;
        }
    }

    public static void SwitchPause(bool isGamePaused, int pauseMenu, LoadSceneMode loadSceneMode)
    {
        switch (isGamePaused)
        {
            case false:
                Time.timeScale = 0;
                SceneManager.LoadScene(pauseMenu, loadSceneMode);
                break;
            case true:
                Time.timeScale = 1;
                SceneManager.UnloadSceneAsync(pauseMenu);
                break;
        }
    }
}
