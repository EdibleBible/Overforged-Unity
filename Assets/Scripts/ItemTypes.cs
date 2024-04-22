using UnityEngine;

[CreateAssetMenu(fileName = "ItemTypes", menuName = "ScriptableObjects/ItemTypes")]
public class ItemTypes : ScriptableObject //This SO allows items to have a variable of type ItemType so they can be differentiated by picking an element of a list in the Inspector
{
    public enum ItemType //List of all possible types of items in the game
    {
        Flower,
        Bouquet,
        Ribbon,
        BouquetRibbon,
        Stick,
        IronOre,
        IronIngot,
        IronAxeHead,
        IronPickHead,
        IronAxe,
        IronPick
    }
}
