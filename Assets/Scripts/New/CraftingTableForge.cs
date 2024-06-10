using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemTypes;

public class CraftingTableForge : MonoBehaviour, IRecipeInitializer
{
    [SerializeField] private GameObject recipePickaxe;
    [SerializeField] private GameObject recipeAxe;
    public ItemInteract InitializeRecipe(ItemInteract item, GameObject slotObject)
    {
        switch (item.info.itemType)
        {
            case ItemType.IronAxeHead:
                return Instantiate(recipeAxe, slotObject.transform).GetComponent<ItemInteract>();
            case ItemType.IronPickHead:
                return Instantiate(recipePickaxe, slotObject.transform).GetComponent<ItemInteract>();
        }
        return null;
    }
}
