using OverForged;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OverForged.GameProgress;

public class UILevelGet : MonoBehaviour
{
    public Level currentLevel;
    void Awake()
    {
        currentLevel = GetLevel();
    }
}
