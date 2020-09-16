using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyOpen : InteractiveObjectJH
{
    public AudioSource Bang;
    public AudioSource Rattle;
    public string KeyItem;
    public override void ExecuteInteractiveAction()
    {
        base.ExecuteInteractiveAction();

        if (InventoryManagerJH.TheInventory.CurrentInventoryIndex < InventoryManagerJH.TheInventory.Items.Count)
        {
            if (InventoryManagerJH.TheInventory.Items[InventoryManagerJH.TheInventory.CurrentInventoryIndex].Name == KeyItem && InventoryManagerJH.TheInventory.CurrentItemImage.sprite != InventoryManagerJH.TheInventory.Empty)
            {

                InventoryManagerJH.TheInventory.RemoveItem(InventoryManagerJH.TheInventory.CurrentInventoryIndex);
                gameObject.GetComponentInParent<Animator>().SetBool("HitOpen", true);
                Bang.Play();
                InventoryManagerJH.TheInventory.UpdateInventory();

            }
            else
            {
                gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
                gameObject.GetComponentInParent<Animator>().SetBool("Rattle", true);
                Rattle.Play();


                StartCoroutine(ResetRattle());
                StartCoroutine(ActivateInXSec(4));
            }
        }

        else
        {
            gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
            gameObject.GetComponentInParent<Animator>().SetBool("Rattle", true);
            Rattle.Play();
            StartCoroutine(ResetRattle());
            StartCoroutine(ActivateInXSec(4));
        }
    }

    public IEnumerator ResetRattle()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponentInParent<Animator>().SetBool("Rattle", false);
    }
}
