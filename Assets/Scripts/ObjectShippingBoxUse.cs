using UnityEngine;

public class ObjectShippingBoxUse : MonoBehaviour
{
    private GameObject playerTrigger; //Player item slot object
    private int levelScore; //Local variable holding the current amount of points
    [SerializeField] private CurrentLevelInfo currentLevelInfo; // SO that holds the information about the current level progress
    public delegate void LevelScoreIncreaseHandler(int levelScore, bool ribbon); //Declares a new event to be passed to the UI element that shows the current level score and amount of shipped bouquets
    public static event LevelScoreIncreaseHandler LevelScoreIncreaseEvent; //Declares a new variable based on the event above

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerTrigger"))
        {
            playerTrigger = null;
        }
    }

    void OnTriggerEnter(Collider other) //When player collides with this collider the player item slot is assigned to this variable
    {
        if (other.CompareTag("PlayerTrigger"))
        {
            playerTrigger = other.gameObject;
        }
    }

    private void Update()
    {
        // If player presses E and holds an object and either holds a bouquet or holds a bouquet with ribbon
        if ( Input.GetKeyDown(KeyCode.E) && playerTrigger != null && playerTrigger.transform.childCount > 0 && (playerTrigger.transform.GetChild(0).gameObject.GetComponent<ItemBaseScript>().itemType == ItemTypes.ItemType.Bouquet || playerTrigger.transform.GetChild(0).gameObject.GetComponent<ItemBaseScript>().itemType == ItemTypes.ItemType.BouquetRibbon))
        {
            if (playerTrigger.transform.GetChild(0).gameObject.GetComponent<ItemBaseScript>().itemType == ItemTypes.ItemType.Bouquet) // If player holds a bouquet
            {
                levelScore += playerTrigger.transform.GetChild(0).gameObject.GetComponent<ItemBaseScript>().itemValue; // Level score variable is increased inside the SO
                currentLevelInfo.bouquetsShipped++; // Amount of shipped bouquets is increased inside the SO
                LevelScoreIncreaseEvent?.Invoke(levelScore, false); //Invokes the event which increases the score inside the UI
            } else if (playerTrigger.transform.GetChild(0).gameObject.GetComponent<ItemBaseScript>().itemType == ItemTypes.ItemType.BouquetRibbon) // If player holds a bouquet with ribbon
            {
                levelScore += ((int)(playerTrigger.transform.GetChild(0).gameObject.GetComponent<ItemBaseScript>().itemValue * 1.5)); // Level score variable is increased inside the SO
                currentLevelInfo.bouquetsShippedRibbon++; // Amount of shipped bouquets with ribbon is increased inside the SO
                LevelScoreIncreaseEvent?.Invoke(levelScore, true); //Invokes the event which increases the score inside the UI
            }

            Destroy(playerTrigger.transform.GetChild(0).gameObject); //Destroys the item held by the player

            PlayerPickUpItem playerPickUpItem = playerTrigger.GetComponent<PlayerPickUpItem>();  //References the script that handles the player information about the held item
            playerPickUpItem.heldItem = null;
            playerPickUpItem.areHandsFull = false;
        }
    }
}
