using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerWalkingSpeed = 5f;
    [SerializeField] GameObject playerModel; //Only the player model is being rotated while the player object doesnt

    // Player input set in Player.cs file depenmding on what player slot is set
    internal KeyCode Move_Forward { get; set; }
    internal KeyCode Move_Backward { get; set; }
    internal KeyCode Move_Left { get; set; }
    internal KeyCode Move_Right { get; set; }

    Vector2 inputMovement = Vector2.zero;
    bool Forward,Backward,Left,Right;

    private void ProcessPlayerInput()
    {
        if (Input.GetKeyDown(Move_Forward))
        {
            Forward = true;
        }
        else if (Input.GetKeyUp(Move_Forward)) 
        {
            Forward = false;
        }
        if (Input.GetKeyDown(Move_Backward))
        {
            Backward = true;
        }
        else if (Input.GetKeyUp(Move_Backward))
        {
            Backward = false;
        }
        if (Input.GetKeyDown(Move_Left))
        {
            Left = true;
        }
        else if (Input.GetKeyUp(Move_Left))
        {
            Left = false;
        }
        if (Input.GetKeyDown(Move_Right))
        {
            Right = true;
        }
        else if (Input.GetKeyUp(Move_Right))
        {
            Right = false;
        }
    }

    void Update()
    {
        ProcessPlayerInput(); // check what key is pressed
        inputMovement = Vector2.zero;
        // mozna to zmienic na wbudowany system inputow uzywajac tego getAxis horizotal itd.
        if (Forward)
        {
            inputMovement.y = 1;
        }
        else if (Backward)
        {
            inputMovement.y = -1;
        }
        if (Left)
        {
            inputMovement.x = -1;
        }
        else if (Right)
        {
            inputMovement.x = 1;
        }

        inputMovement = Vector2.ClampMagnitude(inputMovement, 1); // make sure the sped is consistant even if you move diagonally
        Vector3 movement = new Vector3(inputMovement.x, 0f, inputMovement.y) * playerWalkingSpeed * Time.deltaTime;
        if (Time.deltaTime > 0.1f)
            return;
      

        

        if (movement.magnitude > 0.01f) //check if player is moving significantly
        {
            var Rbody = GetComponentInChildren<Rigidbody>();
            Rbody.Move(Rbody.position + movement, Quaternion.LookRotation(movement));
            //Rbody.transform.rotation = Quaternion.LookRotation(movement); // Rotate the player model to face the movement direction
        }
        //transform.Translate(movement);
    }
}
