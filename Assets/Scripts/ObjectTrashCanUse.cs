using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrashCanUse : MonoBehaviour
{
    [SerializeField] private GameObject playerTrigger;

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
            Destroy(playerTrigger.transform.GetChild(0).gameObject);

            PlayerPickUpItem playerPickUpItem = playerTrigger.GetComponent<PlayerPickUpItem>();
            playerPickUpItem.heldItem = null;
            playerPickUpItem.areHandsFull = false;
        }
    }
}
