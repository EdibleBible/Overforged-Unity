using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteract
{
    bool InteractCheck(PlayerInteract player, ItemInteract item);
}
