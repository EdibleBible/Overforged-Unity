using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static OverForged.GameProgress;

public class UITextScore : MonoBehaviour
{
    public TMP_Text text;
    private void Awake()
    {
        text.text = "Score: " + GetScore().ToString();
    }
}
