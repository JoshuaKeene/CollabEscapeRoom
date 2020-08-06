using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Interactive_DudCannon : J_InteractiveObject
{
    [HideInInspector]
    public static bool firstInteraction = true;

    [HideInInspector]
    public bool Lit = false;

    public override void ExecuteInteractiveAction()
    {
        base.ExecuteInteractiveAction();

        if (J_InventoryManager.TheInventory.CurrentInventoryIndex < J_InventoryManager.TheInventory.Items.Count)
        {
            if (J_InventoryManager.TheInventory.Items[J_InventoryManager.TheInventory.CurrentInventoryIndex].Name == "Lit Torch" && !Lit)
            {
                Lit = true;
                J_AudioManager.GlobalSFXManager.PlaySFX(J_AudioManager.GlobalSFXManager.Fuse, null);
                StartCoroutine("WaitForFuse");
            }
            else if (J_InventoryManager.TheInventory.Items[J_InventoryManager.TheInventory.CurrentInventoryIndex].Name == "Lit Torch" && Lit)
            {
                J_DialogueManager.Manager.Dialogue("No fuse to light.", null);
            }
            else
            {
                if (firstInteraction == true)
                {
                    firstInteraction = false;
                    J_DialogueManager.Manager.Dialogue("My ship is on the other side of this cavern. These two cannons face the wrong way.", null);
                }
                else
                {
                    if (J_InventoryManager.TheInventory.CurrentInventoryIndex < J_InventoryManager.TheInventory.Items.Count)
                    {
                        if (J_InventoryManager.TheInventory.Items[J_InventoryManager.TheInventory.CurrentInventoryIndex].Name == "Gunpowder Keg" || J_InventoryManager.TheInventory.Items[J_InventoryManager.TheInventory.CurrentInventoryIndex].Name == "Cannon Ball")
                        {
                            J_DialogueManager.Manager.Dialogue("I've only got one of these, shouldn't waste it.", null);
                        }
                        else if (J_InventoryManager.TheInventory.Items[J_InventoryManager.TheInventory.CurrentInventoryIndex].Name == "Torch")
                        {
                            J_DialogueManager.Manager.Dialogue("This needs to be lit, but I probably shouldn't light this one anyway.", null);
                        }
                    }
                }
            }
        }
        else
        {
            if (firstInteraction == true)
            {
                firstInteraction = false;
                J_DialogueManager.Manager.Dialogue("My ship is on the other side of this cavern. These two cannons face the wrong way.", null);
            }
            else
            {
                if (J_InventoryManager.TheInventory.CurrentInventoryIndex < J_InventoryManager.TheInventory.Items.Count)
                {
                    if (J_InventoryManager.TheInventory.Items[J_InventoryManager.TheInventory.CurrentInventoryIndex].Name == "Gunpowder Keg" || J_InventoryManager.TheInventory.Items[J_InventoryManager.TheInventory.CurrentInventoryIndex].Name == "Cannon Ball")
                    {
                        J_DialogueManager.Manager.Dialogue("I've only got one of these, shouldn't waste it.", null);
                    }
                    else if (J_InventoryManager.TheInventory.Items[J_InventoryManager.TheInventory.CurrentInventoryIndex].Name == "Torch")
                    {
                        J_DialogueManager.Manager.Dialogue("This needs to be lit, but I probably shouldn't light this one anyway.", null);
                    }
                }
            }
        }

        StartCoroutine(ActivateInXSec(2));
    }

    private IEnumerator WaitForFuse()
    {
        gameObject.transform.Find("Fuse").gameObject.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        gameObject.transform.Find("Fuse").gameObject.SetActive(false);

        J_DialogueManager.Manager.Dialogue("Well that was a waste.", null);
    }
}
