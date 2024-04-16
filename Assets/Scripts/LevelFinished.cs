using UnityEngine;
using TMPro;

public class LevelFinished : MonoBehaviour //Sets up the Level Finish scene when it awakes
{
    [SerializeField] private CurrentLevelInfo currentLevelInfo; //SO containing the info about the current level session
    [SerializeField] private GameObject buttonNextLevel; //Button that can show up on the Level Finish scene
    [SerializeField] private TextMeshProUGUI textLevelComplete; //Text that tells the player whether they completed the level
    void Awake()
    {
        //Hardcoded level 1 passing criteria
        if (currentLevelInfo.currentLevel == 1 && currentLevelInfo.currentLevelScore >= 400 && currentLevelInfo.bouquetsShipped > 7) 
        {
            buttonNextLevel.SetActive(true); //Next level button only appears if the current level is 1
            textLevelComplete.text = "Level Complete";
        }
        //Hardcoded level 2 passing criteria
        else if (currentLevelInfo.currentLevel == 2 && currentLevelInfo.currentLevelScore >= 750 && currentLevelInfo.bouquetsShipped > 4 && currentLevelInfo.bouquetsShippedRibbon > 4)
        {
            textLevelComplete.text = "Level Complete";
        }
    }
}
