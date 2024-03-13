using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShowEscapeMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            menu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void CloseMenu()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
    }
}
