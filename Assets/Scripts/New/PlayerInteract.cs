using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Transform detectionBox;
    public Vector3 boxSize = new(0.1f, 1, 1);  // Size of the detection box
    public LayerMask interactWithItem;  // LayerMask to filter the detected objects when the player holds an item
    public LayerMask interactWithNoItem;  // LayerMask to filter the detected objects when the player holds an item
    public LayerMask useItemWithItem;  // LayerMask to filter the detected objects when the player holds an item
    public LayerMask useItemWithNoItem;  // LayerMask to filter the detected objects when the player holds an item
    private float closestObjectDistance;  //Distance between the detection box center & the closest point of the closest detected object
    private Collider closestCollider;  //Collider of the closest object
    private GameObject closestGameObject;
    public Transform slot;  //Transform of the empty where a picked up item teleports
    public GameObject itemObject;  //Game object of the item that is held by the player
    public PlayerMovement movement;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) //Whenever E key is pressed
        {
            closestGameObject = DetectInteractives(KeyCode.E);
            closestGameObject.GetComponent<IPlayerInteractive>()?.PlayerInteract(this, GetItemScript()); //Interact with the GameObject
        }
        else if (Input.GetKeyDown(KeyCode.Q)) //Whenever Q key is pressed
        {
            closestGameObject = DetectInteractives(KeyCode.Q);
            if (closestGameObject == gameObject && itemObject)
            {
                itemObject.GetComponent<IPlayerItem>().PlayerItemInteraction(this, GetItemScript()); //Interact with the GameObject
            } else
            {
                closestGameObject.GetComponent<IPlayerItem>()?.PlayerItemInteraction(this, GetItemScript()); //Interact with the GameObject
            }
        }
    }

    private GameObject DetectInteractives(KeyCode keyCode) //Detects the closest GameObject which can be interacted with
    {
        LayerMask detectionLayer = new();
        switch (keyCode) {
            case KeyCode.E:
                if (itemObject)
                {
                    detectionLayer = interactWithItem;
                } else
                {
                    detectionLayer = interactWithNoItem;
                }
                break;
            case KeyCode.Q:
                if (itemObject)
                {
                    detectionLayer = useItemWithItem;
                }
                else
                {
                    detectionLayer = useItemWithNoItem;
                }
                break;
        }
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

    public ItemBaseScript GetItemInfo()
    {
        return itemObject.GetComponent<ItemBaseScript>();
    }

    public ItemInteract GetItemScript()
    {
        if (itemObject == null) return null;
        return itemObject.GetComponent<ItemInteract>();
    }

    public bool HasItem()
    {
        if (itemObject)
        {
            return true;
        }
        return false;
    }

    public void Forget()
    {
        itemObject = null;
    }

    public void SetItem(ItemInteract item)
    {
        itemObject = item.gameObject;
    }

    public void SetItem(GameObject item)
    {
        itemObject = item;
    }

    public ItemTypes.ItemType GetItemType()
    {
        return GetItemScript().info.itemType;
    }

    public bool IsItemOfType(ItemTypes.ItemType typeToCheck)
    {
        if (itemObject != null && GetItemType() == typeToCheck)
        {
            return true;
        }
        return false;
    }

    public int GetItemValue()
    {
        return itemObject.GetComponent<ItemBaseScript>().itemValue;
    }

    public PlayerMovement ReturnPlayerMovementScript()
    {
        return gameObject.GetComponent<PlayerMovement>();
    }
}
