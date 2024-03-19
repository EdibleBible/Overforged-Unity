using UnityEngine;

[CreateAssetMenu(fileName = "CurrentLevelInfo", menuName = "ScriptableObjects/CurrentLevelInfo")]
public class CurrentLevelInfo : ScriptableObject //Holds the information about the current level or game play session
{
    public int currentLevelScore;
    public int currentLevel;
    public int bouquetsShipped;
    public int bouquetsShippedRibbon;
    public bool levelTwoUnlocked;
    public bool levelTwoFinished;
}
