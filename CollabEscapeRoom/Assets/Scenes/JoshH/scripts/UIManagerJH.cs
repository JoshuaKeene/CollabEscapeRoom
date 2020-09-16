using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class UIManagerJH : MonoBehaviour
{
    public static UIManagerJH TheUI;

    public FirstPersonController TheCharInput;

    public Text ExitText;
    public GameObject PCPuzzle;
    public GameObject PauseMen;
    public GameObject PCCam;
    public GameObject HUD;
    public GameObject MainMenu;
    public GameObject Chest;
    public GameObject Keypad;
    public GameObject CryptogramPan;
    public GameObject CryptoTut;
    public GameObject InteractivePC;
    public GameObject flashlight;
    public GameObject SettingsPanel;
    public GameObject gameOverCamera;

   

    public AudioSource CryptoSound;
    public AudioSource HB;

    //public Text ESCTooltip;

    public Camera PlayerCam;
    public Camera PadlockCam;

    public bool Paused;

    public GameObject gameFader;

    public GameObject Crosshair;

    void Start()
    {
        TheUI = this;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) )
        {
            
                if (!AreAnyUIIsActive())
                {

                    if (CryptogramPan.GetComponent<Animator>().GetBool("Open") == false)
                    {

                        CryptogramPan.GetComponent<Animator>().SetBool("Open", true);
                        CryptoSound.Play();
                        PlayerInactive();
                        PostProcessManagerJH.PPMan.StartCoroutine("GradualBlur");
                    }
                    else
                    {
                        CryptogramPan.GetComponent<Animator>().SetBool("Open", false);
                        PlayerActive();
                        CryptoSound.Play();
                        PostProcessManagerJH.PPMan.StartCoroutine("UnBlur");
                    }
                }
                else if (CryptogramPan.GetComponent<Animator>().GetBool("Open") == true)
                {
                    CryptogramPan.GetComponent<Animator>().SetBool("Open", false);
                    PlayerActive();
                    CryptoSound.Play();
                    PostProcessManagerJH.PPMan.StartCoroutine("UnBlur");
                }
                
            
           
        }
            
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (AreAnyUIIsActive() == false)
            {
                
               
                


            }

            else if (PauseMen.activeInHierarchy && !SettingsPanel.activeInHierarchy)
            {
                
                TogglePause();
                
            }
            else if (PCPuzzle.activeSelf == true)
            {
                ClosePcPuzzle();

            }
            else if (InventoryManagerJH.TheInventory.InventoryPanel.GetComponent<Animator>().GetBool("Open") == true && !DocumentManagerJH.TheManager.DocPanel.activeInHierarchy)
            {
                InventoryManagerJH.TheInventory.CloseInventory();
               
                PlayerActive();
            }
            else if (PadlockCam.enabled == true)
            {
                //ESCTooltip.gameObject.SetActive(false );
                PadlockCam.enabled = false;
                PlayerCam.enabled = true;
                PlayerActive();
                Chest.GetComponent<InteractiveChestJH>().PadlockVisible = false;
                Crosshair.SetActive(true);
            }
            else if (Keypad.activeSelf == true)
            {
                PlayerActive();
                Keypad.SetActive(false);

            }
            else if (DocumentManagerJH.TheManager.DocPanel.activeInHierarchy)
            {
                //DocumentManager.TheManager.DocPanel.SetActive(false);
                DocumentManagerJH.TheManager.CloseDocumentPanel();
                //PostProcessManager.PPMan.StartCoroutine("UnBlur");
                if (InventoryManagerJH.TheInventory.InventoryPanel.GetComponent<Animator>().GetBool("Open") == false)
                {
                    PlayerActive();
                }
                else
                {
                    PlayerInactive();
                }

                if(DocumentManagerJH.TheManager.DocOnScreen.sprite == CryptogramPan.GetComponent<Image>().sprite)
                {
                  CryptoTut.GetComponent<CryptoTutorial>().CryptoTT();
                }
            }
            else if (CryptogramPan.GetComponent<Animator>().GetBool("Open") == true)
            {
                CryptogramPan.GetComponent<Animator>().SetBool("Open", false);
                PlayerActive();
                CryptoSound.Play();
                ExitText.enabled = false;
                PostProcessManagerJH.PPMan.StartCoroutine("UnBlur");
            }
           


        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (AreAnyUIIsActive() == false)
            {


                TogglePause();
                


            }
        }
        //if (Input.GetButtonDown("Exit"))
        //{
        //    if (AreAnyUIIsActive() == false)
        //    {

        //        TogglePause();



        //    }

        //    else if (PauseMen.activeInHierarchy && !SettingsPanel.activeInHierarchy)
        //    {

        //        TogglePause();

        //    }
        //}
    }
    public bool AreAnyUIIsActive()
    {
        if (DocumentManagerJH.TheManager.DocPanel.activeInHierarchy) return true;
        else if (InventoryManagerJH.TheInventory.InventoryPanel.GetComponent<Animator>().GetBool("Open") == true) return true;
        else if (PCPuzzle.activeInHierarchy) return true;
        else if (PauseMen.activeInHierarchy) return true;
        else if (MainMenu.activeInHierarchy) return true;
        else if (PadlockCam.enabled == true) return true;
        else if (Keypad.activeInHierarchy) return true;
        else if (CryptogramPan.GetComponent<Animator>().GetBool("Open") == true) return true;
        else if (SettingsPanel.activeInHierarchy) return true;
        else if (gameOverCamera.activeInHierarchy) return true;
        else if (gameFader.activeInHierarchy) return true;


        else
            return false;
    }

    internal void LockInput(bool LockVal)
    {
        TheCharInput.enabled = LockVal;
    }

    public void ClosePcPuzzle()
    {
        PCCam.SetActive(false);
        PCPuzzle.SetActive(false);
        PlayerActive();
        PlayerCam.enabled = true;
        InteractivePC.GetComponent<InteractivePC>().PcPuzzleOn = false;

    }

    public void TogglePause()
    {
        if (Paused)
        {
            PauseMen.SetActive(false);
            PlayerActive();
            Paused = false;
            HB.Stop();
            ExitText.enabled = false;
            PostProcessManagerJH.PPMan.StartCoroutine("UnBlur");

        }
        else 
        {
            
            PauseMen.SetActive(true);
            PlayerInactive();
            Paused = true;
            ExitText.enabled = false;
            PostProcessManagerJH.PPMan.StartCoroutine("GradualBlur");

        }
    }

    public void PlayerActive()
    {
        LockInput(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        HUD.SetActive(true);
        Paused = false;
        ExitText.enabled = false;
    }

    public void PlayerInactive()
    {
        LockInput(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        HUD.SetActive(false);
        ExitText.enabled = true;
    }

   

    

}
