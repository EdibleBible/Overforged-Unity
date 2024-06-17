using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrafterSlotInteract : MonoBehaviour, IInteractEEmpty, IInteractEItem, IInteractQEmpty, IInteractQItem, IInteract
{
    public GameObject stuckObject = null;
    private ItemInteract stuckObjectScript = null;
    private PlayerInteract latestPlayer;
    public GameObject clockObject;
    public UIIconClock clock;

    public bool InteractCheck(PlayerInteract player, ItemInteract item)
    {
        throw new System.NotImplementedException();
    }

    public bool InteractEEmpty(PlayerInteract player)
    {
        latestPlayer = player;
        if (stuckObject)
        {
            if (stuckObjectScript.IsRecipe())
            {
                stuckObject.GetComponent<IItemRecipe>().RecipeInteract(latestPlayer, null, this);
                return true;
            }
            stuckObjectScript.PickUp(player);
            stuckObject = null;
            return true;
        }
        return false;
    }

    public bool InteractEItem(PlayerInteract player, ItemInteract item)
    {
        latestPlayer = player;
        if (stuckObject == null)
        { 
            if (item.IsRecipe())
            {
                item.Place(player, this, transform);
                return true;
            }
            else
            {
                stuckObjectScript = gameObject.GetComponent<IRecipeInitializer>().InitializeRecipe(item, gameObject);
                stuckObject = stuckObjectScript.gameObject;
                return true;
            }
        }
        stuckObject.GetComponent<IItemRecipe>().RecipeInteract(latestPlayer, item, this);
        return false;
    }

    public bool InteractQEmpty(PlayerInteract player)
    {
        if (stuckObject)
        {
            stuckObjectScript.PickUp(player);
            stuckObject = null;
            return true;
        }
        return false;
    }

    public bool InteractQItem(PlayerInteract player, ItemInteract item)
    {
        if (stuckObject == null && item.IsRecipe())
        {
            item.Place(player, this, transform);
            return true;
        }
        return false;
    }

    public void Craft(GameObject prefab, float timeInterval, int value)
    {
        clockObject.SetActive(true);
        clock.Craft(timeInterval);
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
        gameObject.layer = 19;
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
