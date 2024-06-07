using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShippingBoxInteract : MonoBehaviour, IPlayerInteractive
{
    public void PlayerInteract(PlayerInteract player, ItemInteract item)
    {
        if (player.HasItem())
        {
        }
    }
}
