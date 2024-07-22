using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInputKey : MonoBehaviour
{
    public int playerInt;
    public PlayerMovement playerMovement;
    public PlayerInteract playerInteract;

    private void Update()
    {
        if (playerInt == 1)
        {
            playerMovement.horizontalInput = Input.GetAxis("Horizontal");
            playerMovement.verticalInput = Input.GetAxis("Vertical");
            if (Input.GetKeyDown(KeyCode.E)) { playerInteract.KeyInteract(); }
            if (Input.GetKeyDown(KeyCode.Q)) { playerInteract.KeyItem(); }
        } else if (playerInt == 2)
        {
            playerMovement.horizontalInput = Input.GetAxis("Horizontal2");
            playerMovement.verticalInput = Input.GetAxis("Vertical2");
            if (Input.GetKeyDown(KeyCode.RightShift)) { playerInteract.KeyInteract(); }
            if (Input.GetKeyDown(KeyCode.RightControl)) { playerInteract.KeyItem(); }
        }
    }
}
