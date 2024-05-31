using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _ItemInteract : MonoBehaviour, IPlayerInteractive //Can be interacted with by pressing E
{
    public void PlayerInteract(_PlayerItemPickup playerScript) //Method which runs when the player presses E
    {
        if (playerScript.heldItem == null) //If the player holds no item
        {
            playerScript.heldItem = gameObject; //Saves a reference to this item to the player memory
            gameObject.layer = 0; //Makes this item no longer possible to detect by a player when scanning for items
            TeleportItem(playerScript.playerItemSlot); //Teleports the item to the player's item slot empty & changes the parent to be the player item slot empty
            gameObject.GetComponent<Rigidbody>().isKinematic = true; //Makes the item no longer able to be affected by physics
        } else //If the player hold any item already
        {
            playerScript.heldItem = null; //Removes the reference of this item from the player memory
            gameObject.layer = 6; //Makes this item possible to detect again
            gameObject.transform.parent = null; //Makes the item parentless
            gameObject.GetComponent<Rigidbody>().isKinematic = false; //Makes the item possible to affect by physics

        }
        Debug.Log("Detected object: " + gameObject.name);
    }

    public void TeleportItem(Transform target) //Runs when the item has to snap to a slot
    {
        gameObject.transform.parent = target; //Changes the parent of the item to be a specified Transform
        transform.SetPositionAndRotation(target.position, new Quaternion(0, 0, 0, 0)); //Teleports the item to the slot and rotates it to 0
    }
}
