using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerShopCraftingTable : MonoBehaviour
{
    enum CrafterState {ReadyForAny, ReadyToAddFlower2, ReadyToAddFlower3, ReadyToMakeRibbonBouquet, ReadyToCraft, Crafting, ReadyToPickUp };
    CrafterState crafterState = CrafterState.ReadyForAny;
    [SerializeField] private List<GameObject> materialSlotList = new();
    [SerializeField] private List<GameObject> placedMaterialsList = new();
    [SerializeField] private GameObject instantiateSlot;
    [SerializeField] private float timeToCraft = 3f;
    [SerializeField] private GameObject bouquetPrefab;
    [SerializeField] private GameObject bouquetRibbonPrefab;
    private GameObject playerTrigger;
    private PlayerPickUpItem playerPickUpItem;
    private float playerWalkingSpeedMemory;
    private GameObject instantiatedItem;

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerTrigger"))
        {
            playerTrigger = null;
            playerPickUpItem = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerTrigger"))
        {
            playerTrigger = other.gameObject;
            playerPickUpItem = playerTrigger.GetComponent<PlayerPickUpItem>();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerTrigger != null)
            switch (crafterState)
            {
                case CrafterState.ReadyForAny:
                    {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
                        if (playerPickUpItem.IsHeldItemType(ItemTypes.ItemType.Flower))
                        {
                            crafterState = CrafterState.ReadyToAddFlower2;
                        }
                        else if (playerPickUpItem.IsHeldItemType(ItemTypes.ItemType.Bouquet) || playerPickUpItem.IsHeldItemType(ItemTypes.ItemType.Ribbon))
                        {
                            crafterState = CrafterState.ReadyToMakeRibbonBouquet;
                        }
                        PlaceItemIntoCrafting(playerPickUpItem.heldItem, 0);
=======
=======
>>>>>>> feabb03 (Flower crafting done)
                        if (playerPickUpItem.heldItem != null)
=======
                        if (playerPickUpItem.IsHeldItemType(ItemTypes.ItemType.Flower))
>>>>>>> 6536a23 (Flower crafting bug fixed)
                        {
                            crafterState = CrafterState.ReadyToAddFlower2;
                        }
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> feabb03 (Flower crafting done)
=======
>>>>>>> feabb03 (Flower crafting done)
=======
                        else if (playerPickUpItem.IsHeldItemType(ItemTypes.ItemType.Bouquet) || playerPickUpItem.IsHeldItemType(ItemTypes.ItemType.Ribbon))
                        {
                            crafterState = CrafterState.ReadyToMakeRibbonBouquet;
                        }
                        PlaceItemIntoCrafting(playerPickUpItem.heldItem, 0);
>>>>>>> 6536a23 (Flower crafting bug fixed)
                        break;
                    }
                case CrafterState.ReadyToMakeRibbonBouquet:
                    {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
                        if (playerPickUpItem.ReturnHeldItemType() != placedMaterialsList[0].GetComponent<ItemBaseScript>().itemType &&
                            playerPickUpItem.IsHeldItemType(ItemTypes.ItemType.Bouquet) || playerPickUpItem.IsHeldItemType(ItemTypes.ItemType.Ribbon))
=======
                        if (playerPickUpItem.heldItem != null && playerPickUpItem.ReturnHeldItemType() != placedMaterialsList[0].GetComponent<ItemBaseScript>().itemType &&
                            playerPickUpItem.ReturnHeldItemType() == ItemTypes.ItemType.Bouquet || playerPickUpItem.ReturnHeldItemType() == ItemTypes.ItemType.Ribbon)
>>>>>>> feabb03 (Flower crafting done)
=======
                        if (playerPickUpItem.heldItem != null && playerPickUpItem.ReturnHeldItemType() != placedMaterialsList[0].GetComponent<ItemBaseScript>().itemType &&
                            playerPickUpItem.ReturnHeldItemType() == ItemTypes.ItemType.Bouquet || playerPickUpItem.ReturnHeldItemType() == ItemTypes.ItemType.Ribbon)
>>>>>>> feabb03 (Flower crafting done)
=======
                        if (playerPickUpItem.ReturnHeldItemType() != placedMaterialsList[0].GetComponent<ItemBaseScript>().itemType &&
                            playerPickUpItem.IsHeldItemType(ItemTypes.ItemType.Bouquet) || playerPickUpItem.IsHeldItemType(ItemTypes.ItemType.Ribbon))
>>>>>>> 6536a23 (Flower crafting bug fixed)
                        {
                            PlaceItemIntoCrafting(playerPickUpItem.heldItem, 1);
                            crafterState = CrafterState.ReadyToCraft;
                        }
                        break;
                    }
                case CrafterState.ReadyToAddFlower2:
                    {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
                        if (playerPickUpItem.IsHeldItemType(ItemTypes.ItemType.Flower))
                        {
                            PlaceItemIntoCrafting(playerPickUpItem.heldItem, 1);
=======
=======
>>>>>>> feabb03 (Flower crafting done)
                        if (playerPickUpItem.heldItem != null)
                        {
                            ItemTypes.ItemType heldItemType = playerPickUpItem.heldItem.GetComponent<ItemBaseScript>().itemType;
                            if (heldItemType == ItemTypes.ItemType.Flower)
                            {
                                PlaceItemIntoCrafting(playerPickUpItem.heldItem, 1);
                            }
<<<<<<< HEAD
>>>>>>> feabb03 (Flower crafting done)
=======
>>>>>>> feabb03 (Flower crafting done)
=======
                        if (playerPickUpItem.IsHeldItemType(ItemTypes.ItemType.Flower))
                        {
                            PlaceItemIntoCrafting(playerPickUpItem.heldItem, 1);
>>>>>>> 6536a23 (Flower crafting bug fixed)
                        }
                        crafterState = CrafterState.ReadyToAddFlower3;
                        break;
                    }
                case CrafterState.ReadyToAddFlower3:
                    {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
                        if (playerPickUpItem.IsHeldItemType(ItemTypes.ItemType.Flower))
                        {
                            PlaceItemIntoCrafting(playerPickUpItem.heldItem, 2);
=======
=======
>>>>>>> feabb03 (Flower crafting done)
                        if (playerPickUpItem.heldItem != null)
                        {
                            ItemTypes.ItemType heldItemType = playerPickUpItem.heldItem.GetComponent<ItemBaseScript>().itemType;
                            if (heldItemType == ItemTypes.ItemType.Flower)
                            {
                                PlaceItemIntoCrafting(playerPickUpItem.heldItem, 1);
                            }
<<<<<<< HEAD
>>>>>>> feabb03 (Flower crafting done)
=======
>>>>>>> feabb03 (Flower crafting done)
=======
                        if (playerPickUpItem.IsHeldItemType(ItemTypes.ItemType.Flower))
                        {
                            PlaceItemIntoCrafting(playerPickUpItem.heldItem, 2);
>>>>>>> 6536a23 (Flower crafting bug fixed)
                        }
                        crafterState = CrafterState.ReadyToCraft;
                        break;
                    }
                case CrafterState.ReadyToCraft: //If crafting table has both items
                    {
                        playerWalkingSpeedMemory = playerPickUpItem.playerObject.GetComponent<PlayerMovement>().playerWalkingSpeed;
                        playerPickUpItem.playerObject.GetComponent<PlayerMovement>().playerWalkingSpeed = 0;
                        crafterState = CrafterState.Crafting;
                        StartCoroutine(CraftingCoroutine());
                        break;
                    }
            }
    }

    private void PlaceItemIntoCrafting(GameObject heldItemReference, int itemSlotIndex)
    {
        Debug.Log(heldItemReference);
        placedMaterialsList.Add(heldItemReference);
        heldItemReference.layer = 0; //Make the item no longer pickupable
        heldItemReference.transform.position = materialSlotList[itemSlotIndex].transform.position; //Tp the item to its slot
        heldItemReference.transform.SetParent(materialSlotList[itemSlotIndex].transform); //Make the slot the parent of the item
        playerPickUpItem.areHandsFull = false; //Variable which makes the player object think it holds no item
        Debug.Log("Placed to craft: " + playerPickUpItem.heldItem.name);
        playerPickUpItem.heldItem = null; //Clear out the object reference to the input item
    }

    IEnumerator CraftingCoroutine()
    {
        yield return new WaitForSeconds(timeToCraft);
        ItemTypes.ItemType firstCraftingMaterial = placedMaterialsList[0].GetComponent<ItemBaseScript>().itemType;
        if (firstCraftingMaterial == ItemTypes.ItemType.Flower)
        {
            instantiatedItem = Instantiate(bouquetPrefab, instantiateSlot.transform);
        }
        else if (firstCraftingMaterial == ItemTypes.ItemType.Ribbon || firstCraftingMaterial == ItemTypes.ItemType.Bouquet)
        {
            instantiatedItem = Instantiate(bouquetRibbonPrefab, instantiateSlot.transform);
        }
        playerPickUpItem.playerObject.GetComponent<PlayerMovement>().playerWalkingSpeed = playerWalkingSpeedMemory;
        instantiatedItem.transform.SetParent(instantiateSlot.transform);
        Debug.Log("Spawned: " + instantiatedItem.name);

        ClearCraftingTableInventory();
        crafterState = CrafterState.ReadyForAny;
    }

    private void ClearCraftingTableInventory()
    {
        foreach (var materialItem in placedMaterialsList)
        {
            Destroy(materialItem.gameObject);
        }
        placedMaterialsList.Clear();
    }
}
