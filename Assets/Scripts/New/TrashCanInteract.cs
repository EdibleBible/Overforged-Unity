using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanInteract : MonoBehaviour, IPlayerItem, IPlayerInteractive
{
    public void PlayerInteract(PlayerInteract player, ItemInteract item)
    {
        Trash(player, item);
    }

    public void PlayerItemInteraction(PlayerInteract player, ItemInteract item)
    {
        Trash(player, item);
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
