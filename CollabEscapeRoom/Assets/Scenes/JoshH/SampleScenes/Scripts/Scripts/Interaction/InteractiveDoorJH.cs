using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveDoorJH : InteractiveObjectJH
{
    public string KeyItem;
    public bool NeedsItem;

    public AudioSource Open;
    public AudioSource Close;
    public AudioSource Unlock;
    public AudioSource Rattle;


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
                    

                    if (gameObject.GetComponentInParent<Animator>().GetBool("Isopen") == true)
                    {
                        gameObject.GetComponentInParent<Animator>().SetBool("Isopen", false);
                        Unlock.Play();
                        Open.Play();
                        gameObject.GetComponent<InteractiveDoorJH>().Tooltip = "Close";

                    }
                    else if (gameObject.GetComponentInParent<Animator>().GetBool("Isopen") == false)
                    {
                        
                        gameObject.GetComponentInParent<Animator>().SetBool("Isopen", true);
                        Close.Play();
                        gameObject.GetComponent<InteractiveDoorJH>().Tooltip = "Open";
                        

                    }
                    InventoryManagerJH.TheInventory.UpdateInventory();
                    NeedsItem = false;
                }
                else
                {
                    gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
                    gameObject.GetComponentInParent<Animator>().SetBool("Rattle", true);
                    if(gameObject.GetComponent<InteractiveDoorJH>().Rattle != null) Rattle.Play();
                    
                    
                    StartCoroutine(ResetBool());
                }
            }

            else
            {
                gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
                gameObject.GetComponentInParent<Animator>().SetBool("Rattle", true);
                if (gameObject.GetComponent<InteractiveDoorJH>().Rattle != null) Rattle.Play();
                StartCoroutine(ResetBool());
            }

        }

        //gameObject.SetActive(false);


        else
        {
            if (gameObject.GetComponentInParent<Animator>().GetBool("Isopen") == true)
            {
               
                gameObject.GetComponentInParent<Animator>().SetBool("Isopen", false);
                Open.Play();
                gameObject.GetComponent<InteractiveDoorJH>().Tooltip = "Close";

            }
            else if (gameObject.GetComponentInParent<Animator>().GetBool("Isopen") == false)
            {
                gameObject.GetComponentInParent<Animator>().SetBool("Isopen", true);
                Close.Play();
                gameObject.GetComponent<InteractiveDoorJH>().Tooltip = "Open";
            }
        } 
            
        
        StartCoroutine(ActivateInXSec(3));

        

    }

   public IEnumerator ResetBool()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponentInParent<Animator>().SetBool("Rattle", false);
    }
}
