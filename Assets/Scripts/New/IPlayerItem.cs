using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerItem //Interface for all items which can be interacted with by pressing Q
{
    void PlayerItemInteraction(PlayerInteract playerScript); //Base method which handles the player interaction script
}
