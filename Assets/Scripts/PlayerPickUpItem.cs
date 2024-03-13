using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpItem : MonoBehaviour
{
    [SerializeField] private GameObject itemInRange; //Item that collides with the player collider
    private GameObject slotInRange; //Item slot that collider with player collider
    public GameObject heldItem; //Reference to the item that is being held by the player
    [SerializeField] private GameObject heldItemSlot; //
    [SerializeField] public bool areHandsFull;
    [SerializeField] private GameObject storageBoxItem;

    private void OnTriggerExit(Collider other)
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

    void OnTriggerEnter(Collider other)
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
        // Check if the player is pressing the Q key and an item is in range
        if (Input.GetKeyDown(KeyCode.Q) && itemInRange != null && !areHandsFull)
        {
            PickUpItem(itemInRange);
        }
        //else if (Input.GetKeyDown(KeyCode.Q) && heldItem != null && areHandsFull)
        //{
        //    DropItem();
        //}

        if (Input.GetKeyDown(KeyCode.E) && heldItem != null && slotInRange != null && areHandsFull)
        {
            PutDownItem();
        }
    }

    public void PickUpItem(GameObject item)
    {
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

        heldItem = item;
        item.transform.SetParent(this.gameObject.transform);
        item.transform.position = this.transform.position;
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

        heldItem.transform.SetParent(null);
        areHandsFull = false;
        Debug.Log("Dropped: " + heldItem.name);
        heldItem = null;
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

        heldItem.transform.SetParent(slotInRange.transform);
        heldItem.transform.position = slotInRange.transform.position;
        heldItem.transform.rotation = new Quaternion(0,0,0,0);
        areHandsFull = false;
        Debug.Log("Put down: " + heldItem.name);
        heldItem = null;
    }
}
