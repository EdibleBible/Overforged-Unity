using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonHideNextLevelForLast : MonoBehaviour
{
    private void OnEnable()
    {
        if (SOGameProgress.latestLevel == OverForged.GameProgress.Level.Forge3)
        {
            gameObject.SetActive(false);
        }
    }
}
