using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIIconClock : MonoBehaviour
{
    public Image fill;
    public float localTime;
    public float craftingTime;
    public void Craft(float time)
    {
        localTime = 0;
        StartCoroutine(FillOvertime(time));
    }

    IEnumerator FillOvertime(float time)
    {
        craftingTime = time;
        float elapsedTime = 0f;
        while (elapsedTime < craftingTime)
        {
            elapsedTime += Time.deltaTime;
            fill.fillAmount = Mathf.Clamp01(elapsedTime / craftingTime);
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
