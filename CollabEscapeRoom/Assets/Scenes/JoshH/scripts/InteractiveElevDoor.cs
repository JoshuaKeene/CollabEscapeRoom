using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveElevDoor : InteractiveObjectJH
{

    public string KeyItem;

    public bool NeedsItem;

    public GameObject elevDoor2;
    public GameObject Crowbar;
   
    public AudioSource ElevBang;
    public AudioSource MetalOpen;
    public override void ExecuteInteractiveAction()
    {
        base.ExecuteInteractiveAction();

        //if (NeedsItem)
        //{

            if (InventoryManagerJH.TheInventory.CurrentInventoryIndex < InventoryManagerJH.TheInventory.Items.Count)
            {
                if (InventoryManagerJH.TheInventory.Items[InventoryManagerJH.TheInventory.CurrentInventoryIndex].Name == KeyItem && InventoryManagerJH.TheInventory.CurrentItemImage.sprite != InventoryManagerJH.TheInventory.Empty)
                {
                    InventoryManagerJH.TheInventory.RemoveItem(InventoryManagerJH.TheInventory.CurrentInventoryIndex);
                    //InventoryManager.TheInventory.UpdateInventory();
                    gameObject.GetComponentInParent<Animator>().SetBool("Opened", true);
                    
                Crowbar.SetActive(true);
                    Crowbar.GetComponent<Collider>().enabled = false;
                    ElevBang.gameObject.GetComponent<AudioSource>().enabled = false;
                    gameObject.transform.tag = "Untagged";
                    NeedsItem = false;
                    InventoryManagerJH.TheInventory.UpdateInventory();
                    MetalOpen.Play();

            }
                else
                {

                    gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
                }
            }
             else
             {

                gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
             }
        //}



        //gameObject.SetActive(false);


        //else
        //{
        //    gameObject.GetComponent<Animator>().enabled = false;
        //    gameObject.transform.position = new Vector3(0f, 0f, 0.472f);
        //    Crowbar.SetActive(true);
        //    Crowbar.GetComponent<Collider>().enabled = false;
        //    Zombeh.SetBool("Getup", true);
        //    Zombeh.SetBool("Walk", true);
        //    ElevBang.Stop();
        //    //Invoke("StartWalk", 5);

        //}

        StartCoroutine(ActivateInXSec(3));


    }

}
