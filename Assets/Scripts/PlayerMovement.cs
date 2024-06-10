
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float playerWalkingSpeed = 5f;
    [SerializeField] GameObject playerModel;
    [SerializeField] Rigidbody rb;
    private bool playerCanMove = true;
    public float horizontalInput;
    public float verticalInput;

    void Update()
    {
        if (playerCanMove)
        {
            Vector3 movement = new Vector3(-verticalInput, 0f, horizontalInput) * playerWalkingSpeed;

            rb.velocity = movement;
            if (movement != Vector3.zero)
            {
                rb.rotation = Quaternion.LookRotation(movement);
            }
        }
    }

    public void PlayerCanMove(bool canMove)
    {
        playerCanMove = canMove;
    }
}

