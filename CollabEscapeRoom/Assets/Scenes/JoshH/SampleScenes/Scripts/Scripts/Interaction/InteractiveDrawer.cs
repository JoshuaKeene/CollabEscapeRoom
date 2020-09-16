using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveDrawer : InteractiveObjectJH
{
    public bool NeedsItem;
    public string KeyItem;
    public AudioSource Open;
    public AudioSource Close;
    public override void ExecuteInteractiveAction()
    {
        base.ExecuteInteractiveAction();

        if (NeedsItem)
        {
            if (InventoryManagerJH.TheInventory.CurrentInventoryIndex < InventoryManagerJH.TheInventory.Items.Count)
            {
                if (InventoryManagerJH.TheInventory.Items[InventoryManagerJH.TheInventory.CurrentInventoryIndex].Name == KeyItem && InventoryManagerJH.TheInventory.CurrentItemImage.sprite != InventoryManagerJH.TheInventory.Empty)
                {
                    if (gameObject.GetComponent<Animator>().GetBool("DrawerOpen") == true)
                    {
                        gameObject.GetComponent<Animator>().SetBool("DrawerOpen", false);
                        Open.Play();
                    }
                    else if (gameObject.GetComponent<Animator>().GetBool("DrawerOpen") == false)
                    {
                        gameObject.GetComponent<Animator>().SetBool("DrawerOpen", true);
                        Close.Play();
                    }
                    InventoryManagerJH.TheInventory.RemoveItem(InventoryManagerJH.TheInventory.CurrentInventoryIndex);
                }
            }

        }

        else
        {
            if (gameObject.GetComponent<Animator>().GetBool("DrawerOpen") == true)
            {
                gameObject.GetComponent<Animator>().SetBool("DrawerOpen", false);
                Open.Play();
            }
            else if (gameObject.GetComponent<Animator>().GetBool("DrawerOpen") == false)
            {
                gameObject.GetComponent<Animator>().SetBool("DrawerOpen", true);
                Close.Play();
            }
        }
        
        StartCoroutine(ActivateInXSec(2));
    }
}
