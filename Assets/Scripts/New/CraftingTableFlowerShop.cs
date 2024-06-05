using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTableFlowerShop : MonoBehaviour, IRecipeInitializer
{
    [SerializeField] private GameObject recipeBouquet;
    [SerializeField] private GameObject recipeBouquetRibbon;
    public GameObject InitializeRecipe(PlayerInteract playerScript, Transform slotTransform)
    {
        switch (playerScript.GetItemType())
        {
            case ItemTypes.ItemType.Flower:
                return Instantiate(recipeBouquet, slotTransform.position, new Quaternion(0f,0f, 0f, 0f));
            case ItemTypes.ItemType.Bouquet:
                return Instantiate(recipeBouquetRibbon, slotTransform.position, new Quaternion(0f, 0f, 0f, 0f));
        }
        return null;
    }
}
