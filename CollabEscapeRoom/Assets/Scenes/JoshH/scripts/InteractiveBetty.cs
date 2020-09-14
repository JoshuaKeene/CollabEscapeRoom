using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractiveBetty : InteractiveObjectJH

{
    bool interacted;
    public bool NeedsItem;
    
    public List<string> KeyItems;

    public bool BettyAlive = true;

    public GameObject elev;
    
    public AudioSource Getup;

    public override void ExecuteInteractiveAction()
    {
        base.ExecuteInteractiveAction();

        if (NeedsItem)
        {

            if (InventoryManagerJH.TheInventory.CurrentInventoryIndex < InventoryManagerJH.TheInventory.Items.Count)
            {
                if (KeyItems.Contains(InventoryManagerJH.TheInventory.Items[InventoryManagerJH.TheInventory.CurrentInventoryIndex].Name) && InventoryManagerJH.TheInventory.CurrentItemImage.sprite != InventoryManagerJH.TheInventory.Empty)
                {
                    
                        gameObject.GetComponent<Animator>().SetBool("Getup", true);
                        gameObject.GetComponent<Animator>().SetBool("Walk", true);
                        elev.GetComponent<Animator>().SetTrigger("Close");
                        Invoke("AddTag",4);
                    

                    if (InventoryManagerJH.TheInventory.Items[InventoryManagerJH.TheInventory.CurrentInventoryIndex].Name != "Syringe - 3")
                    {
                        gameObject.GetComponent<Animator>().SetBool("Poisoned", true);
                        gameObject.tag = "Untagged";
                        BettyAlive = false;
                    }
                    else
                    {
                        gameObject.GetComponent<Animator>().SetBool("Poisoned", false);
                    }

                    
                    InventoryManagerJH.TheInventory.RemoveItem(InventoryManagerJH.TheInventory.CurrentInventoryIndex);
                    InventoryManagerJH.TheInventory.UpdateInventory();

                    NeedsItem = false;
                    



                }
                else if (InventoryManagerJH.TheInventory.Items[InventoryManagerJH.TheInventory.CurrentInventoryIndex].Name == "Empty Syringe")
                {
                    //if (DialogueScript.IsTalkingNowS == false)
                        gameObject.GetComponent<DialogueScriptJH>().StartingDialogueBranch = 0;
                    gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
                    
                }
                else if (InventoryManagerJH.TheInventory.Items[InventoryManagerJH.TheInventory.CurrentInventoryIndex].Name == "Syringe - 1" ||
                    InventoryManagerJH.TheInventory.Items[InventoryManagerJH.TheInventory.CurrentInventoryIndex].Name == "Syringe - 2" ||
                    InventoryManagerJH.TheInventory.Items[InventoryManagerJH.TheInventory.CurrentInventoryIndex].Name == "Syringe - 3" ||
                    InventoryManagerJH.TheInventory.Items[InventoryManagerJH.TheInventory.CurrentInventoryIndex].Name == "Syringe - 4" ||
                    InventoryManagerJH.TheInventory.Items[InventoryManagerJH.TheInventory.CurrentInventoryIndex].Name == "Syringe - 5" ||
                    InventoryManagerJH.TheInventory.Items[InventoryManagerJH.TheInventory.CurrentInventoryIndex].Name == "Syringe - 6")
                {
                    
                    
                    
                }
                else if (InventoryManagerJH.TheInventory.Items[InventoryManagerJH.TheInventory.CurrentInventoryIndex].Name == "Crowbar")
                {
                    
                    
                    gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
                }
                else if (InventoryManagerJH.TheInventory.Items[InventoryManagerJH.TheInventory.CurrentInventoryIndex].Name == "Matchstick")
                {
                    
                    
                    gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
                }

                else
                {
                    if(interacted)
                    {
                        gameObject.GetComponent<DialogueScriptJH>().StartingDialogueBranch = 2;
                    }
                    gameObject.GetComponent<DialogueScriptJH>().DialogueInit();

                }
            }

            else
            {

                if (interacted)
                {
                    gameObject.GetComponent<DialogueScriptJH>().StartingDialogueBranch = 2;
                }
                gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
            }

        }
        else
        {
            gameObject.GetComponent<DialogueScriptJH>().StartingDialogueBranch = 4;
            gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
        }




        interacted = true;

        StartCoroutine(ActivateInXSec(3));



    }

    public void AddTag()
    {
        elev.transform.GetChild(0).GetComponent<Transform>().tag = "Interactable";
    }
    //alternate ending timeline signal calls
    public void BettyDeadSignalFunction()
    {
        if(!BettyAlive || !GetComponent<Animator>().GetBool("Getup"))
        {
            SceneManager.LoadScene("EndScene");
        }
    }
    public void BettyAliveSignalFunction()
    {
        if (BettyAlive)
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    //Getup Jumpscare
    public void GetupSFX()
    {
        Getup.Play();
    }


}

