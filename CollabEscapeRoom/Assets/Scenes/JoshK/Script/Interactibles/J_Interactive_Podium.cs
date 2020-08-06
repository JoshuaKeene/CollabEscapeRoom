using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Interactive_Podium : J_InteractiveObject
{
    private string EquippedItem;
    private GameObject ActiveItem;
    [HideInInspector] //Public but hidden so that it can't be editied but can be read by other podiums
    public GameObject PodiumItem;
    [HideInInspector] //Public but hidden so that it can't be editied but can be read by other scripts
    public bool Solved = false;

    //Key item
    [Header("Correct Item")]
    public string ItemName;

    public enum TypeEnum { None, One, Two }

    //Linked Type - Exposed to inspector
    [Header("Linked Podiums")]
    [Tooltip("Ensure this is also set for the associated linked podiums.")]
    public TypeEnum Type;

    //Linked podium slot - One link
    [Tooltip("This should be the Podium Parent, NOT one of it's children.")]
    public GameObject Linked_Podium;

    //Linked podium slots - Two Links
    [Tooltip("This should be the Podium Parent, NOT one of it's children.")]
    public GameObject Linked_Podium_A;
    public GameObject Linked_Podium_B;

    //Stored linked podiums
    private GameObject L_Podium;
    private GameObject L_Podium_A;
    private GameObject L_Podium_B;

    private void Start()
    {
        //Find and assign private variables
        if (Type == TypeEnum.One)
        {
            Linked_Podium_A = null;
            L_Podium_A = null;
            Linked_Podium_B = null;
            L_Podium_B = null;

            var PodiumParent = Linked_Podium.transform.Find("Podium").gameObject;
            L_Podium = PodiumParent.transform.Find("PodiumManager").gameObject;
        }
        else if (Type == TypeEnum.Two)
        {
            Linked_Podium = null;
            L_Podium = null;
            
            var PodiumParent_A = Linked_Podium_A.transform.Find("Podium").gameObject;
            L_Podium_A = PodiumParent_A.transform.Find("PodiumManager").gameObject;

            var PodiumParent_B = Linked_Podium_B.transform.Find("Podium").gameObject;
            L_Podium_B = PodiumParent_B.transform.Find("PodiumManager").gameObject;
        }
        else
        {
            return;
        }
   
    }

    public override void ExecuteInteractiveAction()
    {
        base.ExecuteInteractiveAction();

        StartCoroutine(ActivateInXSec(2));

        
        //Does the player have an item equiped?
        if (J_InventoryManager.TheInventory.CurrentInventoryIndex < J_InventoryManager.TheInventory.Items.Count)
        {
            //Assign private variables
            EquippedItem = J_InventoryManager.TheInventory.Items[J_InventoryManager.TheInventory.CurrentInventoryIndex].Name;
            ActiveItem = gameObject.transform.Find(EquippedItem).gameObject;

            //Is there an item on the podium?
            if (PodiumItem != null && PodiumItem.activeInHierarchy) 
            {
                J_AudioManager.GlobalSFXManager.PlaySFX(J_AudioManager.GlobalSFXManager.ItemSound, null);
                //Add item on podium to inventory
                J_InventoryManager.TheInventory.AddItem(PodiumItem.GetComponent<J_InventoryPickup>().AssociatedItem);
                //Remove item on podium from podium
                PodiumItem.SetActive(false);
                //Remove equiped item from player
                J_InventoryManager.TheInventory.RemoveItem(EquippedItem);
                //Place item from player on podium
                ActiveItem.SetActive(true); 
                //Set new podium item
                PodiumItem = ActiveItem;
            }
            else
            {
                J_AudioManager.GlobalSFXManager.PlaySFX(J_AudioManager.GlobalSFXManager.ItemSound, null);
                //Place item from player on podium
                ActiveItem.SetActive(true);
                //Remove equiped item from player
                J_InventoryManager.TheInventory.RemoveItem(EquippedItem);
                //Set new podium item
                PodiumItem = ActiveItem;
            }

            //Check if combination correct
            if (Type == TypeEnum.None && PodiumItem != null && PodiumItem.name == ItemName)
            {
                if (PodiumItem.activeInHierarchy)
                {
                    Solved = true;
                    SetUninteractable();
                }
            }
            else if (Type == TypeEnum.One && PodiumItem != null && PodiumItem.name == ItemName && L_Podium.GetComponent<J_Interactive_Podium>().PodiumItem != null && L_Podium.GetComponent<J_Interactive_Podium>().PodiumItem.name == L_Podium.GetComponent<J_Interactive_Podium>().ItemName)
            {
                if (PodiumItem.activeInHierarchy && L_Podium.GetComponent<J_Interactive_Podium>().PodiumItem.activeInHierarchy)
                {
                    Solved = true;
                    SetUninteractable();
                    L_Podium.GetComponent<J_Interactive_Podium>().SetUninteractable();
                    L_Podium.GetComponent<J_Interactive_Podium>().Solved = true;
                }
            }
            else if (Type == TypeEnum.Two && PodiumItem != null && PodiumItem.name == ItemName && L_Podium_A.GetComponent<J_Interactive_Podium>().PodiumItem != null && L_Podium_A.GetComponent<J_Interactive_Podium>().PodiumItem.name == L_Podium_A.GetComponent<J_Interactive_Podium>().ItemName && L_Podium_B.GetComponent<J_Interactive_Podium>().PodiumItem != null && L_Podium_B.GetComponent<J_Interactive_Podium>().PodiumItem.name == L_Podium_B.GetComponent<J_Interactive_Podium>().ItemName)
            {
                if (PodiumItem.activeInHierarchy && L_Podium_A.GetComponent<J_Interactive_Podium>().PodiumItem.activeInHierarchy && L_Podium_B.GetComponent<J_Interactive_Podium>().PodiumItem.activeInHierarchy)
                {
                    Solved = true;
                    SetUninteractable();
                    L_Podium_A.GetComponent<J_Interactive_Podium>().SetUninteractable();
                    L_Podium_B.GetComponent<J_Interactive_Podium>().SetUninteractable();
                    L_Podium_A.GetComponent<J_Interactive_Podium>().Solved = true;
                    L_Podium_B.GetComponent<J_Interactive_Podium>().Solved = true;
                }
            }
        }
        else
        {
            J_UIManager.TheUI.TooltipMessage("You have no item equiped.", 2f);
            //print("You have no item equiped");
        }

    }

    public void SetUninteractable()
    {
        gameObject.tag = "Untagged";
        PodiumItem.tag = "Untagged";
    }

}
