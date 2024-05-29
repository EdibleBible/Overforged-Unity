using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCraftingBouquet : MonoBehaviour
{
    public List<GameObject> craftingStationInventory; //References to the GameObjects of the items placed inside the Crafting Station
    public List<GameObject> flowerIconSlots; //Icons assigned to the items placed inside the Crafting Station
    [SerializeField] private float timeToCraft; //Time between pressing the E button and a bouquet appearing inside the player item slot
    public GameObject itemBouquet; //Bouquet object reference
    public GameObject itemBouquetRibbon; //Ribbon bouquet object reference
    public int totalValue; //Value of the bouquet calculated from the item used to craft it
    private ItemBaseScript itemScript; //Component of an item object
    private GameObject heldItem; //Bouquet the player will hold after crafting
    private bool ribbonIn; //Bool variable used when calculating the bonus for using a Ribbon in crafting
    [SerializeField] private ParticleSystem smokeParticles;


    public void AddItemToInventory(GameObject itemToAdd) //Function called from the other crafting script
    {
        craftingStationInventory.Add(itemToAdd); //Adds a reference to the item placed inside the Crafting Station to the list of items inside
        flowerIconSlots[(craftingStationInventory.Count)-1].GetComponent<SpriteRenderer>().sprite = itemToAdd.GetComponent<ItemBaseScript>().itemIcon; //Grabs the icon of the item and adds it to the list of item icons
    }

    public void BeginCrafting(PlayerPickUpItem playerPickUpItem, GameObject dummyBouquet) //Function called from the other crafting script
    {
        StartCoroutine(DelayedExecution(playerPickUpItem, dummyBouquet)); //Calls the coroutine that finishes crafting after time passes (from timeToCraft variable)
        foreach (var icon in flowerIconSlots) //Clears the list of item icons
        {
            icon.GetComponent<SpriteRenderer>().sprite = null;
        }
    }

    IEnumerator DelayedExecution(PlayerPickUpItem playerPickUpItem, GameObject dummyBouquet)
    {
        yield return new WaitForSeconds(timeToCraft); //Time specified in timeToCraft has to pass before the function resumes

        dummyBouquet.SetActive(false); //Dummy bouquet object is disabled
        foreach (GameObject item in craftingStationInventory) //Loops through the list of items and checks to see if there is a ribbon
        {
            if (item.GetComponent<ItemBaseScript>().itemType == ItemTypes.ItemType.Ribbon)
            {
                ribbonIn = true;
                break;
            }
        }
        if (ribbonIn) //If there is a ribbon, a Ribbon Bouquet is created, else a Bouquet is created
        {
            heldItem = Instantiate(itemBouquetRibbon, this.transform);
            ribbonIn = false;
        } else
        {
            heldItem = Instantiate(itemBouquet, this.transform);
        }

        smokeParticles.Play();

        foreach (GameObject item in craftingStationInventory) //Increases the value of the bouquet for every item placed inside the Crafting Station
        {
            itemScript = item.GetComponent<ItemBaseScript>();
            totalValue += itemScript.itemValue;
        }
        itemScript = heldItem.GetComponent<ItemBaseScript>(); //Assigns the itemScript variable to be the component containing the info of the new Bouquet
        itemScript.itemValue = totalValue; //Sets the value of the Bouquet to be the totalValue calculated above
        playerPickUpItem.heldItem = heldItem; //Assigns the heldItem variable of the player to be the Bouquet
        heldItem.transform.SetParent(playerPickUpItem.gameObject.transform); //Assigns the player to be the parent of the Bouquet
        heldItem.transform.position = this.transform.position; //Teleports the Bouquet to the player item slot
        playerPickUpItem.areHandsFull = true;
        Debug.Log("Picked up: " + heldItem.name);
        craftingStationInventory.Clear(); //Clears the list of object references of the Crafting Station

    }
}
