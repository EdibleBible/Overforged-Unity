using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrafterSlotInteract : MonoBehaviour, IPlayerInteractive
{
    public List<SlotInteract> slotScriptList = new();
    private GameObject craftedRecipeObject = null;

    public void PlayerInteract(PlayerInteract playerScript)
    {
        if (craftedRecipeObject == null && playerScript.heldItem != null)
        {
            if (AreSlotsEmpty())
            {
                craftedRecipeObject = gameObject.GetComponent<IRecipeInitializer>().InitializeRecipe(playerScript, gameObject);
            }
            craftedRecipeObject.GetComponent<IItemRecipe>().RecipeInteract(playerScript);
        } else
        {
            craftedRecipeObject.GetComponent<IItemRecipe>().RecipeInteract(playerScript);
        }
    }

    public bool AreSlotsEmpty()
    {
        foreach (SlotInteract slotScript in slotScriptList)
        {
            if (slotScript.stuckItem != null) { return false; }
        }
        foreach (SlotInteract slotScript in slotScriptList)
        {
            slotScript.DisableSlot(true);
        }
        return true;
    }
}
