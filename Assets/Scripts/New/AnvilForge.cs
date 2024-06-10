using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemTypes;

public class AnvilForge : MonoBehaviour, IRecipeInitializer
{
    [SerializeField] private GameObject recipeToolHead;
    public ItemInteract InitializeRecipe(ItemInteract item, GameObject slotObject)
    {
        if (item.IsType(ItemType.IronIngot))
        {
            return Instantiate(recipeToolHead, slotObject.transform).GetComponent<ItemInteract>();
        }
        return null;
    }
}
