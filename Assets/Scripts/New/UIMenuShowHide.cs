using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuShowHide : MonoBehaviour
{
    public GameObject menu;
    public void Show()
    {
        menu.SetActive(true);
    }

    public void Hide()
    {
        menu.SetActive(false);
    }
}
