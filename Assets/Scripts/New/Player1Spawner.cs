using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Spawner : MonoBehaviour
{
    public SOGameProgress progress;
    public List<GameObject> skinPrefabs = new();
    private void OnEnable()
    {
        Instantiate(skinPrefabs[(int)progress.player1Skin], transform);
    }
}
