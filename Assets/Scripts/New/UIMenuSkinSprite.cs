using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static OverForged.GameProgress;

public class UIMenuSkinSprite : MonoBehaviour
{
    public int skinInt;
    public Image sprite;
    private void OnEnable()
    {
        if (!SOGameProgress.skinUnlocked[skinInt])
        {
            sprite.color = Color.black;
        }
    }
}
