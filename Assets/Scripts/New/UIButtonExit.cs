using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonExit : MonoBehaviour
{
    public static void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
