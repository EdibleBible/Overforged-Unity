using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngineInternal;

public class PickAndDrop : MonoBehaviour
{
    public float pickupRange = 0.1f;
    public LayerMask pickupLayers;

    private bool holdingItem = false;
    private GameObject heldItem = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (holdingItem)
            {
                DropItem();
            }
            else
            {
                PickUpItem();
            }
        }
    }

    private void PickUpItem()
    {
        Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, pickupRange, pickupLayers);
        if (nearbyColliders.Length > 0)
        {
            heldItem = nearbyColliders[0].gameObject;
            heldItem.transform.SetParent(transform);
            heldItem.transform.localPosition = new Vector3(0, 0.5f, 1);
            heldItem.GetComponent<Rigidbody>().isKinematic = true;
            heldItem.GetComponent<BoxCollider>().enabled = false;
            holdingItem = true;
        }
    }

    private void DropItem()
    {
        heldItem.transform.SetParent(null);
        heldItem.GetComponent<BoxCollider>().enabled = true;
        heldItem.GetComponent<Rigidbody>().isKinematic = false;
        heldItem = null;
        holdingItem = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickupRange);
    }
}
