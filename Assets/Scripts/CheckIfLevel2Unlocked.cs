using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfLevel2Unlocked : MonoBehaviour
{
    [SerializeField] private CurrentLevelInfo currentLevelInfo;
    [SerializeField] private GameObject buttonToHide;
    [SerializeField] private GameObject completionStar;
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
} // do wyebania
