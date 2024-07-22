using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Spawner : MonoBehaviour
{
    public SOGameProgress progress;
    public List<GameObject> skinPrefabs = new();
    private void OnEnable()
    {
        if (progress.toggleMultiplayer)
        {
            Instantiate(skinPrefabs[(int)progress.player2Skin], transform);
        }
    }
}
