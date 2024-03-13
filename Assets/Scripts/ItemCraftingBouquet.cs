using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCraftingBouquet : MonoBehaviour
{
    public List<GameObject> craftingStationInventory;
    public List<GameObject> flowerIconSlots;
    [SerializeField] private float timeToCraft;
    public GameObject itemBouquet;
    public GameObject itemBouquetRibbon;
    public int totalValue;
    private ItemBaseScript itemScript;
    private GameObject heldItem;
    private bool ribbonIn;
    [SerializeField] private ParticleSystem smokeParticles;


    public void AddItemToInventory(GameObject heldItem)
    {
        craftingStationInventory.Add(heldItem);
        flowerIconSlots[(craftingStationInventory.Count)-1].GetComponent<SpriteRenderer>().sprite = heldItem.GetComponent<ItemBaseScript>().itemIcon;
    }

    public void BeginCrafting(PlayerPickUpItem playerPickUpItem, GameObject dummyBouquet)
    {
        StartCoroutine(DelayedExecution(playerPickUpItem, dummyBouquet));
        foreach (var icon in flowerIconSlots)
        {
            icon.GetComponent<SpriteRenderer>().sprite = null;
        }
    }

    IEnumerator DelayedExecution(PlayerPickUpItem playerPickUpItem, GameObject dummyBouquet)
    {
        yield return new WaitForSeconds(timeToCraft);

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
        } else
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
}
