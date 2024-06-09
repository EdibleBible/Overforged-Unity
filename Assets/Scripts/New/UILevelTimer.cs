using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using OverForged;

public class UILevelTimer : MonoBehaviour
{
    public TMP_Text timerText; // Reference to the TextMeshPro text component

    private void OnEnable()
    {
        GameProgress.ProgressTimeEvent += UpdateTimerText;
    }

    private void OnDisable()
    {
        GameProgress.ProgressTimeEvent -= UpdateTimerText;
    }

    private void UpdateTimerText(float duration)
    {
        // Format the time into minutes and seconds
        int minutes = Mathf.FloorToInt(duration / 60f);
        int seconds = Mathf.FloorToInt(duration % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
