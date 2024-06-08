using OverForged;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILevelScore : MonoBehaviour
{
    public TextMeshProUGUI textGui;
    public int localScore;

    private void OnEnable()
    {
        GameProgress.ProgressEvent += UpdateScore;
        textGui.text = localScore.ToString();
    }

    private void OnDisable()
    {
        GameProgress.ProgressEvent -= UpdateScore;
    }

    void UpdateScore(ItemInteract item)
    {
        textGui.text = (localScore += item.info.itemValue).ToString();
    }
}
