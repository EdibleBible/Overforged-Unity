using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgeCraftingTable : MonoBehaviour
{
    enum CrafterState { ReadyForItems, ReadyToCraft, Crafting, ReadyToPickUp };
    CrafterState crafterState = CrafterState.ReadyForItems;
    private GameObject playerTrigger;
    private PlayerPickUpItem playerPickUpItem;
    private GameObject stickObjectReference;
    private GameObject toolHeadObjectReference;
    [SerializeField] private GameObject stickSlot;
    [SerializeField] private GameObject toolHeadSlot;
    [SerializeField] private float timeToCraft = 1f;
    private float playerWalkingSpeedMemory;

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
        if (Input.GetKeyDown(KeyCode.E) && playerTrigger != null) //When player presses E key and both colliders collide
        {
            switch (crafterState) //Check for what state the crafting table is in
            {
                case CrafterState.ReadyForItems: //If crafting table is ready to have items placed for crafting
                    {
                        if (playerPickUpItem.heldItem != null) //If the player is holding an item
                        {
                            ItemTypes.ItemType heldItemType = playerPickUpItem.heldItem.GetComponent<ItemBaseScript>().itemType; //Save the held item type to variable
                            if (heldItemType == ItemTypes.ItemType.Stick && stickObjectReference == null)
                            {
                                PlaceItemIntoCrafting(stickObjectReference, stickSlot, toolHeadObjectReference);
                            } 
                            else if ((heldItemType == ItemTypes.ItemType.IronAxeHead || heldItemType == ItemTypes.ItemType.IronPickHead) && toolHeadObjectReference == null)
                            {
                                PlaceItemIntoCrafting(toolHeadObjectReference, toolHeadSlot, stickObjectReference);
                            }
                        }
                        break;
                    }
                case CrafterState.ReadyToCraft: //If crafting table has both items
                    {
                        playerWalkingSpeedMemory = playerPickUpItem.playerObject.GetComponent<PlayerMovement>().playerWalkingSpeed;
                        playerPickUpItem.playerObject.GetComponent<PlayerMovement>().playerWalkingSpeed = 0;
                        StartCoroutine(DelayedExecution(playerPickUpItem, dummyBouquet, playerObject));
                        break;
                    }
            }
        } 
    }

    private void PlaceItemIntoCrafting(GameObject heldItemReference, GameObject itemSlot, GameObject otherItemReference)
    {
        heldItemReference = playerPickUpItem.heldItem; //Save the input item into the variable
        heldItemReference.layer = 0; //Make the item no longer pickupable
        heldItemReference.transform.position = itemSlot.transform.position; //Tp the item to its slot
        heldItemReference.transform.SetParent(itemSlot.transform); //Make the slot the parent of the item
        playerPickUpItem.areHandsFull = false; //Variable which makes the player object think it holds no item
        Debug.Log("Placed to craft: " + playerPickUpItem.heldItem.name);
        playerPickUpItem.heldItem = null; //Clear out the object reference to the input item
        if (otherItemReference != null) //If the other item is also in the crafting table - set the state of crafting into ready to craft
        {
            crafterState = CrafterState.ReadyToCraft;
        }
    }

    IEnumerator CraftingCoroutine()
    {
        yield return new WaitForSeconds(timeToCraft);
        playerPickUpItem.playerObject.GetComponent<PlayerMovement>().playerWalkingSpeed = playerWalkingSpeedMemory;

        dummyBouquet.SetActive(false);
        foreach (GameObject item in craftingStationInventory)
        {
            if (item.GetComponent<ItemBaseScript>().itemType == ItemTypes.ItemType.Ribbon)
            {
                ribbonIn = true;
                break;
            }
        }
        if (ribbonIn)
        {
            heldItem = Instantiate(itemBouquetRibbon, this.transform);
            ribbonIn = false;
        }
        else
        {
            heldItem = Instantiate(itemBouquet, this.transform);
        }

        smokeParticles.Play();

        foreach (GameObject item in craftingStationInventory)
        {
            itemScript = item.GetComponent<ItemBaseScript>();
            totalValue += itemScript.itemValue;
        }
        itemScript = heldItem.GetComponent<ItemBaseScript>();
        itemScript.itemValue = totalValue;
        playerPickUpItem.heldItem = heldItem;
        heldItem.transform.SetParent(playerPickUpItem.gameObject.transform);
        heldItem.transform.position = this.transform.position;
        playerPickUpItem.areHandsFull = true;
        Debug.Log("Picked up: " + heldItem.name);
        craftingStationInventory.Clear();

    }

    private void ClearCraftingTableInventory()
    {
        Destroy(stickObjectReference);
        Destroy(toolHeadObjectReference);
        stickObjectReference = null;
        toolHeadObjectReference = null;
    }
}
