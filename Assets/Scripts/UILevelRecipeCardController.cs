using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILevelRecipeCardController : MonoBehaviour
{
    public GameObject recipeCard;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote) && Time.timeScale != 0f)
        {
            recipeCard.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.BackQuote))
        {
            recipeCard.SetActive(false);
        }
    }
}
