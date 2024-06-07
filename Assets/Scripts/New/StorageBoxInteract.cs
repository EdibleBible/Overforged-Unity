using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageBoxInteract : MonoBehaviour, IPlayerInteractive
{
    [SerializeField] private List<GameObject> itemList = new(); //List of items this storage box can output (assigned in the Inspector)
    [SerializeField] private SlotInteract slot;

    public void PlayerInteract(PlayerInteract playerScript)
    {
        if (slot.stuckItem == null && playerScript.heldItem == null)
        {
            GameObject spawnedItem = Instantiate(itemList[Random.Range(0, itemList.Count)], slot.transform);
            spawnedItem.GetComponent<ItemMove>().PickUpItem(playerScript);
        }
    }
}
