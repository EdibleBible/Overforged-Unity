using UnityEngine;
using TMPro;

public class ForgeShippingController : MonoBehaviour //Handles increasing the UI bouquet counter
{
    [SerializeField] private ItemTypes.ItemType itemTypeOfThisDisplay;

    private void OnEnable() //When the score increase event is called this object picks it up and starts the IncreaseScore function
    {
        LevelProgressionController.LevelProgressionIncreaseEvent += IncreaseScore;
    }

    private void OnDisable() //Lmao nie wiem xD
    {
        LevelProgressionController.LevelProgressionIncreaseEvent -= IncreaseScore;
    }

    private void IncreaseScore(PlaySessionData playSessionData) //Function called by another script
    {
        if (playSessionData.productsShippedDict.ContainsKey(itemTypeOfThisDisplay))
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = playSessionData.productsShippedDict[itemTypeOfThisDisplay].ToString();
        }
    }
}