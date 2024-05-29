using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
    public TMP_Text timerText; // Reference to the TextMeshPro text component

    private void OnEnable()
    {
        LevelProgressionController.TimerUpdateEvent += UpdateTimerText;
    }

    private void OnDisable()
    {
        LevelProgressionController.TimerUpdateEvent -= UpdateTimerText;
    }

    private void UpdateTimerText(float duration)
    {
        // Format the time into minutes and seconds
        int minutes = Mathf.FloorToInt(duration / 60f);
        int seconds = Mathf.FloorToInt(duration % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
