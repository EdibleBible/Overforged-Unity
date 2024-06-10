using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Spawner : MonoBehaviour
{
    public List<GameObject> skinPrefabs = new();
    private void OnEnable()
    {
        Instantiate(skinPrefabs[(int)SOGameProgress.player1Skin], transform);
    }
}
