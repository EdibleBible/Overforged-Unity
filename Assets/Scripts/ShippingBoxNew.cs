using System.Collections.Generic;
using UnityEngine;

public class ShippingBoxNew : MonoBehaviour
{
    private GameObject playerTrigger; //Player item slot object
    [SerializeField] private CurrentLevelInfo currentLevelInfo; // SO that holds the information about the current level progress
    [SerializeField] private List<ItemTypes.ItemType> acceptedProductTypes;
    [SerializeField] private LevelProgressionController levelProgressionController;

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
            GameObject heldItem = playerTrigger.GetComponent<PlayerPickUpItem>().heldItem;
            ItemTypes.ItemType heldItemType = heldItem.GetComponent<ItemBaseScript>().itemType;
            if (acceptedProductTypes.Contains(heldItemType))
            {
                levelProgressionController.AddScoreAndMarkOrder(heldItemType, heldItem.GetComponent<ItemBaseScript>().itemValue);

                Destroy(heldItem); 
                playerTrigger.GetComponent<PlayerPickUpItem>().heldItem = null;
                playerTrigger.GetComponent<PlayerPickUpItem>().areHandsFull = false;
            }
        }

        
    }
}
