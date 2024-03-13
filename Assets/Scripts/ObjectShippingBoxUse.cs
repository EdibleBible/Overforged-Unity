using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectShippingBoxUse : MonoBehaviour
{
    private GameObject playerTrigger;
    [SerializeField] private LevelScoreScript levelScoreScript;
    [SerializeField] private TextMeshProUGUI levelScoreTMP;
    private TextMeshProUGUI text;
    private int levelScore;
    [SerializeField] private CurrentLevelInfo currentLevelInfo;
    public delegate void LevelScoreIncreaseHandler(int levelScore, bool ribbon);
    public static event LevelScoreIncreaseHandler LevelScoreIncreaseEvent;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerTrigger"))
        {
            playerTrigger = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerTrigger"))
        {
            playerTrigger = other.gameObject;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerTrigger != null && (playerTrigger.transform.GetChild(0).gameObject.GetComponent<ItemBaseScript>().itemType == ItemTypes.ItemType.Bouquet || playerTrigger.transform.GetChild(0).gameObject.GetComponent<ItemBaseScript>().itemType == ItemTypes.ItemType.BouquetRibbon))
        {
            if (playerTrigger.transform.GetChild(0).gameObject.GetComponent<ItemBaseScript>().itemType == ItemTypes.ItemType.Bouquet)
            {
                levelScore += playerTrigger.transform.GetChild(0).gameObject.GetComponent<ItemBaseScript>().itemValue;
                currentLevelInfo.bouquetsShipped++;
                LevelScoreIncreaseEvent?.Invoke(levelScore, false);
            } else if (playerTrigger.transform.GetChild(0).gameObject.GetComponent<ItemBaseScript>().itemType == ItemTypes.ItemType.BouquetRibbon)
            {
                levelScore += (((int)(playerTrigger.transform.GetChild(0).gameObject.GetComponent<ItemBaseScript>().itemValue * 1.5)));
                currentLevelInfo.bouquetsShippedRibbon++;
                LevelScoreIncreaseEvent?.Invoke(levelScore, true);
            }

            Destroy(playerTrigger.transform.GetChild(0).gameObject);

            PlayerPickUpItem playerPickUpItem = playerTrigger.GetComponent<PlayerPickUpItem>();
            playerPickUpItem.heldItem = null;
            playerPickUpItem.areHandsFull = false;
        }
    }
}
