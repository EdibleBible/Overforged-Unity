using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageBoxInteract : MonoBehaviour, IPlayerInteractive
{
    [SerializeField] private List<GameObject> itemList = new(); //List of items this storage box can output (assigned in the Inspector)
    [SerializeField] private SlotInteract slot;

    public void PlayerInteract(PlayerInteract player, ItemInteract item)
    {
        if (!slot.HasItem() && !player.HasItem())
        {
            Instantiate(itemList[Random.Range(0, itemList.Count)], slot.transform).GetComponent<ItemInteract>().PickUp(player);
        }
    }
}
