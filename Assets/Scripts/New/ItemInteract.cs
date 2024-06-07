using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteract : MonoBehaviour, IPlayerItem
{
    public ItemBaseScript info;
    public enum PickupType {item, recipe};
    public PickupType pickupType;
    public void PlayerItemInteraction(PlayerInteract player, ItemInteract item) //Method which runs when the player presses Q
    {
        if (player.HasItem()) //If the player holds no item, the item is picked up
        {
            Drop(player); //Drops the item from the player's slot
            Debug.Log("Dropped: " + gameObject.name);
        }
        else //If the player holds any item already, the item is dropped freely
        {
            PickUp(player); //Places the item into player's slot, so it's picked up
            Debug.Log("Picked up: " + gameObject.name);
        }
    }

    public void PickUp(PlayerInteract player) //Runs when the item is picked up by the player into their hands
    {
        DisableItem(true); //Makes the item undetectable, not affected by physics and not colliding
        TeleportItem(player.slot); //Teleports the item to the slot's empty & changes the parent to be the player item slot empty
        player.SetItem(gameObject); //Saves a reference to this item to the player memory
    }
    public void PickUp(PlayerInteract player, SlotInteract slot) //Runs when the item is picked up by the player into their hands from a slot
    {
        DisableItem(true); //Makes the item undetectable, not affected by physics and not colliding
        TeleportItem(player.slot); //Teleports the item to the slot's empty & changes the parent to be the player item slot empty
        player.SetItem(gameObject); //Saves a reference to this item to the player memory
        slot.Forget(); //Removes the reference to this item from the slot memory
    }

    public void Place(PlayerInteract player, SlotInteract slot, Transform target) //Runs when the item is being placed into any slot from player's hands
    {
        DisableItem(true); //Makes the item undetectable, not affected by physics and not colliding
        TeleportItem(target); //Teleports the item to the slot's empty & changes the parent to be the player item slot empty
        slot.SetItem(gameObject); //Saves a reference to this item to the slot memory
        player.Forget(); //Removes the reference to this item from the player memory
    }

    public void Place(PlayerInteract player, CrafterSlotInteract slot, Transform target) //Runs when the item is being placed into any slot from player's hands
    {
        DisableItem(true); //Makes the item undetectable, not affected by physics and not colliding
        TeleportItem(target); //Teleports the item to the slot's empty & changes the parent to be the player item slot empty
        slot.SetItem(gameObject); //Saves a reference to this item to the slot memory
        player.Forget(); //Removes the reference to this item from the player memory
    }

    public void Drop(PlayerInteract player) //Runs when the player drops the item freely from their hands
    {
        DisableItem(false); //Makes the item detectable, affected by physics and colliding
        gameObject.transform.parent = null; //Makes the item parentless
        player.Forget(); //Removes the reference of this item from the player memory
    }

    public void TeleportItem(Transform target) //Runs when the item has to snap to a slot
    {
        gameObject.transform.parent = target; //Changes the parent of the item to be a specified Transform
        transform.SetPositionAndRotation(target.position, new Quaternion(0, 0, 0, 0)); //Teleports the item to the slot and rotates it to 0
    }

    public void Input(PlayerInteract player, Transform target)
    {
        player.Forget();
        DisableItem(gameObject);
        gameObject.SetActive(false);
        gameObject.transform.parent = target;
    }

    public void DisableItem(bool toBeDisabled)
    {
        if (toBeDisabled)
        {
            gameObject.layer = 0; //Makes the item undetectable by players
        }
        else if (IsRecipe())
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

    public bool IsRecipe()
    {
        if (pickupType == PickupType.item)
        {
            return false;
        }
        return true;
    }
}
