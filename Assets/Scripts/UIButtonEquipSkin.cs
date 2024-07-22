using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonEquipSkin : MonoBehaviour
{
    public SOGameProgress progress;
    public int skinInt;
    public Button button;
    public TMP_Text text;
    public int playerInt;
    private void OnEnable()
    {
        if (!progress.skinUnlocked[skinInt])
        {
            button.interactable = false;
            text.text = "Locked";
        }
        else if (playerInt == 1 && (int)progress.player1Skin == skinInt)
        {
            button.interactable = false;
            text.text = "Equipped";
        }
        else if (playerInt == 2 && (int)progress.player2Skin == skinInt)
        {
            button.interactable = false;
            text.text = "Equipped";
        } else
        {
            button.interactable = true;
            text.text = "Equip";
        }
    }

    public void Equip()
    {
        button.interactable = false;
        text.text = "Equipped";
        if (playerInt == 1)
        {
            progress.EquipSkin1(skinInt);
        } else
        {
            progress.EquipSkin2(skinInt);
        }
    }
}
