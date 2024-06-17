using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanInteract : MonoBehaviour, IInteractEItem, IInteractQItem, IInteract
{
    public bool InteractCheck(PlayerInteract player, ItemInteract item)
    {
        return true;
    }

    public bool InteractEItem(PlayerInteract player, ItemInteract item)
    {
        Trash(player, item);
        return true;
    }

    public bool InteractQItem(PlayerInteract player, ItemInteract item)
    {
        Trash(player, item);
        return true;
    }

    public void Trash(PlayerInteract player, ItemInteract item)
    {
        if (player.itemObject)
        {
            Destroy(item.gameObject);
            player.Forget();
        }
    }
}
