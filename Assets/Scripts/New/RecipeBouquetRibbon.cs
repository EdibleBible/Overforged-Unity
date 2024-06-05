using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeBouquetRibbon : MonoBehaviour, IItemRecipe
{
    public List<GameObject> objectInventory = new();
    private GameObject ribbonObject;
    private GameObject bouquetObject;

    public void RecipeInteract(PlayerInteract playerScript)
    {
        if (ribbonObject != null && bouquetObject != null)
        {

        }
        if (ribbonObject == null && playerScript.IsItemOfType(ItemTypes.ItemType.Ribbon))
        {

        }
        else if (bouquetObject == null && playerScript.IsItemOfType(ItemTypes.ItemType.Bouquet))
        {
            playerScript.heldItem.SetActive(false);
        }
    }
}
