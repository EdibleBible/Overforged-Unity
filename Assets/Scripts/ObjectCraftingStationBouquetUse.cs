using UnityEngine;

public class ObjectCraftingStationBouquetUse : MonoBehaviour
{
    private GameObject playerTrigger; //Player item slot object
    [SerializeField] private GameObject itemInitializer; //Other script which also handles crafting
    private ItemCraftingBouquet itemCraftingBouquet; //Component of the above variable
    [SerializeField] private GameObject dummyBouquet; //Dummy bouquet object that shows up when crafting
    [SerializeField] private PlayerPickUpItem playerPickUpItem; //Component of the player object which holds information about the held item
    [SerializeField] private ParticleSystem flowerParticles; //Particles which show up when adding a new item to the crafting process

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
            playerPickUpItem = playerTrigger.GetComponent<PlayerPickUpItem>(); //Lmao idk
        }
    }

    private void Start()
    {
        itemCraftingBouquet = itemInitializer.GetComponent<ItemCraftingBouquet>();
    }

    private void Update()
    {
        if (!playerPickUpItem) return;
        // If player presses E and holds an object and either holds a bouquet or holds a bouquet with ribbon
        if (Input.GetKeyDown(playerPickUpItem.PlayerRef.GetInput(e_PlayerInput.Use_Action)) && playerTrigger != null) //If the player presses E and holds an item
        {
            ItemTypes.ItemType heldItemType = ItemTypes.ItemType.Flower; //Declares the heldItemType variable & assigns Flower as the default value so that the code can compile
            if (playerPickUpItem.areHandsFull == true) //If the player holds an item its type is assigned to the heldItemType variable
            {
                heldItemType = playerPickUpItem.heldItem.GetComponent<ItemBaseScript>().itemType;
            }
            // If there are less than 3 items inside the crafting station & the players holds an item of Flower or Ribbon type
            if (itemCraftingBouquet.craftingStationInventory.Count < 3 && heldItemType == ItemTypes.ItemType.Flower || heldItemType == ItemTypes.ItemType.Ribbon)
            {
                flowerParticles.Play();
                dummyBouquet.SetActive(true); //Shows the dummy bouquet object
                itemCraftingBouquet.AddItemToInventory(playerPickUpItem.heldItem); //Runs a function which adds a reference in the crafting station memory to the item that is held by the player
                playerPickUpItem.heldItem.SetActive(false); //Disables the item that is held to remove it without destroying it
                playerPickUpItem.heldItem.transform.SetParent(itemCraftingBouquet.gameObject.transform); //Frees the held item from its parent
                playerPickUpItem.areHandsFull = false; //Makes the player object believe it no longer holds an item
                Debug.Log("Placed to craft: " + playerPickUpItem.heldItem.name);
                playerPickUpItem.heldItem = null; //Makes the player object believe it no longer holds an item
            }
            else if (itemCraftingBouquet.craftingStationInventory.Count == 3 && playerPickUpItem.areHandsFull == false) //If the crafting station already has 3 items & the player has empty hands
            {
                flowerParticles.Play();
                itemCraftingBouquet.BeginCrafting(playerPickUpItem, dummyBouquet); //Runs the function inside the other script which handles crafting
            }

            playerPickUpItem.heldItem = null;
            playerPickUpItem.areHandsFull = false;
        }
    }
}
