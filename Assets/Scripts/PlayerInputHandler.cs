using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private Mover mover;
    private Mover mover2;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        var movers = FindObjectsOfType<Mover>();
        mover = movers[0];
        mover2 = movers[1];
    }

    public void OnMove(CallbackContext context)
    {
        if(mover != null) 
        mover.SetInputVector(context.ReadValue<Vector2>());
    }

    public void OnMovePlayer2(CallbackContext context)
    {
        if (mover2 != null)
            mover2.SetInputVector(context.ReadValue<Vector2>());
    }



}
