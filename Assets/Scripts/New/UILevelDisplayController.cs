using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OverForged.GameProgress;

public class UILevelDisplayController : MonoBehaviour
{
    public GameObject Flower1Order;
    public GameObject Flower2Order;
    public GameObject Flower3Order;
    public GameObject Forge1Order;
    public GameObject Forge2Order;
    public GameObject Forge3Order;

    private void Awake()
    {
        Level orderLevel = SOGameProgress.currentLevel;
        switch (orderLevel)
        {
            case Level.Flower1:
            {
                Flower1Order.SetActive(true);
                break;
            }
            case Level.Flower2:
            {
                Flower2Order.SetActive(true);
                break;
                }
            case Level.Flower3:
                {
                    Flower3Order.SetActive(true);
                    break;
                }
            case Level.Forge1:
                {
                    Forge1Order.SetActive(true);
                    break;
                }
            case Level.Forge2:
                {
                    Forge2Order.SetActive(true);
                    break;
                }
            case Level.Forge3:
                {
                    Forge3Order.SetActive(true);
                    break;
                }
        }
    }
}
