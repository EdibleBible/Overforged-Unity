using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectStorageBoxInteraction : MonoBehaviour
{
    [SerializeField] private GameObject playerTrigger;
    [SerializeField] private List<GameObject> storageBoxItemList = new List<GameObject>();
    private GameObject storageBoxItem;

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
        if (Input.GetKeyDown(KeyCode.E) && playerTrigger != null)
        {
            storageBoxItem = storageBoxItemList[Random.Range(0, storageBoxItemList.Count)];

            GameObject heldItem = Instantiate(storageBoxItem, this.transform);
            Collider itemCollider = heldItem.GetComponent<Collider>();
            if (itemCollider != null)
            {
                itemCollider.enabled = false;
            }
            Rigidbody itemRigidbody = heldItem.GetComponent<Rigidbody>();
            if (itemRigidbody != null)
            {
                itemRigidbody.useGravity = false;
            }

            heldItem.transform.SetParent(playerTrigger.transform);
            heldItem.transform.position = playerTrigger.transform.position;

            PlayerPickUpItem playerPickUpItem = playerTrigger.GetComponent<PlayerPickUpItem>();
            playerPickUpItem.heldItem = heldItem;
            Debug.Log(playerPickUpItem.heldItem);
            playerPickUpItem.areHandsFull = true;
        }
    }
}
