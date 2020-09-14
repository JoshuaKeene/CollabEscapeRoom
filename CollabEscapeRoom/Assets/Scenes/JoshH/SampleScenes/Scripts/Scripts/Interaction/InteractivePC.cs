using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractivePC : InteractiveObjectJH
{
    
    public bool PcPuzzleOn;
    public GameObject PCCam;
    public GameObject PcPuzzle;
    public GameObject Player;
    public GameObject HUD;
    public Camera PlayerCam;


    public GameObject PlayerLight;

    

    public override void ExecuteInteractiveAction()
    {
        base.ExecuteInteractiveAction();

        PcInteract();

       StartCoroutine(ActivateInXSec(2));

    }

    public void PcInteract()
    {
        if (PcPuzzleOn)
        {
            PCCam.SetActive(false);
            PcPuzzle.SetActive(false);
            PcPuzzleOn = false;
            UIManagerJH.TheUI.PlayerActive();
            
            PlayerCam.enabled = true;

           
            

        }
        else if (!PcPuzzleOn)
        {
            PcPuzzle.SetActive(true);
            //PcPuzzle.GetComponent<Test>().LetterSetup();
            PcPuzzleOn = true;
            
            PCCam.SetActive(true);
            PlayerCam.enabled = false;
            //PlayerLight.SetActive(false);
            UIManagerJH.TheUI.PlayerInactive();


            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
