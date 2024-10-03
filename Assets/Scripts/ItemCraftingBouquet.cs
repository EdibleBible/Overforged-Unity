
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private float playerWalkingSpeedMemory;

    [SerializeField] private Image timerImage;


    public void AddItemToInventory(GameObject heldItem)
    {
        craftingStationInventory.Add(heldItem);
        flowerIconSlots[(craftingStationInventory.Count)-1].GetComponent<SpriteRenderer>().sprite = heldItem.GetComponent<ItemBaseScript>().itemIcon;
    }

    public void BeginCrafting(PlayerPickUpItem playerPickUpItem, GameObject dummyBouquet, GameObject playerObject)
    {
        playerWalkingSpeedMemory = playerObject.GetComponent<PlayerMovement>().playerWalkingSpeed;
        playerObject.GetComponent<PlayerMovement>().playerWalkingSpeed = 0;
        StartCoroutine(DelayedExecution(playerPickUpItem, dummyBouquet, playerObject));
        foreach (var icon in flowerIconSlots)
        {
            icon.GetComponent<SpriteRenderer>().sprite = null;
        }
    }

    IEnumerator DelayedExecution(PlayerPickUpItem playerPickUpItem, GameObject dummyBouquet, GameObject playerObject)
    {
        StartCoroutine(CountDownAnimation(timeToCraft));

        yield return new WaitForSeconds(timeToCraft);
        playerObject.GetComponent<PlayerMovement>().playerWalkingSpeed = playerWalkingSpeedMemory;

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


    IEnumerator CountDownAnimation(float time)
    {
        float animationTime = 0;
        print("DUPA");
        timerImage.fillAmount = 0;
        while (timerImage.fillAmount < 1)
        {
            animationTime += Time.deltaTime;
            timerImage.fillAmount = animationTime / time;
            yield return null;

        }
    }
}

