using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Interactive_Chest : J_InteractiveObject
{
    public Animator ChestOpenAnim;
    public string KeyItemName;

    private static bool firstInteraction = true;

    public override void ExecuteInteractiveAction()
    {
        base.ExecuteInteractiveAction();

        print("CLICK");

        StartCoroutine(ActivateInXSec(2));

        if (J_InventoryManager.TheInventory.CurrentInventoryIndex < J_InventoryManager.TheInventory.Items.Count)
        {
            if (J_InventoryManager.TheInventory.Items[J_InventoryManager.TheInventory.CurrentInventoryIndex].Name == KeyItemName)
            {
                J_InventoryManager.TheInventory.RemoveItem(KeyItemName);
                J_AudioManager.GlobalSFXManager.PlaySFX(J_AudioManager.GlobalSFXManager.LockSuccess, null);
                gameObject.tag = "Untagged";

                StartCoroutine("Wait");
            }
            else
            {
                J_AudioManager.GlobalSFXManager.PlaySFX(J_AudioManager.GlobalSFXManager.LockFail, null);
                J_UIManager.TheUI.TooltipMessage("Incorrect item.", 2f);
                if (firstInteraction) { J_DialogueManager.Manager.Dialogue("This needs a key...", null); firstInteraction = false; return; }
            }
        }
        else
        {
            J_AudioManager.GlobalSFXManager.PlaySFX(J_AudioManager.GlobalSFXManager.LockFail, null);
            J_UIManager.TheUI.TooltipMessage("You have no item equiped.", 2f);
            if (firstInteraction) { J_DialogueManager.Manager.Dialogue("This needs a key...", null); firstInteraction = false; return; }
        }         
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.4f);

        J_AudioManager.GlobalSFXManager.PlaySFX(J_AudioManager.GlobalSFXManager.ChestOpen, null);
        ChestOpenAnim.Play(J_AnimationManager.Chest_Open);
    }
}
