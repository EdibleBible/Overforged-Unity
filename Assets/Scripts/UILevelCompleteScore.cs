using UnityEngine;
using TMPro;

public class UILevelCompleteScore : MonoBehaviour
{
    [SerializeField] private CurrentLevelInfo currentLevelInfo; //SO containing the information about the current level played
    private TextMeshProUGUI text; //Reference to self

    void Awake() //When the Level Finish scene loads the script adds the level score to the text object
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "Score: " + currentLevelInfo.currentLevelScore;
    }
}
