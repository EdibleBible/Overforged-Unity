using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OverForged.GameProgress;

[CreateAssetMenu(fileName = "SOGameProgress", menuName = "ScriptableObjects/GameProgress")]

public class SOGameProgress : ScriptableObject
{
    public int unlockedLevel;
    public static Level latestLevel = Level.Flower1;
    public static int currentScore;
    public static Level currentLevel;
}
