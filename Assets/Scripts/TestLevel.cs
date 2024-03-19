using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestLevel : MonoBehaviour //Teleports the player to the Test Level scene when pressing Delete in the Main Menu
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            SceneManager.LoadScene("Scenes/TestLevel");
        }
    }
}
