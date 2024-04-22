using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgeAnvil : MonoBehaviour
{
    enum CrafterState { ReadyForItems, ReadyToCraft, Crafting, ReadyToPickUp };
    CrafterState crafterState = CrafterState.ReadyForItems;
    [SerializeField] private GameObject inputSlot;
    [SerializeField] private GameObject instantiateSlot;
    [SerializeField] private float timeToCraft = 5f;
    [SerializeField] private List<GameObject> instantiateObjectPrefabList = new List<GameObject>();
    private GameObject inputObjectReference;
    private GameObject instantiatedObjectReference;

    private GameObject playerTrigger;
    private PlayerPickUpItem playerPickUpItem;

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
                        if (playerPickUpItem.heldItem != null && playerPickUpItem.heldItem.GetComponent<ItemBaseScript>().itemType == ItemTypes.ItemType.IronIngot) //If the player is holding an item
                        {
                            inputObjectReference = playerPickUpItem.heldItem;
                            Debug.Log(inputObjectReference);
                            inputObjectReference.layer = 0; //Make the item no longer pickupable
                            inputObjectReference.transform.position = inputSlot.transform.position; //Tp the item to its slot
                            inputObjectReference.transform.SetParent(inputSlot.transform); //Make the slot the parent of the item
                            playerPickUpItem.areHandsFull = false; //Variable which makes the player object think it holds no item
                            Debug.Log("Placed to craft: " + playerPickUpItem.heldItem.name);
                            playerPickUpItem.heldItem = null; //Clear out the object reference to the input item
                            crafterState = CrafterState.ReadyToCraft;
                        }
                        break;
                    }
                case CrafterState.ReadyToCraft: //If crafting table has an item
                    {
                        playerPickUpItem.PlayerCanMove(false);
                        StartCoroutine(CraftingCoroutine());
                        break;
                    }
            }
        }
    }

    IEnumerator CraftingCoroutine()
    {
        crafterState = CrafterState.Crafting;
        yield return new WaitForSeconds(timeToCraft);
        playerPickUpItem.PlayerCanMove(true);
        GameObject instantiatedObjectPrefab = instantiateObjectPrefabList[Random.Range(0, instantiateObjectPrefabList.Count)];
        instantiatedObjectReference = Instantiate(instantiatedObjectPrefab, instantiateSlot.transform);
        Debug.Log("Spawned: " + instantiatedObjectReference.name);

        ClearCraftingTableInventory();
        crafterState = CrafterState.ReadyForItems;
    }

    private void ClearCraftingTableInventory()
    {
        Destroy(inputObjectReference);
        inputObjectReference = null;

    }
}
