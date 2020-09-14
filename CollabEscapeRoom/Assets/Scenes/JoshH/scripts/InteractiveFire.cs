using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveFire : InteractiveObjectJH
{

    public string KeyItem;

    public bool NeedsItem;
    
    public GameObject ChestLid;
    public GameObject ChestBody;
    public GameObject MetalButton;
    public GameObject Light;
    
    public Color Burned;

    public AudioSource Extinguisher;

    public ParticleSystem Extinguish;

   


    public override void ExecuteInteractiveAction()
    {
        base.ExecuteInteractiveAction();

       

            if (InventoryManagerJH.TheInventory.CurrentInventoryIndex < InventoryManagerJH.TheInventory.Items.Count)
            {
                if (InventoryManagerJH.TheInventory.Items[InventoryManagerJH.TheInventory.CurrentInventoryIndex].Name == KeyItem && InventoryManagerJH.TheInventory.CurrentItemImage.sprite != InventoryManagerJH.TheInventory.Empty)
                {

                    GetComponent<ParticleSystem>().Stop();
                    GetComponent<Collider>().enabled = false;
                    gameObject.SetActive(false);
                    ChestLid.SetActive(false);
                    ChestBody.GetComponentInParent<Renderer>().material.color = Burned;
                    ChestBody.GetComponent<Collider>().enabled = false;
                    InventoryManagerJH.TheInventory.RemoveItem(InventoryManagerJH.TheInventory.CurrentInventoryIndex);
                    InventoryManagerJH.TheInventory.UpdateInventory();
                    NeedsItem = false;
                  
                    Extinguisher.Play();
                    Extinguish.Play();
                     Light.SetActive(false);

                }
                else
                {
                //if (DialogueScript.IsTalkingNowS == false)
                    gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
                    StartCoroutine(ActivateInXSec(1));
                }

            }
            else
            {
            //if (DialogueScript.IsTalkingNowS == false)
                gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
                StartCoroutine(ActivateInXSec(1));
            }



        
        }
        

}

