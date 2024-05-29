using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonRetryLevel : MonoBehaviour //Attached to the buttons on the Level Finish scene
{
    [SerializeField] private CurrentLevelInfo currentLevelInfo; //SO containing the info about the current level progress
    [SerializeField] private PlaySessionData playSessionData;
    public void Retry() //When retry button is pressed
    {
        GamePause.SwitchPause(playSessionData.isGamePaused, playSessionData.recentLevelInt);
    }
    public void Menu() //When menu button is pressed
    {
        GamePause.SwitchPause(playSessionData.isGamePaused, 0);
    }

    public void NextLevel() //When next level button is pressed
    {
        if (playSessionData.recentLevelInt > 5)
        {
            GamePause.SwitchPause(playSessionData.isGamePaused, 0);
        } else
        {
            GamePause.SwitchPause(playSessionData.isGamePaused, playSessionData.recentLevelInt + 1);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
