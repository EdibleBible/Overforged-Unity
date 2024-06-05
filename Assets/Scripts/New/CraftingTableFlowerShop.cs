using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTableFlowerShop : MonoBehaviour, IRecipeInitializer
{
    [SerializeField] private GameObject recipeBouquet;
    [SerializeField] private GameObject recipeBouquetRibbon;
    public GameObject InitializeRecipe(PlayerInteract playerScript, GameObject slot)
    {
        switch (playerScript.GetItemType())
        {
            case ItemTypes.ItemType.Flower:
                return Instantiate(recipeBouquet, slot.transform);
            case ItemTypes.ItemType.Bouquet:
                return Instantiate(recipeBouquetRibbon, slot.transform);
        }
        return null;
    }
}
