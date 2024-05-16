using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerjoiner : MonoBehaviour
{
    public PlayerInputManager playerInputManager;


    private void Awake()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        playerInputManager.JoinPlayer(0);
        playerInputManager.JoinPlayer(1);
    }
}
