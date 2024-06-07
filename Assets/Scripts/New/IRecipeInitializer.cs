using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRecipeInitializer
{
    ItemInteract InitializeRecipe(ItemInteract item, GameObject slotObject);
}
