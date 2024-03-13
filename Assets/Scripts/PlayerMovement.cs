using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerWalkingSpeed = 5f;
    [SerializeField] GameObject playerModel;
    void Start()
    {
        
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * playerWalkingSpeed * Time.deltaTime;
        if (movement != Vector3.zero)
        {
            // Rotate the player to face the movement direction
            playerModel.transform.rotation = Quaternion.LookRotation(movement);
        }

        transform.Translate(movement);
    }
}
