using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
<<<<<<< HEAD
<<<<<<< HEAD
    public static void SwitchPause(bool isGamePaused, Scene pauseMenu)
=======
    public static void SwitchPause(bool isGamePaused, Scene pauseMenu, LoadSceneMode loadSceneMode)
>>>>>>> 6be2f7d (Absolutely chaotic pause menu management)
=======
    public static void SwitchPause(bool isGamePaused, Scene pauseMenu)
>>>>>>> feabb03 (Flower crafting done)
    {
        switch (isGamePaused)
        {
            case false:
                Time.timeScale = 0;
<<<<<<< HEAD
<<<<<<< HEAD
                SceneManager.LoadScene(pauseMenu.name);
=======
                SceneManager.LoadScene(pauseMenu.name, loadSceneMode);
                break;
            case true:
                Time.timeScale = 1;
                SceneManager.UnloadSceneAsync(pauseMenu.name);
                break;
        }
    }

    public static void SwitchPause(bool isGamePaused, SceneAsset pauseMenu)
    {
        switch (isGamePaused)
        {
            case false:
                Time.timeScale = 0;
                SceneManager.LoadScene(pauseMenu.name, LoadSceneMode.Additive);
>>>>>>> 6be2f7d (Absolutely chaotic pause menu management)
=======
                SceneManager.LoadScene(pauseMenu.name);
>>>>>>> feabb03 (Flower crafting done)
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
<<<<<<< HEAD
<<<<<<< HEAD
                SceneManager.LoadScene(pauseMenu);
=======
                SceneManager.LoadScene(pauseMenu, LoadSceneMode.Additive);
>>>>>>> 6be2f7d (Absolutely chaotic pause menu management)
=======
                SceneManager.LoadScene(pauseMenu);
>>>>>>> feabb03 (Flower crafting done)
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
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> feabb03 (Flower crafting done)
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
<<<<<<< HEAD
=======
>>>>>>> 6be2f7d (Absolutely chaotic pause menu management)
=======
>>>>>>> feabb03 (Flower crafting done)
}
