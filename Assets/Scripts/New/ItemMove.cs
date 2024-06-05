using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    public void PickUpItem(PlayerInteract playerScript) //Runs when the item is picked up by the player into their hands
    {
        DisableItem(true); //Makes the item undetectable, not affected by physics and not colliding
        TeleportItem(playerScript.playerItemSlot); //Teleports the item to the slot's empty & changes the parent to be the player item slot empty
        playerScript.heldItem = gameObject; //Saves a reference to this item to the player memory
    }
    public void PickUpItem(PlayerInteract playerScript, SlotInteract slotScript) //Runs when the item is picked up by the player into their hands from a slot
    {
        DisableItem(true); //Makes the item undetectable, not affected by physics and not colliding
        TeleportItem(playerScript.playerItemSlot); //Teleports the item to the slot's empty & changes the parent to be the player item slot empty
        playerScript.heldItem = gameObject; //Saves a reference to this item to the player memory
        slotScript.stuckItem = null; //Removes the reference to this item from the slot memory
    }

    public void PlaceItem(PlayerInteract playerScript, SlotInteract slotScript, Transform slotTransform) //Runs when the item is being placed into any slot from player's hands
    {
        DisableItem(true); //Makes the item undetectable, not affected by physics and not colliding
        TeleportItem(slotTransform); //Teleports the item to the slot's empty & changes the parent to be the player item slot empty
        slotScript.stuckItem = gameObject; //Saves a reference to this item to the slot memory
        playerScript.heldItem = null; //Removes the reference to this item from the player memory
    }

    public void DropItem(PlayerInteract playerScript) //Runs when the player drops the item freely from their hands
    {
        DisableItem(false); //Makes the item detectable, affected by physics and colliding
        gameObject.transform.parent = null; //Makes the item parentless
        playerScript.heldItem = null; //Removes the reference of this item from the player memory
    }

    public void PlaceInObjectInventory(PlayerInteract playerScript, GameObject recipeObject)
    {
        playerScript.heldItem = null;
        gameObject.SetActive(false);
        transform.parent = recipeObject.transform;
    }

    public void TeleportItem(Transform target) //Runs when the item has to snap to a slot
    {
        gameObject.transform.parent = target; //Changes the parent of the item to be a specified Transform
        transform.SetPositionAndRotation(target.position, new Quaternion(0, 0, 0, 0)); //Teleports the item to the slot and rotates it to 0
    }

    public void DisableItem(bool toBeDisabled)
    {
        if (toBeDisabled)
        {
            gameObject.layer = 0; //Makes the item undetectable by players
        }
        else
        {
            gameObject.layer = 6; //Makes the item detectable by players
        }
        gameObject.GetComponent<Rigidbody>().isKinematic = toBeDisabled; //Makes the item possible (if true) to affect by physics
        gameObject.GetComponent<Collider>().isTrigger = toBeDisabled; //Makes the item cause (if true) collisions
    }
}
