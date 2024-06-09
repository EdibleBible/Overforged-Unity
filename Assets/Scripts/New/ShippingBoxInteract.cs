using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OverForged;
using static ItemTypes;

public class ShippingBoxInteract : MonoBehaviour, IPlayerInteractive
{
    public void PlayerInteract(PlayerInteract player, ItemInteract item)
    {
        if (player.HasItem())
        {
            item.Input(player, transform);
            GameProgress.UpdateProgress(item);
        }
    }
}
