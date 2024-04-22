using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgressionController : MonoBehaviour
{
    [SerializeField] private CurrentLevelInfo currentLevelInfo;
    public delegate void LevelScoreIncreaseHandlerNew(string currentLevelScore);
    public static event LevelScoreIncreaseHandlerNew LevelScoreIncreaseEventNew;
    public delegate void LevelProgressionIncreaseHandler(CurrentLevelInfo currentLevelInfo);
    public static event LevelProgressionIncreaseHandler LevelProgressionIncreaseEvent;

    private void Start()
    {
        currentLevelInfo.currentLevelScore = 0;
        currentLevelInfo.productsShippedDict.Clear();
    }

    public void AddScoreAndMarkOrder(ItemTypes.ItemType itemType, int itemValue)
    {
        currentLevelInfo.IncreaseShippedProductCount(itemType);
        currentLevelInfo.currentLevelScore += itemValue;
        LevelScoreIncreaseEventNew?.Invoke(currentLevelInfo.currentLevelScore.ToString());
        LevelProgressionIncreaseEvent?.Invoke(currentLevelInfo);
    }
}
