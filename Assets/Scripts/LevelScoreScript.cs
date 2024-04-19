using UnityEngine;
using TMPro;

public class LevelScoreScript : MonoBehaviour //Handles the display of the current score on the UI display
{
    [SerializeField] private CurrentLevelInfo currentLevelInfo; //SO containing the information about the current level session

    private void OnEnable() //When this event is called this function will run to increase the score on the display
    {
        ShippingBoxNew.LevelScoreIncreaseEventNew += IncreaseScore;
    }

    private void OnDisable() //Lmao idk
    {
        ShippingBoxNew.LevelScoreIncreaseEventNew -= IncreaseScore;
    }

    private void IncreaseScore() //Runs the function with the current score the display and another discarded variable
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = currentLevelInfo.currentLevelScore.ToString(); //TMP text component is updated with the new level score
    }
}
