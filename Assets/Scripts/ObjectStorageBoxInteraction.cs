using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectStorageBoxInteraction : MonoBehaviour
{
    [SerializeField] private GameObject playerTrigger; //Player item slot collider object
    [SerializeField] private List<GameObject> storageBoxItemList = new List<GameObject>(); //List of items this storage box can output (assigned in the Inspector)
    private GameObject storageBoxItem; //Item this storage box will output to the player

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
        if (Input.GetKeyDown(KeyCode.E) && playerTrigger != null && !playerTrigger.GetComponent<PlayerPickUpItem>().areHandsFull)
        {
            storageBoxItem = storageBoxItemList[Random.Range(0, storageBoxItemList.Count)]; //Randomly picks an item from the list of available items assigned in Inspector

            GameObject heldItem = Instantiate(storageBoxItem, this.transform); //Instantiates a new object - the item
            Collider itemCollider = heldItem.GetComponent<Collider>(); //Collider component of the new item object
            if (itemCollider != null) //Disables the collider of the item
            {
                itemCollider.enabled = false;
            }
            Rigidbody itemRigidbody = heldItem.GetComponent<Rigidbody>();
            if (itemRigidbody != null) //Disables the gravity of the item
            {
                itemRigidbody.useGravity = false;
            }

            heldItem.transform.SetParent(playerTrigger.transform); //Sets the parent of the item object to be the player item slot object
            heldItem.transform.position = playerTrigger.transform.position; //Sets the position of the item object to be the player item slot object position

            PlayerPickUpItem playerPickUpItem = playerTrigger.GetComponent<PlayerPickUpItem>(); //Referencs the script that handles the player holding an item
            playerPickUpItem.heldItem = heldItem; //The player is informed what item they are holding now
            Debug.Log(playerPickUpItem.heldItem);
            playerPickUpItem.areHandsFull = true; //The player is informed their hands are holding an item
        }
    }
}
