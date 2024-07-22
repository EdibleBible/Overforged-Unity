using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonHideNextLevelForLast : MonoBehaviour
{
    public SOGameProgress progress;
    private void OnEnable()
    {
        if (progress.latestLevel == OverForged.GameProgress.Level.Forge3)
        {
            gameObject.SetActive(false);
        }
    }
}
