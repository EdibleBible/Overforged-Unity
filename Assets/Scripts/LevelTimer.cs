using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
    public float duration = 180f; // Initial duration in seconds
    public TMP_Text timerText; // Reference to the TextMeshPro text component

    private void Start()
    {
        // Initialize the timer text
        UpdateTimerText();

        // Start the timer coroutine
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        while (duration > 0f)
        {
            // Decrease the duration by deltaTime each frame
            duration -= Time.deltaTime;

            // Update the timer text
            UpdateTimerText();

            yield return null;
        }

        // Ensure the timer ends at 0 and update the text one last time
        duration = 0f;
        UpdateTimerText();
        FinishLevel();
    }

    private void UpdateTimerText()
    {
        // Format the time into minutes and seconds
        int minutes = Mathf.FloorToInt(duration / 60f);
        int seconds = Mathf.FloorToInt(duration % 60f);

        // Update the TMP text component with the formatted time
        if (timerText != null)
        {
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void FinishLevel()
    {
        Time.timeScale = 0f; //Stops the game clock
        SceneManager.LoadScene("Scenes/UIFinishLevel", LoadSceneMode.Additive); //Loads the Level Finish scene on top
    }
}
