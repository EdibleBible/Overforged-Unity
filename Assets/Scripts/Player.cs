using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
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
    };
    public Dictionary<e_PlayerInput, KeyCode> Player2Input = new Dictionary<e_PlayerInput, KeyCode>()
    {
        { e_PlayerInput.Move_Forward, KeyCode.UpArrow },
        { e_PlayerInput.Move_Backward, KeyCode.DownArrow },
        { e_PlayerInput.Move_Left, KeyCode.LeftArrow },
        { e_PlayerInput.Move_Right, KeyCode.RightArrow },
        { e_PlayerInput.Use_Action, KeyCode.RightControl },
        { e_PlayerInput.PutDown_Action, KeyCode.Keypad0 },
    };

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
