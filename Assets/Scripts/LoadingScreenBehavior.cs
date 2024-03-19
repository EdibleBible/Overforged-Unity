using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenBehavior : MonoBehaviour //Unused
{
    [SerializeField] private float loadingTime = 5f;
    private float remainingTime;
    private Image fillImage;

    void Awake()
    {
        Time.timeScale = 1f;
        remainingTime = loadingTime;
        fillImage = GetComponent<Image>();
        StartCoroutine(WaitAndSwitchScene());
    }

    private void Update()
    {
        remainingTime -= Time.deltaTime;
        fillImage.fillAmount = 1-(remainingTime/loadingTime);
    }

    IEnumerator WaitAndSwitchScene()
    {
        yield return new WaitForSeconds(loadingTime);

        SceneManager.LoadScene("Scenes/TestLevel");
    }
}
