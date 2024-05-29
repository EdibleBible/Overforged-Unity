using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpItem : MonoBehaviour //Plz rewrite
{
    internal Player PlayerRef;
    [SerializeField] private GameObject itemInRange; //Item that collides with the player collider
    private GameObject slotInRange; //Item slot that collider with player collider
    public GameObject heldItem; //Reference to the item that is being held by the player
    [SerializeField] private GameObject heldItemSlot; //GameObject where the player has the item that is held
    [SerializeField] public bool areHandsFull; //Protection check to make sure only one item is held

    internal KeyCode PickupItemKey { get; set; }
    internal KeyCode PutDownItemKey { get; set; }
    private void OnTriggerExit(Collider other) //Clears the variables below when leaving a collider
    {
        if (other.CompareTag("Item"))
        {
            itemInRange = null;
        }
        if (other.CompareTag("Slot"))
        {
            slotInRange = null;
        }
    }

    void OnTriggerEnter(Collider other) //Assigns the GameObject colliding with the player's collider to the proper type of variable
    {
        if (other.CompareTag("Item"))
        {
            itemInRange = other.gameObject;
        }
        if (other.CompareTag("Slot"))
        {
            slotInRange = other.gameObject;
        }
    }

    void Update()
    {
        // Check if the player is pressing the Q key & an item is in range & no item is held
        if (Input.GetKeyDown(PickupItemKey) && itemInRange != null && !areHandsFull)
        {
            PickUpItem(itemInRange);
        }

        // Check if the player is pressing the E key & a slot is in range & an item is held
        if (Input.GetKeyDown(PutDownItemKey) && heldItem != null && slotInRange != null && areHandsFull)
        {
            PutDownItem();
        }
    }

    public void PickUpItem(GameObject item)
    {
        if (areHandsFull) return; // dont pickup if hands are full...
        // Disable the collider of the item
        Collider itemCollider = item.GetComponent<Collider>();
        if (itemCollider != null)
        {
            itemCollider.enabled = false;
        }

        // Disable gravity for the item's Rigidbody
        Rigidbody itemRigidbody = item.GetComponent<Rigidbody>();
        if (itemRigidbody != null)
        {
            itemRigidbody.useGravity = false;
        }

        heldItem = item; //References the held item GameObject to this variable for later use
        item.transform.SetParent(this.gameObject.transform); //Sets the parent of the held item GameObject to be the player
        item.transform.position = this.transform.position; //Teleports the picked up item to the player item slot
        areHandsFull = true;
        Debug.Log("Picked up: " + item.name);
    }

    void DropItem()
    {
        // Enable the collider of the item
        Collider itemCollider = heldItem.GetComponent<Collider>();
        if (itemCollider != null)
        {
            itemCollider.enabled = true;
        }

        // Enable gravity for the item's Rigidbody
        Rigidbody itemRigidbody = heldItem.GetComponent<Rigidbody>();
        if (itemRigidbody != null)
        {
            itemRigidbody.useGravity = true;
        }

        heldItem.transform.SetParent(null); //The player is no longer the parent of the dropped item
        areHandsFull = false;
        Debug.Log("Dropped: " + heldItem.name);
        heldItem = null; //Removes the reference to the previously held item
    }

    void PutDownItem()
    {
        // Enable the collider of the item
        Collider itemCollider = heldItem.GetComponent<Collider>();
        if (itemCollider != null)
        {
            itemCollider.enabled = true;
        }

        // Enable gravity for the item's Rigidbody
        Rigidbody itemRigidbody = heldItem.GetComponent<Rigidbody>();
        if (itemRigidbody != null)
        {
            itemRigidbody.useGravity = true;
        }

        heldItem.transform.SetParent(slotInRange.transform); //Sets the parent of the held item GameObject to be the slot of the object the item is placed on
        heldItem.transform.position = slotInRange.transform.position; //Teleports the picked up item to the object item slot
        heldItem.transform.rotation = new Quaternion(0,0,0,0); //Resets item rotation
        areHandsFull = false;
        Debug.Log("Put down: " + heldItem.name);
        heldItem = null; //Removes the reference to the previously held item
    }
}
