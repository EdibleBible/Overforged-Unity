using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOSettings", menuName = "ScriptableObjects/Settings")]

public class SOSettings : ScriptableObject
{
    public float audioVolume = 1;
    public int latestSaveFile = 1;
}
