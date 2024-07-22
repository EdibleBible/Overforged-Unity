using UnityEngine;
using GameEnums;

public class ItemBaseScript : MonoBehaviour //List of variables for an item object
{
    public ItemType itemType; //Allows to pick the type of the item in the Inspector
    public int itemValue; //Value increases the score
    public Sprite itemIcon; //Item icon that is passed to the Crafting Station to show what item is inside it
}
