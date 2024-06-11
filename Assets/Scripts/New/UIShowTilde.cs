using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShowTilde : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            object1.SetActive(true);
            object2.SetActive(true);
            object3.SetActive(true);
        }
    }
}
