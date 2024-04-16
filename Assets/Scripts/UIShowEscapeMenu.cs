using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShowEscapeMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu; //Escape menu overlay parent object
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            menu.SetActive(true); //Enables the menu object
            Time.timeScale = 0f; //Stops the game clock
        }
    }

    public void CloseMenu()
    {
        menu.SetActive(false); //Disables the menu object
        Time.timeScale = 1f; //Resumes the game clock
    }
}
