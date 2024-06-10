using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrafterSlotInteract : MonoBehaviour, IPlayerInteractive, IPlayerItem
{
    public GameObject stuckObject = null;
    private ItemInteract stuckObjectScript = null;
    private PlayerInteract latestPlayer;

    public void PlayerInteract(PlayerInteract player, ItemInteract item)
    {
        /*if (stuckObject && !stuckObject.GetComponent<ItemInteract>().isRecipe())
        {
            stuckObject.GetComponent<ItemMove>().PickUpItem(player);
            stuckObject = null;
            gameObject.layer = 7;
            return;
        }*/
        latestPlayer = player;
        if (stuckObject == null && latestPlayer.HasItem())
        {
            if (item.IsRecipe())
            {
                item.Place(player, this, transform);
            } else
            {
                stuckObjectScript = gameObject.GetComponent<IRecipeInitializer>().InitializeRecipe(item, gameObject);
                stuckObject = stuckObjectScript.gameObject;
            }
            if (stuckObject)
            {
                stuckObject.GetComponent<IItemRecipe>().RecipeInteract(latestPlayer, item, this);
            }
        } else if (stuckObject)
        {
            stuckObject.GetComponent<IItemRecipe>().RecipeInteract(latestPlayer, item, this);
        }
    }

    public void PlayerItemInteraction(PlayerInteract player, ItemInteract item)
    {
        if (player.HasItem())
        {
            if (stuckObject == null && item.IsRecipe())
            {
                item.Place(player, this, transform);
            }
        } else
        {
            if (stuckObject)
            {
                stuckObjectScript.PickUp(player); 
                stuckObject = null;
                gameObject.layer = 7;
            }
        }
    }


    public void Craft(GameObject prefab, float timeInterval, int value)
    {
        StartCoroutine(WaitToCraft(timeInterval));
        latestPlayer.movement.PlayerCanMove(false);
        gameObject.layer = 0;
        Destroy(stuckObject);
        stuckObject = Instantiate(prefab, gameObject.transform);
        stuckObjectScript = stuckObject.GetComponent<ItemInteract>();
        stuckObject.SetActive(false);
        stuckObjectScript.DisableItem(true);
        stuckObjectScript.SetValue(value);
    }

    public void Craft(List<GameObject> prefabList, float timeInterval, int value)
    {
        GameObject prefab = prefabList[Random.Range(0, prefabList.Count)];
        Craft(prefab, timeInterval, value);
    }

    IEnumerator WaitToCraft(float time)
    {
        yield return new WaitForSeconds(time);
        FinishCrafting();
    }

    void FinishCrafting()
    {
        latestPlayer.movement.PlayerCanMove(true);
        gameObject.layer = 9;
        stuckObject.SetActive(true);
    }

    public void SetItem(GameObject item)
    {
        stuckObject = item;
    }

    public void SetItem(ItemInteract item)
    {
        stuckObject = item.gameObject;
    }

    public void Forget()
    {
        stuckObject = null;
    }
}
