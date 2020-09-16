using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableKeypad : InteractiveObjectJH
{

    public GameObject Player;
    public GameObject HUD;

    public GameObject KeypadCanvas;

    private bool KeypadOn = false;
    public override void ExecuteInteractiveAction()
    {
        base.ExecuteInteractiveAction();

        if (KeypadOn == true)
        {
            KeypadCanvas.SetActive(false);
            Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
            HUD.SetActive(true);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (KeypadOn == false)
        {
            KeypadCanvas.SetActive(true);
            Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
            //HUD.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            UIManagerJH.TheUI.ExitText.enabled = true;
        }

        StartCoroutine(ActivateInXSec(2));

    }
}

