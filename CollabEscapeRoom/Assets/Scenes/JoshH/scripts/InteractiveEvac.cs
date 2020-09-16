using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveEvac : InteractiveObjectJH
{

    public string KeyItem;

    public bool NeedsItem;

    public Material OG;

    public GameObject PCcanv;
    public GameObject EntranceDoor;
    public GameObject EntranceDoor2;
    public GameObject EndGameTrigger;
    public GameObject BettyEnd;
    public GameObject Light1;
    public GameObject Light2;

    public Text BadEndingText;

    public AudioSource alarm;

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

                    gameObject.GetComponent<Renderer>().enabled = true;
                    gameObject.GetComponent<Renderer>().material = OG;
                    gameObject.GetComponent<InteractiveEvac>().Tooltip = "Press";
                    gameObject.GetComponent<DialogueScriptJH>().StartingDialogueBranch = 2;
                    NeedsItem = false;
                }
                else
                {
                    //if (DialogueScript.IsTalkingNow == false)
                    //{
                        gameObject.GetComponent<DialogueScriptJH>().StartingDialogueBranch = 0;
                        gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
                    //}
                }
            }

            else
            {
                // "I need the button first"
                //if (DialogueScript.IsTalkingNow == false)
                //{
                    //gameObject.GetComponent<DialogueScript>().StartingDialogueBranch = 0;
                    gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
                //}
            }

        }

        //gameObject.SetActive(false);


        else
        {
            if (PCcanv.GetComponent<TestJH>().PasswordEntered == true)
            {
                EntranceDoor.GetComponentInParent<Animator>().SetBool("Isopen", false);
                EntranceDoor2.GetComponentInParent<Animator>().SetBool("Isopen", false);
                EndGameTrigger.SetActive(true);
                BettyEnd.SetActive(true);
                BadEndingText.text = "";
                alarm.Play();
                Light1.SetActive(true);
                Light2.SetActive(true);
                Light2.GetComponentInParent<Renderer>().material.EnableKeyword("_EMISSION");
            }
            else
            {
                //if (DialogueScript.IsTalkingNow == false)
                //{
                gameObject.GetComponent<DialogueScriptJH>().StartingDialogueBranch = 2;
                gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
                //}
            }
        }


        StartCoroutine(ActivateInXSec(3.5f));



    }
}

