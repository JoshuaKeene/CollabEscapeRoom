using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class J_Interactive_FirePit : J_InteractiveObject
{
    [Header("Fire Pit Variables")]
    public float TimeLimit;

    public Sprite Torch;
    public Sprite LitTorch;

    public GameObject Cannon;
    public GameObject DudCannon_1;
    public GameObject DudCannon_2;

    private static bool firstInteraction = true;

    public override void ExecuteInteractiveAction()
    {
        if (J_InventoryManager.TheInventory.CurrentInventoryIndex < J_InventoryManager.TheInventory.Items.Count)
        {
            if (J_InventoryManager.TheInventory.Items[J_InventoryManager.TheInventory.CurrentInventoryIndex].Name == "Torch")
            {
                J_UIManager.TheUI.TooltipMessage("Torch lit!", 2f);
                J_InventoryManager.TheInventory.Items[J_InventoryManager.TheInventory.GetIndexOfItem("Torch")].Image = LitTorch;
                J_InventoryManager.TheInventory.Items[J_InventoryManager.TheInventory.GetIndexOfItem("Torch")].Name = "Lit Torch";
                gameObject.GetComponent<MeshCollider>().enabled = false;
                StartCoroutine("LitDuration");
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

    public IEnumerator LitDuration()
    {
        yield return new WaitForSeconds(TimeLimit);
        J_InventoryManager.TheInventory.Items[J_InventoryManager.TheInventory.GetIndexOfItem("Lit Torch")].Image = Torch;
        J_InventoryManager.TheInventory.Items[J_InventoryManager.TheInventory.GetIndexOfItem("Lit Torch")].Name = "Torch";
        if ((firstInteraction && Cannon.GetComponent<J_Interactive_Cannon>().Fired == false) && DudCannon_1.GetComponent<J_Interactive_DudCannon>().Lit == false && DudCannon_2.GetComponent<J_Interactive_DudCannon>().Lit == false) { J_UIManager.TheUI.TooltipMessage("Torch extinguished!\nYou need to be faster!", 2f); firstInteraction = false; }
        else if (Cannon.GetComponent<J_Interactive_Cannon>().Fired == false) { J_UIManager.TheUI.TooltipMessage("Torch extinguished!", 2f); }
        gameObject.GetComponent<MeshCollider>().enabled = true;
    }

}
