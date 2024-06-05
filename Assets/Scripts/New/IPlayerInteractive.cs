using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerInteractive //Interface for all objects which can be interacted with by pressing E
{
    void PlayerInteract(PlayerInteract playerScript); //Base method which handles the player interaction script
}
