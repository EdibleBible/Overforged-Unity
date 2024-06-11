using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuShowSkinSprite : MonoBehaviour
{
    public List<Sprite> sprites = new();
    public Image image;
    public int playerNo;
    private void OnEnable()
    {
        if (playerNo == 1)
        {
            image.sprite = sprites[(int)SOGameProgress.player1Skin];
        } else if (playerNo == 2)
        {
            image.sprite = sprites[(int)SOGameProgress.player2Skin];
        }
    }
}
