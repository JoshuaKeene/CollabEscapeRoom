using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveVial : InteractiveObjectJH
{

    public string Number;
    //private string KeyItem1 = "Empty Syringe";
    //public string KeyItem2;
    //public string KeyItem3;
    //public string KeyItem4;
    //public string KeyItem5;
    //public string KeyItem6;

    public List<string> KeyItems;
    public bool EmptyVial;
    public AudioSource LiquidSFX;

    public GameObject RedFill;
    public GameObject GreenFill;

    public InventoryItem FilledSyringe;

    public bool NeedsItem = true;
    public override void ExecuteInteractiveAction()
    {
        base.ExecuteInteractiveAction();

        if (NeedsItem)
        {

            if (InventoryManagerJH.TheInventory.CurrentInventoryIndex < InventoryManagerJH.TheInventory.Items.Count && InventoryManagerJH.TheInventory.CurrentItemImage.sprite != InventoryManagerJH.TheInventory.Empty)
            {
                if(KeyItems.Contains(InventoryManagerJH.TheInventory.Items[InventoryManagerJH.TheInventory.CurrentInventoryIndex].Name))
                //if ((InventoryManager.TheInventory.Items[InventoryManager.TheInventory.CurrentInventoryIndex].Name == KeyItem1 ||
                //    InventoryManager.TheInventory.Items[InventoryManager.TheInventory.CurrentInventoryIndex].Name == KeyItem2 ||
                //    InventoryManager.TheInventory.Items[InventoryManager.TheInventory.CurrentInventoryIndex].Name == KeyItem3 ||
                //    InventoryManager.TheInventory.Items[InventoryManager.TheInventory.CurrentInventoryIndex].Name == KeyItem4 ||
                //    InventoryManager.TheInventory.Items[InventoryManager.TheInventory.CurrentInventoryIndex].Name == KeyItem5 ||
                //    InventoryManager.TheInventory.Items[InventoryManager.TheInventory.CurrentInventoryIndex].Name == KeyItem6)
                //    && InventoryManager.TheInventory.CurrentItemImage.sprite != InventoryManager.TheInventory.Empty)
                {
                    if(EmptyVial)
                    {
                        if (InventoryManagerJH.TheInventory.Items[InventoryManagerJH.TheInventory.CurrentInventoryIndex].Name == "Syringe - 1" ||
                             InventoryManagerJH.TheInventory.Items[InventoryManagerJH.TheInventory.CurrentInventoryIndex].Name == "Syringe - 3" ||
                             InventoryManagerJH.TheInventory.Items[InventoryManagerJH.TheInventory.CurrentInventoryIndex].Name == "Syringe - 6")
                        {
                            GreenFill.SetActive(true);
                            RedFill.SetActive(false);
                        }

                        else
                        {
                            GreenFill.SetActive(false);
                            RedFill.SetActive(true);
                        }
                    }
                    InventoryManagerJH.TheInventory.RemoveItem(InventoryManagerJH.TheInventory.CurrentInventoryIndex);
                    InventoryManagerJH.TheInventory.UpdateInventory();
                    InventoryManagerJH.TheInventory.AddItem(FilledSyringe);
                    InventoryManagerJH.TheInventory.UpdateInventory();
                    LiquidSFX.Play();

                    

                }
                else
                {
                    //if (DialogueScript.IsTalkingNowS == false)
                        gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
                }
            }

            else
            {
                //if(DialogueScript.IsTalkingNowS == false)
                gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
            }

        }

        //gameObject.SetActive(false);


        


        StartCoroutine(ActivateInXSec(2));



    }
}

