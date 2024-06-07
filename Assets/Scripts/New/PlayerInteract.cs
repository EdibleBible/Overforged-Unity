using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Transform detectionBox;
    public Vector3 boxSize = new Vector3(0.1f, 1, 1);  // Size of the detection box
    public LayerMask interactWithItem;  // LayerMask to filter the detected objects when the player holds an item
    public LayerMask interactWithNoItem;  // LayerMask to filter the detected objects when the player holds an item
    public LayerMask useItemWithItem;  // LayerMask to filter the detected objects when the player holds an item
    public LayerMask useItemWithNoItem;  // LayerMask to filter the detected objects when the player holds an item
    private float closestObjectDistance;  //Distance between the detection box center & the closest point of the closest detected object
    private Collider closestCollider;  //Collider of the closest object
    private GameObject closestGameObject;
    public Transform playerItemSlot;  //Transform of the empty where a picked up item teleports
    public GameObject heldItem;  //Game object of the item that is held by the player

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) //Whenever E key is pressed
        {
            if (heldItem == null)  //If the player holds no item
            {
                closestGameObject = DetectInteractives(interactWithNoItem);  //Start scanning for items to pick up or objects to interact with
            } else //If the player holds any item
            {
                closestGameObject = DetectInteractives(interactWithItem);  //Start scanning for slots to place items in or objects to interact with
            }
            closestGameObject.GetComponent<IPlayerInteractive>()?.PlayerInteract(this); //Interact with the GameObject
        }
        else if (Input.GetKeyDown(KeyCode.Q)) //Whenever Q key is pressed
        {
            if (heldItem == null)  //If the player holds no item
            {
                closestGameObject = DetectInteractives(useItemWithNoItem);  //Start scanning for items to pick up or objects to interact with
                closestGameObject.GetComponent<IPlayerItem>()?.PlayerItemInteraction(this); //Interact with the GameObject
            } else
            {
                closestGameObject = DetectInteractives(useItemWithItem);  //Start scanning for slots to place items in
                if (closestGameObject == gameObject) //If there's not slot to interact with
                {
                    heldItem.GetComponent<IPlayerItem>().PlayerItemInteraction(this); //Interact with the GameObject
                } else
                {
                    closestGameObject.GetComponent<IPlayerItem>()?.PlayerItemInteraction(this); //Interact with the GameObject
                }
            }
        }
    }

    private GameObject DetectInteractives(LayerMask detectionLayer) //Detects the closest GameObject which can be interacted with
    {
        Vector3 triggerCenter = detectionBox.position; //Gets the center position of this object
        Collider[] hitColliders = Physics.OverlapBox(triggerCenter, boxSize / 2, gameObject.transform.rotation, detectionLayer); //Makes a list of all colliders which hit this object
        if (hitColliders.Length == 0) { closestCollider = null; return gameObject; };
        float distance = Vector3.Distance(hitColliders[0].ClosestPoint(detectionBox.position), triggerCenter); //Saves the distance to the first collider
        closestCollider = hitColliders[0]; //Saves a reference to the first collider
        foreach (Collider collider in hitColliders) //Loops through the list of detected colliders
        {
            distance = Vector3.Distance(collider.ClosestPoint(detectionBox.position), triggerCenter); //Saves the distance to this collider
            if (distance < closestObjectDistance) //If this collider is closer than the previous closest collider
            {
                distance = closestObjectDistance; //Replaces the reference to the closest collider distance
                closestCollider = collider; //Replaces the reference to the closest collider
            }
        }
        return closestCollider.gameObject;
    }

    public ItemMove ReturnItemMovementScript()
    {
        return heldItem.GetComponent<ItemMove>();
    }

    public ItemTypes.ItemType GetItemType()
    {
        return heldItem.GetComponent<ItemBaseScript>().itemType;
    }

    public bool IsItemOfType(ItemTypes.ItemType typeToCheck)
    {
        if (heldItem != null && GetItemType() == typeToCheck)
        {
            return true;
        }
        return false;
    }

    public bool HoldsItem()
    {
        if (heldItem == null)
        {
            return false;
        }
        return true;
    }

    public int GetItemValue()
    {
        return heldItem.GetComponent<ItemBaseScript>().itemValue;
    }

    public PlayerMovement ReturnPlayerMovementScript()
    {
        return gameObject.GetComponent<PlayerMovement>();
    }
}
