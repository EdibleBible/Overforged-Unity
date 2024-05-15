using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonRetryLevel : MonoBehaviour //Attached to the buttons on the Level Finish scene
{
    [SerializeField] private CurrentLevelInfo currentLevelInfo; //SO containing the info about the current level progress
    [SerializeField] private PlaySessionData playSessionData;
    public void Retry() //When retry button is pressed
    {
        GamePause.SwitchPause(playSessionData.isGamePaused, playSessionData.recentLevelScene);
    }
    public void Menu() //When menu button is pressed
    {
        GamePause.SwitchPause(playSessionData.isGamePaused, 0);
    }

    public void NextLevel() //When next level button is pressed
    {
        GamePause.SwitchPause(playSessionData.isGamePaused, playSessionData.ReturnNextLevelSceneAsset());
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
