using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_InventoryTutorial : MonoBehaviour
{
    public List<GameObject> Items = new List<GameObject>();

    private bool ItemPickedUp = false;

    // Update is called once per frame
    void Update()
    {
        if (!ItemPickedUp)
        {
            foreach (var item in Items)
            {
                if (!item.activeInHierarchy) 
                { 
                    ItemPickedUp = true;
                    J_UIManager.TheUI.TooltipMessage("'TAB' to open Inventory.", 2);
                }
            }
        }
    }
}
