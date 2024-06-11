using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonToggleMultiplayer : MonoBehaviour
{
    public GameObject SelectedSingle;
    public GameObject SelectedMulti;

    private void OnEnable()
    {
        if (SOGameProgress.toggleMultiplayer == false)
        {
            SelectedSingle.SetActive(true);
            SelectedMulti.SetActive(false);
        }
    }
    public void Singleplayer()
    {
        SOGameProgress.toggleMultiplayer = false;
        SelectedSingle.SetActive(true);
        SelectedMulti.SetActive(false);
    }
    public void Multiplayer()
    {
        SOGameProgress.toggleMultiplayer = true;
        SelectedSingle.SetActive(false);
        SelectedMulti.SetActive(true);
    }
}
