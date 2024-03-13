using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelScoreScript : MonoBehaviour
{
    public int levelScore;
    public TextMeshProUGUI text;
    [SerializeField] private CurrentLevelInfo currentLevelInfo;

    private void OnEnable()
    {
        ObjectShippingBoxUse.LevelScoreIncreaseEvent += IncreaseScore;
    }

    private void OnDisable()
    {
        ObjectShippingBoxUse.LevelScoreIncreaseEvent -= IncreaseScore;
    }

    private void IncreaseScore(int levelScore, bool ribbon)
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = levelScore.ToString();
        currentLevelInfo.currentLevelScore += levelScore;
    }
}
