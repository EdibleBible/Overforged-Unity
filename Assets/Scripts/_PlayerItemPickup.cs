using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerItemPickup : MonoBehaviour
{
    public Vector3 boxSize = new Vector3(0.1f, 1, 1);  // Adjust the size of the box
    public LayerMask detectionLayer;  // LayerMask to filter the detected objects
    private float closestObjectDistance;
    private Collider closestCollider;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 triggerCenter = transform.position;
            Collider[] hitColliders = Physics.OverlapBox(triggerCenter, boxSize / 2, Quaternion.identity, detectionLayer);
            float distance = Vector3.Distance(hitColliders[0].ClosestPoint(this.transform.position), triggerCenter);
            foreach (Collider collider in hitColliders)
            {
                distance = Vector3.Distance(collider.ClosestPoint(this.transform.position), triggerCenter);
                if (distance <= closestObjectDistance)
                {
                    distance = closestObjectDistance;
                    closestCollider = collider;
                }
                Debug.Log("Detected object: " + closestCollider.name);
            }
        }
    }
}
