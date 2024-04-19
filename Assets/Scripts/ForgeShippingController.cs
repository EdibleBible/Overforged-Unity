using UnityEngine;
using TMPro;

public class ForgeShippingController : MonoBehaviour //Handles increasing the UI bouquet counter
{
    [SerializeField] private ItemTypes.ItemType itemTypeOfThisDisplay;
    [SerializeField] CurrentLevelInfo currentLevelInfo;

    private void OnEnable() //When the score increase event is called this object picks it up and starts the IncreaseScore function
    {
        ShippingBoxNew.LevelScoreIncreaseEventNew += IncreaseScore;
    }

    private void OnDisable() //Lmao nie wiem xD
    {
        ShippingBoxNew.LevelScoreIncreaseEventNew -= IncreaseScore;
    }

    private void IncreaseScore() //Function called by another script
    {
        if (currentLevelInfo.productsShippedDict.ContainsKey(itemTypeOfThisDisplay))
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = currentLevelInfo.productsShippedDict[itemTypeOfThisDisplay].ToString();
        }
    }
}