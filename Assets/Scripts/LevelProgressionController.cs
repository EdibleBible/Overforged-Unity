using System;
using System.Collections;
using UnityEngine;

public class LevelProgressionController : MonoBehaviour
{
    [SerializeField] private CurrentLevelInfo currentLevelInfo;
    [SerializeField] private PlaySessionData playSessionData;
    [SerializeField] private LevelProgressData levelProgressData;
<<<<<<< HEAD
    public float levelTime;
=======
    [NonSerialized] public float levelTime;
>>>>>>> 6be2f7d (Absolutely chaotic pause menu management)
    public delegate void LevelScoreIncreaseHandlerNew(string currentLevelScore);
    public static event LevelScoreIncreaseHandlerNew LevelScoreIncreaseEventNew;
    public delegate void LevelProgressionIncreaseHandler(PlaySessionData playSessionData);
    public static event LevelProgressionIncreaseHandler LevelProgressionIncreaseEvent;
    public delegate void TimerHandler(float timeLeft);
    public static event TimerHandler TimerUpdateEvent;

    private void Start()
    {
<<<<<<< HEAD
        levelTime = levelProgressData.levelTime;
        playSessionData.recentLevelScore = 0;
        playSessionData.productsShippedDict.Clear();
        playSessionData.enoughProductsShipped = false;
        playSessionData.recentLevelProgressData = levelProgressData;
        TimerUpdateEvent.Invoke(levelTime);
        StartCoroutine(StartTimer());
=======
        playSessionData.recentLevelScore = 0;
        playSessionData.productsShippedDict.Clear();
        playSessionData.enoughProductsShipped = false;
        TimerUpdateEvent.Invoke(levelTime);
        StartCoroutine(StartTimer());
        levelTime = levelProgressData.levelTime;
>>>>>>> 6be2f7d (Absolutely chaotic pause menu management)
}
    private IEnumerator StartTimer()
    {
        while (levelTime > 0f)
        {
            // Decrease the duration by deltaTime each frame
            levelTime -= Time.deltaTime;

            // Update the timer text
            TimerUpdateEvent.Invoke(levelTime + 1);

            yield return null;
        }

        // Ensure the timer ends at 0 and update the text one last time
        levelTime = 0f;
        TimerUpdateEvent.Invoke(levelTime);
        FinishLevel();
    }

    private void FinishLevel()
    {
        if (CheckShippedProductsToPass() && playSessionData.recentLevelScore >= levelProgressData.requiredScore)
        {
            playSessionData.recentLevelPassed = true;
<<<<<<< HEAD
            playSessionData.UnlockNextLevel();
=======
            playSessionData.UnlockNextLevel(levelProgressData);
>>>>>>> 6be2f7d (Absolutely chaotic pause menu management)
        } else
        {
            playSessionData.recentLevelPassed = false;
        }

<<<<<<< HEAD
        GamePause.SwitchPause(playSessionData.isGamePaused, "Scenes/UIFinishLevel", UnityEngine.SceneManagement.LoadSceneMode.Additive);
=======
        GamePause.SwitchPause(playSessionData.isGamePaused, "Scenes/UIFinishLevel");
>>>>>>> 6be2f7d (Absolutely chaotic pause menu management)
    }

    private bool CheckShippedProductsToPass()
    {
        foreach (var itemType in playSessionData.productsShippedDict.Keys)
        {
            if (playSessionData.productsShippedDict[itemType] < levelProgressData.requiredItemAmounts[levelProgressData.requiredItems.IndexOf(itemType)])
            {
                return false;
            }
        }
        return true;
    }

    public void AddScoreAndMarkOrder(ItemTypes.ItemType itemType, int itemValue)
    {
        playSessionData.IncreaseShippedProductCount(itemType);
        playSessionData.recentLevelScore += itemValue;
        LevelScoreIncreaseEventNew?.Invoke(playSessionData.recentLevelScore.ToString());
        LevelProgressionIncreaseEvent?.Invoke(playSessionData);
    }
}
