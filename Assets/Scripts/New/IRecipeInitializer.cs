using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRecipeInitializer
{
    GameObject InitializeRecipe(PlayerInteract playerScript, GameObject slotObject);
}
