using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageBoxInteract : MonoBehaviour, IInteractEEmpty, IInteract
{
    [SerializeField] private List<GameObject> itemList = new(); //List of items this storage box can output (assigned in the Inspector)
    [SerializeField] private SlotInteract slot;

    public bool InteractCheck(PlayerInteract player, ItemInteract item)
    {
        if (slot.HasItem())
        {
            return false;
        }
        return true;
    }

    public bool InteractEEmpty(PlayerInteract player)
    {
        if (!slot.HasItem())
        {
            Instantiate(itemList[Random.Range(0, itemList.Count)], slot.transform).GetComponent<ItemInteract>().PickUp(player);
            return true;
        }
        return false;
    }
}
