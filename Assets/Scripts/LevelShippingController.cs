using UnityEngine;
using TMPro;

public class LevelShippingController : MonoBehaviour //Handles increasing the UI bouquet counter
{
    private int bouquetsShipped = 0; //Default value that is shown on the UI display
    [SerializeField] bool isRibbon; //True if the UI display this script is attached to handles Ribbon Bouquets
    public TextMeshProUGUI text; //TMP component of the UI display

    private void OnEnable() //When the score increase event is called this object picks it up and starts the IncreaseScore function
    {
        ObjectShippingBoxUse.LevelScoreIncreaseEvent += IncreaseScore;
    }

    private void OnDisable() //Lmao nie wiem xD
    {
        ObjectShippingBoxUse.LevelScoreIncreaseEvent -= IncreaseScore;
    }

    private void IncreaseScore(int levelScore, bool ribbon) //Function called by another script which contains score to add (discarded here) and whether the shipped item has a ribbon
    {
        if (isRibbon == ribbon) //If the UI display is for the same type of bouquet as the bouquet that was just shipped
        {
            bouquetsShipped++;
            text = GetComponent<TextMeshProUGUI>();
            text.text = bouquetsShipped.ToString(); //UI display TMP component is updated with the new amount of shipped products
        }
    }
}