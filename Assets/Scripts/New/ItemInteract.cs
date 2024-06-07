using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteract : MonoBehaviour, IPlayerItem
{
    [SerializeField] private ItemMove itemScript;
    public enum PickupType {item, recipe};
    public PickupType pickupType;
    public void PlayerItemInteraction(PlayerInteract playerScript) //Method which runs when the player presses Q
    {
        if (playerScript.heldItem == null) //If the player holds no item, the item is picked up
        {
            itemScript.PickUpItem(playerScript); //Places the item into player's slot, so it's picked up
            Debug.Log("Picked up: " + gameObject.name);
        }
        else //If the player holds any item already, the item is dropped freely
        {
            itemScript.DropItem(playerScript); //Drops the item from the player's slot
            Debug.Log("Dropped: " + gameObject.name);
        }
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
