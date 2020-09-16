using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class InteractiveElevButton : InteractiveObjectJH
{
    public GameObject Player;
    public GameObject Button;
    public AudioSource ElevatorFx;
    public GameObject Betty;
    public GameObject BettyMoveTo;
    public string KeyItem;
    public Text ExitText;

    private bool firstDescent = true;
    public bool NeedsItem;
    
    public override void ExecuteInteractiveAction()
    {
        base.ExecuteInteractiveAction();

        if (NeedsItem)
        {

            if (InventoryManagerJH.TheInventory.CurrentInventoryIndex < InventoryManagerJH.TheInventory.Items.Count)
            {
                if (InventoryManagerJH.TheInventory.Items[InventoryManagerJH.TheInventory.CurrentInventoryIndex].Name == KeyItem && InventoryManagerJH.TheInventory.CurrentItemImage.sprite != InventoryManagerJH.TheInventory.Empty)
                {
                    Button.SetActive(true);
                    if (GetComponentInParent<Animator>().GetBool("Pressed") == false)
                    {

                        GetComponentInParent<Animator>().SetBool("Pressed", true);
                        UIManagerJH.TheUI.PlayerInactive();
                        ExitText.enabled = false;
                        StartCoroutine(PlayerActive());
                        GetComponent<InteractiveElevButton>().Tooltip = "Go Down";
                        ElevatorFx.Play();
                        StartCoroutine(ActivateInXSec(10));
                    }
                    else
                    {

                        GetComponentInParent<Animator>().SetBool("Pressed", false);
                        StartCoroutine(ActivateInXSec(10));

                    }
                    InventoryManagerJH.TheInventory.RemoveItem(InventoryManagerJH.TheInventory.CurrentInventoryIndex);
                    InventoryManagerJH.TheInventory.UpdateInventory();
                    NeedsItem = false;
                }
                else
                {
                    //if (DialogueScript.IsTalkingNowS == false)
                        gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
                    StartCoroutine(ActivateInXSec(4));
                }
            }
            else
            {
                //if (DialogueScript.IsTalkingNowS == false)
                    gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
                StartCoroutine(ActivateInXSec(4));
            }
        }

        else
            {
             if (GetComponentInParent<Animator>().GetBool("Pressed") == false)
                {

                    GetComponentInParent<Animator>().SetBool("Pressed", true);
                UIManagerJH.TheUI.PlayerInactive();
                StartCoroutine(PlayerActive());
                GetComponent<InteractiveElevButton>().Tooltip = "Go Down";
                ElevatorFx.Play();
                StartCoroutine(ActivateInXSec(10));

            }
             else
                {

                    GetComponentInParent<Animator>().SetBool("Pressed", false);
                GetComponent<InteractiveElevButton>().Tooltip = "Go Up";
                ElevatorFx.Play();
                StartCoroutine(ActivateInXSec(10));
                if (firstDescent)
                {
                    StartCoroutine(BettyScare());
                    firstDescent = false;
                }


            }
            } 
        }

       
    
    private IEnumerator BettyScare()//Invoke Betty to be moved and movement to be turned off then make her go back to her walking once the doors are open
    {
        yield return new WaitForSeconds(7f);
        Betty.GetComponent<MoveTo>().enabled = false;
        Betty.GetComponent<NavMeshAgent>().speed = 0;
       
        Betty.GetComponent<Animator>().SetTrigger("ElevScare");
        Betty.transform.position = BettyMoveTo.transform.position;
        Betty.transform.rotation = BettyMoveTo.transform.rotation;
    }
    private IEnumerator PlayerActive()
    {
        yield return new WaitForSeconds(2);
        ExitText.enabled = true;
        UIManagerJH.TheUI.PlayerActive();
        
    }

   
}
