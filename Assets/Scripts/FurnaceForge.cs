using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEnums;

public class FurnaceForge : MonoBehaviour, IRecipeInitializer
{
    [SerializeField] private GameObject recipeIngot;
    public ItemInteract InitializeRecipe(ItemInteract item, GameObject slotObject)
    {
        if (item.IsType(ItemType.IronOre))
        {
            return Instantiate(recipeIngot, slotObject.transform).GetComponent<ItemInteract>();
        }
        return null;
    }
}
