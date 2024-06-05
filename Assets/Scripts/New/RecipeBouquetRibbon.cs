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
        GameObject heldItem = playerScript.heldItem;
        if (ribbonObject != null && bouquetObject != null)
        {

        }
        if (ribbonObject == null && playerScript.IsItemOfType(ItemTypes.ItemType.Ribbon))
        {
            playerScript.ReturnItemMovementScript().PlaceInObjectInventory(playerScript, gameObject);
            objectInventory.Add(playerScript.heldItem);
        }
        else if (bouquetObject == null && playerScript.IsItemOfType(ItemTypes.ItemType.Bouquet))
        {
            playerScript.ReturnItemMovementScript().PlaceInObjectInventory(playerScript, gameObject);
            objectInventory.Add(playerScript.heldItem);
        }
    }
}
