using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteract : MonoBehaviour, IPlayerItem
{
    public ItemBaseScript info;
    public enum PickupType {item, recipe};
    public PickupType pickupType;
    public void PlayerItemInteraction(PlayerInteract playerScript) //Method which runs when the player presses Q
    {
        if (playerScript.item == null) //If the player holds no item, the item is picked up
        {
            PickUpItem(playerScript); //Places the item into player's slot, so it's picked up
            Debug.Log("Picked up: " + gameObject.name);
        }
        else //If the player holds any item already, the item is dropped freely
        {
            DropItem(playerScript); //Drops the item from the player's slot
            Debug.Log("Dropped: " + gameObject.name);
        }
    }

    public void PickUpItem(PlayerInteract playerScript) //Runs when the item is picked up by the player into their hands
    {
        DisableItem(true); //Makes the item undetectable, not affected by physics and not colliding
        TeleportItem(playerScript.slot); //Teleports the item to the slot's empty & changes the parent to be the player item slot empty
        playerScript.item = gameObject; //Saves a reference to this item to the player memory
    }
    public void PickUpItem(PlayerInteract playerScript, SlotInteract slotScript) //Runs when the item is picked up by the player into their hands from a slot
    {
        DisableItem(true); //Makes the item undetectable, not affected by physics and not colliding
        TeleportItem(playerScript.slot); //Teleports the item to the slot's empty & changes the parent to be the player item slot empty
        playerScript.item = gameObject; //Saves a reference to this item to the player memory
        slotScript.stuckItem = null; //Removes the reference to this item from the slot memory
    }

    public void PlaceItem(PlayerInteract playerScript, SlotInteract slotScript, Transform slotTransform) //Runs when the item is being placed into any slot from player's hands
    {
        DisableItem(true); //Makes the item undetectable, not affected by physics and not colliding
        TeleportItem(slotTransform); //Teleports the item to the slot's empty & changes the parent to be the player item slot empty
        slotScript.stuckItem = gameObject; //Saves a reference to this item to the slot memory
        playerScript.item = null; //Removes the reference to this item from the player memory
    }

    public void PlaceItem(PlayerInteract playerScript, CrafterSlotInteract slotScript, Transform slotTransform) //Runs when the item is being placed into any slot from player's hands
    {
        DisableItem(true); //Makes the item undetectable, not affected by physics and not colliding
        TeleportItem(slotTransform); //Teleports the item to the slot's empty & changes the parent to be the player item slot empty
        slotScript.stuckObject = gameObject; //Saves a reference to this item to the slot memory
        playerScript.item = null; //Removes the reference to this item from the player memory
    }

    public void DropItem(PlayerInteract playerScript) //Runs when the player drops the item freely from their hands
    {
        DisableItem(false); //Makes the item detectable, affected by physics and colliding
        gameObject.transform.parent = null; //Makes the item parentless
        playerScript.item = null; //Removes the reference of this item from the player memory
    }

    public void InputItem(PlayerInteract playerScript, GameObject recipeObject)
    {
        playerScript.item = null;
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
        else if (gameObject.GetComponent<ItemInteract>().isRecipe())
        {
            gameObject.layer = 10; //Makes the item detectable by players
        }
        else
        {
            gameObject.layer = 6;
        }
        gameObject.GetComponent<Rigidbody>().isKinematic = toBeDisabled; //Makes the item possible (if true) to affect by physics
        gameObject.GetComponent<Collider>().isTrigger = toBeDisabled; //Makes the item cause (if true) collisions
    }

    public bool isRecipe()
    {
        if (pickupType == PickupType.item)
        {
            return false;
        }
        return true;
    }
}
