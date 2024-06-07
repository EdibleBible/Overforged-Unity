using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrafterSlotInteract : MonoBehaviour, IPlayerInteractive, IPlayerItem
{
    public List<SlotInteract> slotScriptList = new();
    public GameObject stuckObject = null;
    private PlayerInteract latestPlayer;

    public void PlayerInteract(PlayerInteract playerScript)
    {
        if (stuckObject && !stuckObject.GetComponent<ItemInteract>().isRecipe())
        {
            stuckObject.GetComponent<ItemMove>().PickUpItem(playerScript);
            stuckObject = null;
            gameObject.layer = 7;
            return;
        }

        latestPlayer = playerScript;
        if (stuckObject == null && latestPlayer.heldItem != null)
        {
            stuckObject = gameObject.GetComponent<IRecipeInitializer>().InitializeRecipe(latestPlayer, gameObject);
            stuckObject.GetComponent<IItemRecipe>().RecipeInteract(latestPlayer, this);
        } else if (stuckObject)
        {
            stuckObject.GetComponent<IItemRecipe>().RecipeInteract(latestPlayer, this);
        }
    }

    public void PlayerItemInteraction(PlayerInteract playerScript)
    {
        if (playerScript.heldItem)
        {
            if (stuckObject == null && playerScript.heldItem.GetComponent<ItemInteract>().isRecipe())
            {
                stuckObject.GetComponent<ItemMove>().PlaceItem(playerScript, this, transform);
            }
        } else
        {
            if (stuckObject)
            {
                stuckObject.GetComponent<ItemMove>().PickUpItem(playerScript);
                stuckObject = null;
                gameObject.layer = 7;
            }
        }
    }


    public void Craft(GameObject prefab, float timeInterval, int value)
    {
        StartCoroutine(WaitToCraft(timeInterval));
        latestPlayer.ReturnPlayerMovementScript().PlayerCanMove(false);
        gameObject.layer = 0;
        Destroy(stuckObject);
        stuckObject = Instantiate(prefab, gameObject.transform);
        stuckObject.SetActive(false);
        stuckObject.GetComponent<ItemMove>().DisableItem(true);
        stuckObject.GetComponent<ItemBaseScript>().itemValue = value;
    }

    IEnumerator WaitToCraft(float time)
    {
        yield return new WaitForSeconds(time);
        FinishCrafting();
    }

    void FinishCrafting()
    {
        latestPlayer.ReturnPlayerMovementScript().PlayerCanMove(true);
        gameObject.layer = 9;
        stuckObject.SetActive(true);
    }
}
