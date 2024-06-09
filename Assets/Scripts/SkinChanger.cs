using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public e_PlayerSlot PlayerSlot;
    private Player PlayerReference;
    public TMP_Dropdown tMP_Dropdown;
    void Start()
    {

        var players = FindObjectsByType<Player>(FindObjectsSortMode.None);
        foreach (var player in players)
        {
            if (player.PlayerSlot == PlayerSlot) 
            {
                PlayerReference = player;
                break;
            }
        }
        tMP_Dropdown.onValueChanged.AddListener(delegate { SkinChanged(tMP_Dropdown); });
        if (PlayerSlot == e_PlayerSlot.PlayerOne)
            tMP_Dropdown.value = PlayerPrefs.GetInt("Player1Skin");
        if (PlayerSlot == e_PlayerSlot.PlayerTwo)
            tMP_Dropdown.value = PlayerPrefs.GetInt("Player2Skin");

    }
    public void SkinChanged(TMP_Dropdown dropdown) 
    {
        PlayerReference.ChangeSkin(dropdown.value);
    }
}
