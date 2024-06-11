using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OverForged.GameProgress;

public class UIHideForProgress : MonoBehaviour
{
    [SerializeField] private int level;
    private void OnEnable()
    {
        if (level > (int)SOGameProgress.latestLevel)
        {
            gameObject.SetActive(false);
        }
    }
}
