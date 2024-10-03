using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CurrentLevelInfo", menuName = "ScriptableObjects/CurrentLevelInfo")]
public class CurrentLevelInfo : ScriptableObject //Holds the information about the current level or game play session
{
    public int currentLevelScore;
    public int currentLevel;
    public int bouquetsShipped;
    public int bouquetsShippedRibbon;
    public int ironAxeShipped;
    public int ironPickShipped;
    public bool levelTwoUnlocked; // Radek powiedzia³, ¿e do wyjebania
    public bool levelTwoFinished; // to te¿
    public Dictionary<ItemTypes.ItemType, int> productsShippedDict = new Dictionary<ItemTypes.ItemType, int>();

    // bazowe info o lvl

    public void IncreaseShippedProductCount(ItemTypes.ItemType itemType)
    {
        Debug.Log(productsShippedDict);
        if (!productsShippedDict.ContainsKey(itemType))
        {
            productsShippedDict.Add(itemType, 0);
        }
        productsShippedDict[itemType]++;
    }

}
