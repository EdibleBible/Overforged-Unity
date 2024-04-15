using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float playerWalkingSpeed = 5f;
    [SerializeField] GameObject playerModel;
    [SerializeField] Rigidbody rb;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * playerWalkingSpeed;
 
        rb.velocity = movement;
        if (movement != Vector3.zero)
        {
            rb.rotation = Quaternion.LookRotation(movement);
        }
    }
}
