using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OverForged.GameProgress;

public class UIHideForProgress : MonoBehaviour
{
    public SOGameProgress progress;
    [SerializeField] private int level;
    private void OnEnable()
    {
        if (level > (int)progress.latestLevel)
        {
            gameObject.SetActive(false);
        }
    }
}
