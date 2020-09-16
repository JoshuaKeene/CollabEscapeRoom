using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDirector : MonoBehaviour
{
    // Start is called before the first frame update

    public bool InventoryIsOpen = false;
    public GameObject UIPanel;
    public GameObject PcPuzzlePanel;
    public GameObject HUD;
    public GameObject ESC;
    public GameObject MainMenuPanel;
    public GameObject Player;
    private bool Paused = false;
    public GameObject PCCam;
    public Camera PlayerCam;

    public AudioSource HB;
  
 

    // Update is called once per frame
    void Update()
    {
        

        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    if (AreAnyUIIsActive() == false)
        //    {
               
        //        TogglePause();
                
                
        //    }
          
        //    else if (ESC.activeSelf == true)
        //    {
        //        TogglePause();
        //    }
        //    else if (PCPuzzle.activeSelf == true)
        //    {
        //        ClosePcPuzzle();

        //    }

          
        //}

    }

   
   

    public void ClosePcPuzzle()
    {
        PCCam.SetActive(false);
        PcPuzzlePanel.SetActive(false);
        Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        HUD.SetActive(true);
        PlayerCam.enabled = true;
        
    }

    public void TogglePause()
    {
        if (Paused)
        {
            ESC.SetActive(false);
            Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            HUD.SetActive(true);
            Paused = false;
            HB.Stop();

        }
        else if (!Paused)
        {
            PCCam.SetActive(false);
            ESC.SetActive(true);
            Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            HUD.SetActive(false);
            Paused = true;
        }
    }
}
