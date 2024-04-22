using System.Collections.Generic;
using UnityEngine;
using static ItemTypes;

public class ShippingBoxNew : MonoBehaviour
{
    private GameObject playerTrigger; //Player item slot object
    [SerializeField] private CurrentLevelInfo currentLevelInfo; // SO that holds the information about the current level progress
    [SerializeField] private List<ItemType> acceptedProductTypes;
    [SerializeField] private LevelProgressionController levelProgressionController;
    private GameObject itemToShip;
    private ItemType itemType;

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerTrigger"))
        {
            playerTrigger = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerTrigger"))
        {
            playerTrigger = other.gameObject;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerTrigger != null && playerTrigger.GetComponent<PlayerPickUpItem>().heldItem != null)
        {
            GameObject itemToShip = playerTrigger.GetComponent<PlayerPickUpItem>().heldItem;
            itemType = itemToShip.GetComponent<ItemBaseScript>().itemType;
            if (acceptedProductTypes.Contains(itemType))
            {
                levelProgressionController.AddScoreAndMarkOrder(itemType, itemToShip.GetComponent<ItemBaseScript>().itemValue);

                Destroy(itemToShip); 
                playerTrigger.GetComponent<PlayerPickUpItem>().heldItem = null;
                playerTrigger.GetComponent<PlayerPickUpItem>().areHandsFull = false;
            }
        }

        
    }
}
