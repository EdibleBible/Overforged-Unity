using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotInteract : MonoBehaviour, IPlayerItem
{
    public GameObject stuckItem;

    public void PlayerItemInteraction(PlayerInteract player, ItemInteract item)
    {
        if (player.HasItem() && !HasItem())
        {
            item.Place(player, this, gameObject.transform);
            gameObject.layer = 9;
            Debug.Log("Placed: " + stuckItem.name);
        }
        else if (!player.HasItem() &&  HasItem())
        {
            stuckItem.GetComponent<ItemInteract>().PickUp(player, this);
            gameObject.layer = 8;
            Debug.Log("Picked up: " + stuckItem.name);
        }
    }

    public void DisableSlot(bool toBeDisabled)
    {
        if (toBeDisabled) { gameObject.layer = 0; } else { gameObject.layer = 8; }
    }

    public bool HasItem()
    {
        if (stuckItem)
        {
            return true;
        }
        return false;
    }

    public void SetItem(GameObject item)
    {
        stuckItem = item;

    }

    public void SetItem(ItemInteract item)
    {
        stuckItem = item.gameObject;
    }

    public void Forget()
    {
        stuckItem = null;
    }
}
