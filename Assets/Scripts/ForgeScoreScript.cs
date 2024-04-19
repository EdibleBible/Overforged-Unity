using UnityEngine;
using TMPro;

public class ForgeScoreScript : MonoBehaviour //Handles the display of the current score on the UI display
{
    public int levelScore;
    public TextMeshProUGUI text;
    [SerializeField] private CurrentLevelInfo currentLevelInfo; //SO containing the information about the current level session

    private void OnEnable() //When this event is called this function will run to increase the score on the display
    {
        ObjectShippingBoxUse.LevelScoreIncreaseEvent += IncreaseScore;
    }

    private void OnDisable() //Lmao idk
    {
        ObjectShippingBoxUse.LevelScoreIncreaseEvent -= IncreaseScore;
    }

    private void IncreaseScore(int levelScore, bool ribbon) //Runs the function with the current score the display and another discarded variable
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = levelScore.ToString(); //TMP text component is updated with the new level score
        currentLevelInfo.currentLevelScore += levelScore; //SO with the information about the current level session is updated with the new level score
    }
}
