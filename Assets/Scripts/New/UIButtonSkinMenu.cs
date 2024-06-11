using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonSkinMenu : MonoBehaviour
{
    public List<GameObject> skinObjects = new();
    public int playerInt;
    public int currentSkin;

    private void OnEnable()
    {
        if (playerInt == 1)
        {
            currentSkin = (int)SOGameProgress.player1Skin;
        } else if (playerInt == 2)
        {
            currentSkin = (int)SOGameProgress.player2Skin;
        }
        skinObjects[currentSkin].SetActive(true);
    }

    public void Next()
    {
        if (currentSkin < skinObjects.Count-1)
        {
            skinObjects[currentSkin].SetActive(false);
            currentSkin++;
            skinObjects[currentSkin].SetActive(true);
        }
    }

    public void Previous()
    {
        if (currentSkin > 0)
        {
            skinObjects[currentSkin].SetActive(false);
            currentSkin--;
            skinObjects[currentSkin].SetActive(true);
        }
    }
}
