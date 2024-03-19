using UnityEngine;

public class CheckIfLevel2Unlocked : MonoBehaviour //Runs when the Main Menu scene awakes to check if Level 2 button should be hidden
{
    [SerializeField] private CurrentLevelInfo currentLevelInfo; //SO containing the information about whether level 2 was unlocked
    [SerializeField] private GameObject buttonToHide; //Level 2 button
    [SerializeField] private GameObject completionStar; //I think broken but was supposed to show a star in the menu is level 2 was completed
    void Awake()
    {
        if (currentLevelInfo.levelTwoFinished == true)
        {
            completionStar.SetActive(true);
        }
        if (currentLevelInfo.levelTwoUnlocked == true)
        {
            buttonToHide.SetActive(false);
        }
    }
}
