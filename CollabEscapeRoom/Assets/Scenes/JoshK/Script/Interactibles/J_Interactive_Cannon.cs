using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Interactive_Cannon : J_InteractiveObject
{
    private bool GunpowderLoaded = false;
    private bool CannonBallLoaded = false;
    [HideInInspector]
    public bool Fired = false;

    public GameObject DudCannon_1;
    public GameObject DudCannon_2;

    private static bool firstInteraction = true;

    [Header("Door to Destroy")]
    public GameObject Door;

    public override void ExecuteInteractiveAction()
    {
        base.ExecuteInteractiveAction();

        if (J_InventoryManager.TheInventory.CurrentInventoryIndex < J_InventoryManager.TheInventory.Items.Count)
        {
            if (J_InventoryManager.TheInventory.Items[J_InventoryManager.TheInventory.CurrentInventoryIndex].Name == "Gunpowder Keg" && GunpowderLoaded == false)
            {
                print("Gunpowder Loaded");

                GunpowderLoaded = true;

                J_UIManager.TheUI.TooltipMessage("Gunpowder loaded!", 1f);
                J_AudioManager.GlobalSFXManager.PlaySFX(J_AudioManager.GlobalSFXManager.ItemSound, null);

                J_InventoryManager.TheInventory.RemoveItem("Gunpowder Keg");
                Tooltip = " Load Cannon Ball";
            }
            else if (J_InventoryManager.TheInventory.Items[J_InventoryManager.TheInventory.CurrentInventoryIndex].Name == "Cannon Ball" && GunpowderLoaded == true)
            {
                print("Cannon Ball Loaded");

                CannonBallLoaded = true;

                J_UIManager.TheUI.TooltipMessage("Cannon ball loaded!", 1f);
                J_AudioManager.GlobalSFXManager.PlaySFX(J_AudioManager.GlobalSFXManager.ItemSound, null);

                J_InventoryManager.TheInventory.RemoveItem("Cannon Ball");
                Tooltip = " Fire";
            }
            else if (J_InventoryManager.TheInventory.Items[J_InventoryManager.TheInventory.CurrentInventoryIndex].Name == "Lit Torch" && CannonBallLoaded == true)
            {
                print("FIRE!");
                Fired = true;
                gameObject.tag = "Untagged";
                DudCannon_1.tag = "Untagged";
                DudCannon_2.tag = "Untagged";
                J_AudioManager.GlobalSFXManager.PlaySFX(J_AudioManager.GlobalSFXManager.Fuse, null);
                StartCoroutine("WaitForFuse");
            }
            else
            {
                if (J_InventoryManager.TheInventory.Items[J_InventoryManager.TheInventory.CurrentInventoryIndex].Name == "Torch" && CannonBallLoaded && firstInteraction)
                {
                    J_DialogueManager.Manager.Dialogue("I need to light this somehow...", null); 
                    firstInteraction = false;
                }
                else if (firstInteraction)
                {
                    J_DialogueManager.Manager.Dialogue("If I can work out how to fire this I can use it to break through the cavern wall.", null);
                    Tooltip = " Load Gunpowder";
                }
                else
                {
                    J_UIManager.TheUI.TooltipMessage("You do not have the requied item", 2f);
                }
            }
        }
        else
        {
            if (firstInteraction)
            {
                J_DialogueManager.Manager.Dialogue("If I can work out how to fire this I can use it to break through the cavern wall.", null);
                Tooltip = " Load Gunpowder";
            }
            else
            {
                J_UIManager.TheUI.TooltipMessage("You do not have the requied item", 2f);
            }
        }


        print("CLICK");

        StartCoroutine(ActivateInXSec(2));
                    
    }

    private IEnumerator WaitForFuse()
    {
        gameObject.transform.Find("Fuse").gameObject.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        gameObject.transform.Find("Fuse").gameObject.SetActive(false);

        gameObject.transform.Find("Cannon Blast").gameObject.SetActive(true);
        Fired = true;
        StartCoroutine("WaitForExplosion");
    }

    private IEnumerator WaitForExplosion()
    {
        yield return new WaitForSeconds(0.5f);
        Door.SetActive(false);
    }

}
