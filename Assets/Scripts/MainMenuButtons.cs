using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour //Used for the buttons in the Main Menu scene
{
    [SerializeField] private int sceneNumber; //Assigned in the Inspector for each button
    [SerializeField] private CurrentLevelInfo currentLevelInfo; //SO containing the information about the current level session
    public static void ExitGame()
    {
        Application.Quit();
    }

    public void GoToStage() //When the player presses a button to go to a level the values are reset and the scene number is set based on the button pressed
    {
        currentLevelInfo.currentLevel = sceneNumber;
        currentLevelInfo.currentLevelScore = 0;
        currentLevelInfo.bouquetsShipped = 0;
        currentLevelInfo.bouquetsShippedRibbon = 0;
        SceneManager.LoadScene(sceneNumber);
    }
}
