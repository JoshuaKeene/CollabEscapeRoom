using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveHardCrate : InteractiveObjectJH
{

    public string KeyItem;

    public bool NeedsItem;

    public Collider FireCol;

    public ParticleSystem FireFX;

    public GameObject Light;

    public override void ExecuteInteractiveAction()
    {
        base.ExecuteInteractiveAction();

        //if (NeedsItem)
        //{

            if (InventoryManagerJH.TheInventory.CurrentInventoryIndex < InventoryManagerJH.TheInventory.Items.Count)
            {
                if (InventoryManagerJH.TheInventory.Items[InventoryManagerJH.TheInventory.CurrentInventoryIndex].Name == KeyItem && InventoryManagerJH.TheInventory.CurrentItemImage.sprite != InventoryManagerJH.TheInventory.Empty)
                {

                    FireFX.Play();
                FireFX.gameObject.GetComponent<AudioSource>().Play();
                InventoryManagerJH.TheInventory.RemoveItem(InventoryManagerJH.TheInventory.CurrentInventoryIndex);
                InventoryManagerJH.TheInventory.UpdateInventory();
                NeedsItem = false;
                Light.SetActive(true);
                    //gameObject.GetComponent<Collider>().enabled = false;
                    FireCol.enabled = true;

                }
                else
                {
                //if (DialogueScript.IsTalkingNowS == false)
                    gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
                }


            }
            else
            {

            //if (DialogueScript.IsTalkingNowS == false)
                gameObject.GetComponent<DialogueScriptJH>().DialogueInit();

            }
        //}



        //else
        //{


        //    FireFX.Play();
        //}

        StartCoroutine(ActivateInXSec(2));

    }

   
}
