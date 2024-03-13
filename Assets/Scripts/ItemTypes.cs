using UnityEngine;

[CreateAssetMenu(fileName = "ItemTypes", menuName = "ScriptableObjects/ItemTypes")]
public class ItemTypes : ScriptableObject
{
    public enum ItemType
    {
        Flower,
        Bouquet,
        Ribbon,
        BouquetRibbon
    }
}
