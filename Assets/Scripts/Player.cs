using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    private int selectedSkinIndex;
    internal PlayerMovement playerMovement;
    internal PlayerPickUpItem pickUpItem;
    public e_PlayerSlot PlayerSlot;
    public Dictionary<e_PlayerInput, KeyCode> Player1Input = new Dictionary<e_PlayerInput, KeyCode>()
    {
        { e_PlayerInput.Move_Forward, KeyCode.W },
        { e_PlayerInput.Move_Backward, KeyCode.S },
        { e_PlayerInput.Move_Left, KeyCode.A },
        { e_PlayerInput.Move_Right, KeyCode.D },
        { e_PlayerInput.Use_Action, KeyCode.E },
        { e_PlayerInput.PutDown_Action, KeyCode.Q },
        { e_PlayerInput.SkinChangeDown, KeyCode.Alpha1 },
        { e_PlayerInput.SkinChangeUp, KeyCode.Alpha2 },
    };
    public Dictionary<e_PlayerInput, KeyCode> Player2Input = new Dictionary<e_PlayerInput, KeyCode>()
    {
        { e_PlayerInput.Move_Forward, KeyCode.UpArrow },
        { e_PlayerInput.Move_Backward, KeyCode.DownArrow },
        { e_PlayerInput.Move_Left, KeyCode.LeftArrow },
        { e_PlayerInput.Move_Right, KeyCode.RightArrow },
        { e_PlayerInput.Use_Action, KeyCode.RightControl },
        { e_PlayerInput.PutDown_Action, KeyCode.Keypad0 },
        { e_PlayerInput.SkinChangeDown, KeyCode.Keypad1 },
        { e_PlayerInput.SkinChangeUp, KeyCode.Keypad2 },
   };

    public List<GameObject> Skins = new List<GameObject>();
    internal void ChangeSkin(int index=0)
    {
        if (Skins.Count <= index)
            return;
        var selectedMaterial = Skins[index];
        for (int i = 0; i < Skins.Count; i++)
        {
            var skin = Skins[i];
            if (i == index)
            {
                skin.SetActive(true);
            }
            else
            {
                skin.SetActive(false);
            }
        }
        if(PlayerSlot == e_PlayerSlot.PlayerOne)
            PlayerPrefs.SetInt("Player1Skin", index);
        if(PlayerSlot == e_PlayerSlot.PlayerTwo)
            PlayerPrefs.SetInt("Player2Skin", index);

        PlayerPrefs.Save();
    }

    internal void ChangeSkinUp()
    {
        selectedSkinIndex += 1;
        if (selectedSkinIndex >= Skins.Count - 1)
        {
            selectedSkinIndex = 0;
        }
        ChangeSkin(selectedSkinIndex);
    }
    internal void ChangeSkinDown()
    {
        selectedSkinIndex -= 1;
        if (selectedSkinIndex < 0)
        {
            selectedSkinIndex = Skins.Count -1;
        }
        ChangeSkin(selectedSkinIndex);
    }

    internal KeyCode GetInput(e_PlayerInput InputName) 
    {
        return (PlayerSlot == e_PlayerSlot.PlayerOne) ? Player1Input[InputName] : Player2Input[InputName];
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerSlot == e_PlayerSlot.None) print("Niewybrano sloty gracza dla Gracza");
        playerMovement = GetComponent<PlayerMovement>();
        pickUpItem = GetComponentInChildren<PlayerPickUpItem>();
        pickUpItem.PlayerRef = this;
        pickUpItem.PickupItemKey = GetInput(e_PlayerInput.Use_Action);
        pickUpItem.PutDownItemKey = GetInput(e_PlayerInput.PutDown_Action);
        playerMovement.Move_Forward = GetInput(e_PlayerInput.Move_Forward);
        playerMovement.Move_Backward = GetInput(e_PlayerInput.Move_Backward);
        playerMovement.Move_Left = GetInput(e_PlayerInput.Move_Left);
        playerMovement.Move_Right = GetInput(e_PlayerInput.Move_Right);
        //playerMovement.SkinChangeUp = GetInput(e_PlayerInput.SkinChangeUp);
        ///playerMovement.SkinChangeDown = GetInput(e_PlayerInput.SkinChangeDown);
        if (PlayerSlot == e_PlayerSlot.PlayerOne)
            selectedSkinIndex = PlayerPrefs.GetInt("Player1Skin");
        if (PlayerSlot == e_PlayerSlot.PlayerTwo)
            selectedSkinIndex = PlayerPrefs.GetInt("Player2Skin");
        ChangeSkin(selectedSkinIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(GetInput(e_PlayerInput.SkinChangeUp)))
        {
            ChangeSkinUp();
        }
        if (Input.GetKeyDown(GetInput(e_PlayerInput.SkinChangeDown)))
        {
            ChangeSkinDown();
        }
    }
}
