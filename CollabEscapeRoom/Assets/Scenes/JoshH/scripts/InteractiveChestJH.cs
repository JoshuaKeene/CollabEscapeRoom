using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveChestJH : InteractiveObjectJH
{

    public Camera PadlockCam;
    public GameObject Player;
    public Camera PlayerCam;
    public bool PadlockVisible;
    public GameObject Crosshair;
    public GameObject Esc;
    public override void ExecuteInteractiveAction()
    {
        base.ExecuteInteractiveAction();


        if (PadlockVisible)
        {
            
            PadlockCam.enabled = false;
            PlayerCam.enabled = true;
            UIManagerJH.TheUI.LockInput(true);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            PadlockVisible = false;
            Crosshair.SetActive(true);
            Esc.SetActive(false);
            UIManagerJH.TheUI.ExitText.enabled = true;
        }
        else
        {
            
            PadlockCam.enabled = true;
            PlayerCam.enabled = false;
            UIManagerJH.TheUI.LockInput(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            PadlockVisible = true;
           Crosshair.SetActive(false);
            UIManagerJH.TheUI.ExitText.enabled = true;

        }

        StartCoroutine(ActivateInXSec(2));
    }
}
