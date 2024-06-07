using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemRecipe
{
    void RecipeInteract(PlayerInteract player, ItemInteract item, CrafterSlotInteract crafterSlot);
}
