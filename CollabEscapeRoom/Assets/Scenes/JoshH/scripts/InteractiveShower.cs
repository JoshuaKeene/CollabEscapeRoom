using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveShower : InteractiveObjectJH
{

    public string KeyItem;

    public bool NeedsItem;

    // public prefab ShowerFX
    public GameObject Mirror;

    public ParticleSystem Steam;
    public ParticleSystem ShowerFX;

    public AudioSource ShowerSFX;
    public AudioSource TapSqueak;

    // Start is called before the first frame update
    public override void ExecuteInteractiveAction()
    {
        base.ExecuteInteractiveAction();
        StartCoroutine(ActivateInXSec(4));

        if (NeedsItem)
        {
            if (InventoryManagerJH.TheInventory.CurrentInventoryIndex < InventoryManagerJH.TheInventory.Items.Count)
            {
                if (InventoryManagerJH.TheInventory.Items[InventoryManagerJH.TheInventory.CurrentInventoryIndex].Name == KeyItem && InventoryManagerJH.TheInventory.CurrentItemImage.sprite != InventoryManagerJH.TheInventory.Empty)
                {
                    if (Mirror.activeInHierarchy)
                    {
                        ShowerFX.Play();
                        ShowerSFX.Play();
                        TapSqueak.Play();
                        Steam.Play();
                        Mirror.SetActive(false);
                        StartCoroutine(TurnShowerOff());
                    }
                    else
                    {
                        ShowerFX.Stop();
                        ShowerSFX.Stop();
                        TapSqueak.Play();
                        Steam.Stop();
                        Mirror.SetActive(true);

                    }

                    InventoryManagerJH.TheInventory.RemoveItem(InventoryManagerJH.TheInventory.CurrentInventoryIndex);
                    InventoryManagerJH.TheInventory.UpdateInventory();
                    NeedsItem = false;
                }
                else
                {
                    //if (DialogueScript.IsTalkingNow == false)
                        gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
                }
            }
            else
            {
                //if (DialogueScript.IsTalkingNow == false)
                    gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
            }
        }

            else
            {
                if (Mirror.activeInHierarchy)
                {
                    ShowerFX.Play();
                    TapSqueak.Play();
                    ShowerSFX.Play();
                    Steam.Play();
                    Mirror.SetActive(false);
                StartCoroutine(TurnShowerOff());

                }
                else
                {
                    ShowerSFX.Stop();
                    TapSqueak.Play();
                    ShowerFX.Stop();
                    Steam.Stop();
                    Mirror.SetActive(true);

                }
            }
        }

    private IEnumerator TurnShowerOff()
    {
        yield return new WaitForSeconds(30);
        ShowerFX.Stop();
        ShowerSFX.Stop();
        TapSqueak.Play();
        Steam.Stop();
        Mirror.SetActive(true);
    }

        
}




