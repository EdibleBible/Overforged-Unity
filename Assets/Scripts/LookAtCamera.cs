using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    void Update()
    {
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            transform.LookAt(mainCamera.transform);
        }
        else
        {
            Debug.LogWarning("Main camera not found.");
        }
    }
}
