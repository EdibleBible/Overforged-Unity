using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemTypes;

public class RecipeGeneric : MonoBehaviour, IItemRecipe
{
    public GameObject recipeProduct;
    public List<ItemTypes.ItemType> recipeItems = new();
    public List<int> recipeItemCounts = new();
    public float timeToCraft = 3f;
    private Dictionary<ItemTypes.ItemType, int> recipeDict = new();
    private Dictionary<ItemTypes.ItemType, int> inventoryDict = new();
    private int craftValue = 0;

    private void Awake()
    {
        for (int i = 0; i < recipeItems.Count; i++)
        {
            recipeDict.Add(recipeItems[i], recipeItemCounts[i]);
            inventoryDict.Add(recipeItems[i], 0);
        }
    }

    public void RecipeInteract(PlayerInteract playerScript, CrafterSlotInteract crafterSlot)
    {
        if (playerScript.HoldsItem())
        {
            ItemTypes.ItemType itemType = playerScript.GetItemType();
            if (CanInput(itemType) && !EnoughInputOfType(itemType))
            {
                AddValue(playerScript.GetItemValue());
                playerScript.ReturnItemMovementScript().InputItem(playerScript, gameObject);
                inventoryDict[itemType]++;
                return;
            }
        }
        if (InventoryFull())
        {
            crafterSlot.Craft(recipeProduct, timeToCraft, craftValue);
            gameObject.SetActive(false);
        }
    }

    bool CanInput(ItemTypes.ItemType itemType)
    {
        return recipeDict.ContainsKey(itemType);
    }

    bool EnoughInputOfType(ItemTypes.ItemType itemType)
    {
        if (inventoryDict[itemType] < recipeDict[itemType])
        {
            return false;
        }
        return true;
    }

    bool InventoryFull()
    {
        foreach (var itemType in inventoryDict.Keys)
        {
            if (inventoryDict[itemType] < recipeDict[itemType])
            {
                return false;
            }
        }
        return true;
    }

    void AddValue(int value)
    {
        craftValue += value;
    }
}
