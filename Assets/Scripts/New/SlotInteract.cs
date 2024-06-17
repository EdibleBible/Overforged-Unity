using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlotInteract : MonoBehaviour, IInteractEEmpty, IInteractEItem, IInteract
{
    public GameObject stuckItem;

    public bool InteractCheck(PlayerInteract player, ItemInteract item)
    {
        if (item != null && !HasItem() || item == null && HasItem())
        {
            return true;
        }
        return false;
    }

    public bool InteractEItem(PlayerInteract player, ItemInteract item)
    {
        if (!HasItem())
        {
            item.Place(player, this, gameObject.transform);
            gameObject.layer = 12;
            Debug.Log("Placed: " + stuckItem.name);
            return true;
        }
        return false;
    }

    public bool InteractEEmpty(PlayerInteract player)
    {
        if (HasItem())
        {
            stuckItem.GetComponent<ItemInteract>().PickUp(player, this);
            gameObject.layer = 11;
            Debug.Log("Picked up: " + stuckItem.name);
            return true;
        }
        return false;
    }

    public void DisableSlot(bool toBeDisabled)
    {
        if (toBeDisabled) { gameObject.layer = 0; } else { gameObject.layer = 11; }
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
