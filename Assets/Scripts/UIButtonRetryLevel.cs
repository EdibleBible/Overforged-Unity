using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonRetryLevel : MonoBehaviour //Attached to the buttons on the Level Finish scene
{
    [SerializeField] private CurrentLevelInfo currentLevelInfo; //SO containing the info about the current level progress
    [SerializeField] private PlaySessionData playSessionData;
    public void Retry() //When retry button is pressed
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(playSessionData.recentLevelInt);
    }
    public void Menu() //When menu button is pressed
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void NextLevel() //When next level button is pressed
    {
        Time.timeScale = 1;
        if (playSessionData.recentLevelInt > 5)
        {
            SceneManager.LoadScene(0);
        } else
        {
            SceneManager.LoadScene(playSessionData.recentLevelInt + 1);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
