using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelshippingController : MonoBehaviour
{
    private int bouquetsShipped = 0;
    [SerializeField] bool isRibbon;
    public TextMeshProUGUI text;

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
        if (isRibbon == ribbon)
        {
            bouquetsShipped++;
            text = GetComponent<TextMeshProUGUI>();
            text.text = bouquetsShipped.ToString();
        }
    }
}