
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpItem : MonoBehaviour
{
    private GameObject slotInRange; //Item slot that collider with player collider
    public GameObject heldItem; //Reference to the item that is being held by the player
    [SerializeField] private GameObject heldItemSlot; //
    [SerializeField] public bool areHandsFull;
    [SerializeField] private GameObject storageBoxItem;
    [SerializeField] public PlayerMovement playerMovement;
    public GameObject playerObject;
    public float pickupRange = 1f;
    public LayerMask pickupLayers;

    void Update()
    {
        // Check if the player is pressing the Q key and an item is in range
        if (Input.GetKeyDown(KeyCode.Q) && !areHandsFull)
        {
            PickUpItem();
        }
        else if (Input.GetKeyDown(KeyCode.Q) && heldItem != null && areHandsFull)
        {
            DropItem();
        }

/*        if (Input.GetKeyDown(KeyCode.E) && heldItem != null && slotInRange != null && areHandsFull)
        {
            PutDownItem();
        }*/
    }

    public void PickUpItem()
    {
        Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, pickupRange, pickupLayers);
        if (nearbyColliders.Length > 0)
        {
            // Disable the collider of the item
        Collider itemCollider = nearbyColliders[0];
        if (itemCollider != null)
        {
            itemCollider.enabled = false;
        }

        // Disable gravity for the item's Rigidbody
        Rigidbody itemRigidbody = itemCollider.GetComponent<Rigidbody>();
        if (itemRigidbody != null)
        {
            itemRigidbody.useGravity = false;
            itemRigidbody.isKinematic = true;
        }

        heldItem = itemCollider.gameObject;
            itemCollider.transform.SetParent(this.gameObject.transform);
            itemCollider.transform.position = this.transform.position;
        areHandsFull = true;
        Debug.Log("Picked up: " + itemCollider.name);
        }

       
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
            itemRigidbody.isKinematic = false;
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

    public void PlayerCanMove(bool canMove)
    {
        playerMovement.PlayerCanMove(canMove);
    }

    public bool IsHeldItemType(ItemTypes.ItemType typeToCompare)
    {
        if (ReturnHeldItemType() == typeToCompare)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public ItemTypes.ItemType ReturnHeldItemType()
    {
<<<<<<< HEAD
        if (heldItem != null)
        {
            return heldItem.GetComponent<ItemBaseScript>().itemType;
        }
        return ItemTypes.ItemType.None;
=======
        return heldItem.GetComponent<ItemBaseScript>().itemType;
>>>>>>> feabb03 (Flower crafting done)
    }

}

