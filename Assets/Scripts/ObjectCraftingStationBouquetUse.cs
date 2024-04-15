using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCraftingStationBouquetUse : MonoBehaviour
{
    private GameObject playerTrigger;
    [SerializeField] private GameObject itemInitializer;
    [SerializeField] private GameObject dummyBouquet;
    private ItemCraftingBouquet itemCraftingBouquet;
    [SerializeField] private PlayerPickUpItem playerPickUpItem;
    [SerializeField] private ParticleSystem flowerParticles;

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

    private void Start()
    {
        itemCraftingBouquet = itemInitializer.GetComponent<ItemCraftingBouquet>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerTrigger != null)
        {
            ItemTypes.ItemType heldItemType = ItemTypes.ItemType.Flower;
            if (playerPickUpItem.areHandsFull == true)
            {
                heldItemType = playerPickUpItem.heldItem.GetComponent<ItemBaseScript>().itemType;
            }
            if (itemCraftingBouquet.craftingStationInventory.Count < 3 && heldItemType == ItemTypes.ItemType.Flower || heldItemType == ItemTypes.ItemType.Ribbon)
            {
                flowerParticles.Play();
                dummyBouquet.SetActive(true);
                itemCraftingBouquet.AddItemToInventory(playerPickUpItem.heldItem);
                playerPickUpItem.heldItem.SetActive(false);
                playerPickUpItem.heldItem.transform.SetParent(itemCraftingBouquet.gameObject.transform);
                playerPickUpItem.areHandsFull = false;
                Debug.Log("Placed to craft: " + playerPickUpItem.heldItem.name);
                playerPickUpItem.heldItem = null;
            }
            else if (itemCraftingBouquet.craftingStationInventory.Count == 3 && playerPickUpItem.areHandsFull == false)
            {
                flowerParticles.Play();
                itemCraftingBouquet.BeginCrafting(playerPickUpItem, dummyBouquet, playerPickUpItem.playerObject);
            }

            playerPickUpItem.heldItem = null;
            playerPickUpItem.areHandsFull = false;
        }
    }
}
