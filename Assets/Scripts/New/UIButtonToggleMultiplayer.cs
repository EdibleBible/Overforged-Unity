using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonToggleMultiplayer : MonoBehaviour
{
    public SOGameProgress progress;
    public GameObject SelectedSingle;
    public GameObject SelectedMulti;

    private void OnEnable()
    {
        if (progress.toggleMultiplayer == false)
        {
            SelectedSingle.SetActive(true);
            SelectedMulti.SetActive(false);
        }
    }
    public void Singleplayer()
    {
        progress.toggleMultiplayer = false;
        SelectedSingle.SetActive(true);
        SelectedMulti.SetActive(false);
    }
    public void Multiplayer()
    {
        progress.toggleMultiplayer = true;
        SelectedSingle.SetActive(false);
        SelectedMulti.SetActive(true);
    }
}
