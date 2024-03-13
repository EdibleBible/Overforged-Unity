using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UILevelCompleteScore : MonoBehaviour
{
    [SerializeField] private CurrentLevelInfo currentLevelInfo;
    private TextMeshProUGUI text;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "Score: " + currentLevelInfo.currentLevelScore;
    }
}
