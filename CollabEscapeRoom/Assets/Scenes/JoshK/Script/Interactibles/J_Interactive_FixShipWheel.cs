using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Interactive_FixShipWheel : J_InteractiveObject
{
    [Header("Replacement Object")]
    public GameObject ReplacementWheel;

    private bool firstInteraction = true;
    
    public override void ExecuteInteractiveAction()
    {
        if (firstInteraction) { J_DialogueManager.Manager.Dialogue("Damn! It's broken, gonna need to find a replacement.", null); firstInteraction = false; Tooltip = " Replace"; return; }

        if (J_InventoryManager.TheInventory.CurrentInventoryIndex < J_InventoryManager.TheInventory.Items.Count)
        {
            if (J_InventoryManager.TheInventory.Items[J_InventoryManager.TheInventory.CurrentInventoryIndex].Name == "Ship Wheel")
            {
                J_AudioManager.GlobalSFXManager.PlaySFX(J_AudioManager.GlobalSFXManager.ItemSound, null);
                ReplacementWheel.SetActive(true);
                gameObject.SetActive(false);
                J_InventoryManager.TheInventory.RemoveItem("Ship Wheel");
                J_UIManager.TheUI.TooltipMessage("Wheel Fixed!", 1f);
            }
            else
            {
                J_UIManager.TheUI.TooltipMessage("Incorrect item.", 2f);
            }
        }
        else
        {
            J_UIManager.TheUI.TooltipMessage("You have no item equiped.", 2f);
        }
    }
}
