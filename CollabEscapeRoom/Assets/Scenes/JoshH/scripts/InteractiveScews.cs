using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveScews : InteractiveObjectJH
{

    public bool NeedsItem;

    public string KeyItem;

    public GameObject Door;
    //bool Jack Released
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



                    gameObject.GetComponent<Animator>().SetTrigger("ScrewRemoved");
                    Door.GetComponent<InteractiveDoorJH>().NeedsItem = false;
                    NeedsItem = false;
                }
                else
                {
                    //if(DialogueScript.IsTalkingNowS == false)
                        gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
                }
            }

            else
            {
                //if (DialogueScript.IsTalkingNowS == false)
                    gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
            }

        }

        //gameObject.SetActive(false);


       


        StartCoroutine(ActivateInXSec(5));



    }
}

