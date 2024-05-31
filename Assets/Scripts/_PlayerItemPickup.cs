using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerItemPickup : MonoBehaviour
{
    public Vector3 boxSize = new Vector3(0.1f, 1, 1);  // Size of the detection box
    public LayerMask detectionLayerHoldsItem;  // LayerMask to filter the detected objects when the player holds an item
    public LayerMask detectionLayerHoldsNoItem;  // LayerMask to filter the detected objects when the player doesn't hold any item
    private float closestObjectDistance;  //Distance between the detection box center & the closest point of the closest detected object
    private Collider closestCollider;  //Collider of the closest object
    public Transform playerItemSlot;  //Transform of the empty where a picked up item teleports
    public GameObject heldItem;  //Game object of the item that is held by the player

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) //Whenever Q key is pressed
        {
            if (heldItem == null)  //If the player holds no item
            {
                DetectInteractives(detectionLayerHoldsNoItem);  //Start scanning for items to pick up or objects to interact with
            } else //If the player holds any item
            {
                DetectInteractives(detectionLayerHoldsItem);  //Start scanning for slots to place items in or objects to interact with
            }
            closestCollider.gameObject.GetComponent<IPlayerInteractive>().PlayerInteract(this); //Interact with the GameObject
        }
    }

    private void DetectInteractives(LayerMask detectionLayer) //Detects the closest GameObject which can be interacted with
    {
        Vector3 triggerCenter = transform.position; //Gets the center position of this object
        Collider[] hitColliders = Physics.OverlapBox(triggerCenter, boxSize / 2, gameObject.transform.rotation, detectionLayer); //Makes a list of all colliders which hit this object
        float distance = Vector3.Distance(hitColliders[0].ClosestPoint(this.transform.position), triggerCenter); //Saves the distance to the first collider
        closestCollider = hitColliders[0]; //Saves a reference to the first collider
        foreach (Collider collider in hitColliders) //Loops through the list of detected colliders
        {
            distance = Vector3.Distance(collider.ClosestPoint(this.transform.position), triggerCenter); //Saves the distance to this collider
            if (distance < closestObjectDistance) //If this collider is closer than the previous closest collider
            {
                distance = closestObjectDistance; //Replaces the reference to the closest collider distance
                closestCollider = collider; //Replaces the reference to the closest collider
            }
        }
    }
}
