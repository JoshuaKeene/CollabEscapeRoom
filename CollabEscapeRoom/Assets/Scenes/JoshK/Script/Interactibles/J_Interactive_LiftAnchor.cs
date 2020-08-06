using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Interactive_LiftAnchor : J_InteractiveObject
{
    public Animator LiftAnim;
    public GameObject Lift;
    public string InteractItemName;

    private GameObject LiftZone;

    private void Start()
    {
        LiftZone = Lift.transform.Find("Trigger").gameObject;
    }

    public override void ExecuteInteractiveAction()
    {
        base.ExecuteInteractiveAction();

        print("CLICK");

        StartCoroutine(ActivateInXSec(2));

        if (J_InventoryManager.TheInventory.CurrentInventoryIndex < J_InventoryManager.TheInventory.Items.Count)
        {
            if (J_InventoryManager.TheInventory.Items[J_InventoryManager.TheInventory.CurrentInventoryIndex].Name == InteractItemName)
            {
                if (LiftZone.GetComponent<J_LiftTrigger>().PlayerInLift)
                {
                    LiftAnim.Play(J_AnimationManager.Lift_Lower);
                    J_AudioManager.GlobalSFXManager.PlaySFX(J_AudioManager.GlobalSFXManager.RopeCut, null);

                    Lift.GetComponent<AudioSource>().PlayOneShot(J_AudioManager.GlobalSFXManager.LiftLower);

                    gameObject.SetActive(false);
                }
                else
                {
                    J_DialogueManager.Manager.Dialogue("I should probably stand on the lift before cutting this.", null);
                }
            }
            else
            {
                J_UIManager.TheUI.TooltipMessage("Sharp item required.", 3f);
            }
        }
        else
        {
            J_UIManager.TheUI.TooltipMessage("You have no item eqquiped.", 3f);
        }           
    }
}
