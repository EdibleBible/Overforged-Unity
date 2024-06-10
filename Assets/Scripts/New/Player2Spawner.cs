using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Spawner : MonoBehaviour
{
    public List<GameObject> skinPrefabs = new();
    private void OnEnable()
    {
        if (SOGameProgress.toggleMultiplayer)
        {
            Instantiate(skinPrefabs[(int)SOGameProgress.player2Skin], transform);
        }
    }
}
