using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerWalkingSpeed = 5f;
    [SerializeField] GameObject playerModel; //Only the player model is being rotated while the player object doesnt

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * playerWalkingSpeed * Time.deltaTime;
        if (movement != Vector3.zero) //If the player is moving
        {
            playerModel.transform.rotation = Quaternion.LookRotation(movement); // Rotate the player model to face the movement direction
        }

        transform.Translate(movement);
    }
}
