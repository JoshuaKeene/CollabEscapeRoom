using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Interactive_TreasureDig : J_InteractiveObject
{
    [Header("Treasure Variables")]
    public GameObject ShipWheel;

    private static bool firstInteraction = true;

    public override void ExecuteInteractiveAction()
    {
        if (J_InventoryManager.TheInventory.CurrentInventoryIndex < J_InventoryManager.TheInventory.Items.Count)
        {
            if (J_InventoryManager.TheInventory.Items[J_InventoryManager.TheInventory.CurrentInventoryIndex].Name == "Shovel")
            {
                J_AudioManager.GlobalSFXManager.PlaySFX(J_AudioManager.GlobalSFXManager.DigSand, null);
                ShipWheel.GetComponent<Animator>().Play(J_AnimationManager.Dig_ShipWheel);
                gameObject.GetComponent<SphereCollider>().enabled = false;
                StartCoroutine("WaitForDig");
            }
            else
            {
                J_UIManager.TheUI.TooltipMessage("You can't use that to dig.", 2f);
                if (firstInteraction) { J_DialogueManager.Manager.Dialogue("I need a shovel...", null); firstInteraction = false; }
            }
        }
        else
        {
            J_UIManager.TheUI.TooltipMessage("You have no item equiped.", 2f);
            if (firstInteraction) { J_DialogueManager.Manager.Dialogue("I need a shovel...", null); firstInteraction = false; }
        }
    }

    public IEnumerator WaitForDig()
    {
        yield return new WaitForSeconds(3f);
        ShipWheel.tag = "Pickupable";
    }
}
