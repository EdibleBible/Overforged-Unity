using UnityEngine;
using TMPro;

public class ForgeScoreScript : MonoBehaviour //Handles the display of the current score on the UI display
{
    public TextMeshProUGUI text;

    private void OnEnable() //When this event is called this function will run to increase the score on the display
    {
        LevelProgressionController.LevelScoreIncreaseEvent += IncreaseScore;
    }

    private void OnDisable() //Lmao idk
    {
        LevelProgressionController.LevelScoreIncreaseEvent -= IncreaseScore;
    }

    private void IncreaseScore(string currentLevelScore) //Runs the function with the current score the display and another discarded variable
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = currentLevelScore; //TMP text component is updated with the new level score
    }
}
