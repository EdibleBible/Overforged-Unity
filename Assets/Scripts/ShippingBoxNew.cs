using System.Collections.Generic;
using UnityEngine;

public class ShippingBoxNew : MonoBehaviour
{
    private GameObject playerTrigger; //Player item slot object
    [SerializeField] private CurrentLevelInfo currentLevelInfo; // SO that holds the information about the current level progress
    public delegate void LevelScoreIncreaseHandlerNew(); //Declares a new event to be passed to the UI element that shows the current level score and amount of shipped bouquets
    public static event LevelScoreIncreaseHandlerNew LevelScoreIncreaseEventNew; //Declares a new variable based on the event above
    [SerializeField] private List<ItemTypes.ItemType> acceptedProductTypes;

    private void Start()
    {
        currentLevelInfo.currentLevelScore = 0;
        currentLevelInfo.productsShippedDict.Clear();
    }

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
        if (Input.GetKeyDown(KeyCode.E) && playerTrigger.GetComponent<PlayerPickUpItem>().heldItem != null)
        {
            GameObject heldItem = playerTrigger.GetComponent<PlayerPickUpItem>().heldItem;
            ItemTypes.ItemType heldItemType = heldItem.GetComponent<ItemBaseScript>().itemType;
            if (acceptedProductTypes.Contains(heldItemType))
            {
                currentLevelInfo.IncreaseShippedProductCount(heldItemType);
                currentLevelInfo.currentLevelScore += heldItem.GetComponent<ItemBaseScript>().itemValue;
                LevelScoreIncreaseEventNew?.Invoke();

                Destroy(heldItem); 
                playerTrigger.GetComponent<PlayerPickUpItem>().heldItem = null;
                playerTrigger.GetComponent<PlayerPickUpItem>().areHandsFull = false;
            }
        }

        
    }
}
