using UnityEngine;
using TMPro;

public class LevelScoreScript : MonoBehaviour //Handles the display of the current score on the UI display
{
    private void OnEnable() //When this event is called this function will run to increase the score on the display
    {
        LevelProgressionController.LevelScoreIncreaseEventNew += IncreaseScore;
    }

    private void OnDisable() //Lmao idk
    {
        LevelProgressionController.LevelScoreIncreaseEventNew -= IncreaseScore;
    }

    private void IncreaseScore(string currentLevelScore) //Runs the function with the current score the display and another discarded variable
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = currentLevelScore;
    }
}
