using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveAngelHidden : InteractiveObjectJH
{
    public bool NeedsItem;

    public string KeyItem;

    public GameObject Angel;
    public override void ExecuteInteractiveAction()
    {
        base.ExecuteInteractiveAction();

        if (NeedsItem)
        {

            if (InventoryManagerJH.TheInventory.CurrentInventoryIndex < InventoryManagerJH.TheInventory.Items.Count)
            {
                if (InventoryManagerJH.TheInventory.Items[InventoryManagerJH.TheInventory.CurrentInventoryIndex].Name == KeyItem && InventoryManagerJH.TheInventory.CurrentItemImage.sprite != InventoryManagerJH.TheInventory.Empty)
                {

                    InventoryManagerJH.TheInventory.RemoveItem(InventoryManagerJH.TheInventory.CurrentInventoryIndex);
                    InventoryManagerJH.TheInventory.UpdateInventory();
                    Angel.SetActive(true);
                    gameObject.GetComponent<Collider>().enabled = false;
                    gameObject.GetComponent<Renderer>().enabled = false;
                    gameObject.GetComponent<InteractiveAngelHidden>().enabled = false;

                }
                else
                {
                    gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
                    StartCoroutine(ActivateInXSec(3));
                }
            }

            else
            {
                gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
                StartCoroutine(ActivateInXSec(3));
            }

        }

       


        



    }
}

