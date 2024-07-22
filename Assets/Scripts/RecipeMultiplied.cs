using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEnums;

public class RecipeMultiplied : MonoBehaviour, IItemRecipe
{
    public GameObject recipeProduct;
    public List<ItemType> recipeItems = new();
    public List<int> recipeItemCounts = new();
    public float timeToCraft = 3f;
    private Dictionary<ItemType, int> recipeDict = new();
    private Dictionary<ItemType, int> inventoryDict = new();
    private int craftValue = 0;
    private float multiplier = 1;
    public List<ItemType> multiplierItems = new();

    private void Awake()
    {
        for (int i = 0; i < recipeItems.Count; i++)
        {
            recipeDict.Add(recipeItems[i], recipeItemCounts[i]);
            inventoryDict.Add(recipeItems[i], 0);
        }
    }

    public void RecipeInteract(PlayerInteract player, ItemInteract item, CrafterSlotInteract crafter)
    {
        if (player.HasItem())
        {
            ItemType itemType = player.GetItemType();
            if (CanInput(itemType) && !EnoughInputOfType(itemType))
            {
                AddValue(player.GetItemValue(), itemType);
                item.Input(player, gameObject.transform);
                inventoryDict[itemType]++;
                return;
            }
        }
        if (InventoryFull())
        {
            crafter.Craft(recipeProduct, timeToCraft, Mathf.FloorToInt(craftValue * multiplier));
            gameObject.SetActive(false);
        }
    }

    bool CanInput(ItemType itemType)
    {
        return recipeDict.ContainsKey(itemType);
    }

    bool EnoughInputOfType(ItemType itemType)
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

    void AddValue(int value, ItemType type)
    {
        if (multiplierItems.Contains(type))
        {
            multiplier += 0.4f;
        } else
        {
            craftValue += value;
        }
    }
}
