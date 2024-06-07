using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotInteract : MonoBehaviour, IPlayerItem
{
    public GameObject stuckItem;

    public void PlayerItemInteraction(PlayerInteract playerScript)
    {
        if (playerScript.item != null && stuckItem == null)
        {
            PlaceItem(playerScript.ReturnItemMovementScript(), playerScript);
        }
        else if (playerScript.item == null &&  stuckItem != null)
        {
            PickUpItem(stuckItem.GetComponent<ItemMove>(), playerScript);
        }
    }

    public void PlaceItem(ItemMove itemScript, PlayerInteract playerScript)
    {
        itemScript.PlaceItem(playerScript, this, this.gameObject.transform);
        gameObject.layer = 9;
        Debug.Log("Placed: " + stuckItem.name);
    }

    public void PickUpItem(ItemMove itemScript, PlayerInteract playerScript)
    {
        Debug.Log("Picked up: " + stuckItem.name);
        gameObject.layer = 8;
        itemScript.PickUpItem(playerScript, this);
    }

    public void DisableSlot(bool toBeDisabled)
    {
        if (toBeDisabled) { gameObject.layer = 0; } else { gameObject.layer = 8; }
    }
}
