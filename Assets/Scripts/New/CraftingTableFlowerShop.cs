using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemTypes;

public class CraftingTableFlowerShop : MonoBehaviour, IRecipeInitializer
{
    [SerializeField] private GameObject recipeBouquet;
    [SerializeField] private GameObject recipeBouquetRibbon;
    public ItemInteract InitializeRecipe(ItemInteract item, GameObject slotObject)
    {
        switch (item.info.itemType)
        {
            case ItemType.Flower:
                return Instantiate(recipeBouquet, slotObject.transform).GetComponent<ItemInteract>();
            case ItemType.Bouquet:
                return Instantiate(recipeBouquetRibbon, slotObject.transform).GetComponent<ItemInteract>();
            case ItemType.Ribbon:
                return Instantiate(recipeBouquetRibbon, slotObject.transform).GetComponent<ItemInteract>();
        }
        return null;
    }
}
