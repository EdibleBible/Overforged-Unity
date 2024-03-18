using UnityEngine;

public class ObjectTrashCanUse : MonoBehaviour
{
    [SerializeField] private GameObject playerTrigger; //Player collider object

    void OnTriggerExit(Collider other) //When the player is no longer in front of the trashcan the reference is removed so it can no longer be used
    {
        if (other.CompareTag("PlayerTrigger"))
        {
            playerTrigger = null;
        }
    }

    void OnTriggerEnter(Collider other) //When the player approaches the trashcan the reference is made to the slot where the player holds an item
    {
        if (other.CompareTag("PlayerTrigger"))
        {
            playerTrigger = other.gameObject;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerTrigger != null) //When the player presses E & has an item
        {
            Destroy(playerTrigger.transform.GetChild(0).gameObject); //First child object (presumably the held item) of the player item slot is destroyed
            PlayerPickUpItem playerPickUpItem = playerTrigger.GetComponent<PlayerPickUpItem>(); //References the script that handles the player picking up and putting down items
            playerPickUpItem.heldItem = null; //The player no longer thinks they hold an item
            playerPickUpItem.areHandsFull = false; //The player can pick up an item again
        }
    }
}
