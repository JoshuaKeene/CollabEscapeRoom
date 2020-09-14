using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Playables;

public class MouseRaycastJH : MonoBehaviour 
{
    // Start is called before the first frame update
    Ray ray;
    RaycastHit hit;
    public Text TooltipText;
    public bool PcPuzzleOn;
    public GameObject PcPuzzle;
    public GameObject HUD;
    public GameObject Player;
    public GameObject LetterFromEm;
    private bool BookOpen = false;
    public AudioSource Crumple;
    public Camera PlayerCam;
    public GameObject PCCam;
   
    public GameObject Inv;
 
  
 
    //public float RotSpeed;

    void Start()
    {
        PcPuzzleOn = false;

    }

    // Update is called once per frame
    void Update()
    {
        RayAcknowledgement();
        PCtoggle();
        Door();
        ReadBook();
       

    }

    private void Door()
    {
        if (Input.GetKeyDown(KeyCode.R) && hit.collider.tag == "Door")
        {
            if (hit.collider.gameObject.GetComponentInParent<Animator>().GetBool("Isopen")== true)
            {
                hit.collider.gameObject.GetComponentInParent<Animator>().SetBool("Isopen", false);
                
            }
            else if (hit.collider.gameObject.GetComponentInParent<Animator>().GetBool("Isopen") == false)
            {
                hit.collider.gameObject.GetComponentInParent<Animator>().SetBool("Isopen", true);
                
            }
        }
    }


    

    public void RayAcknowledgement()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit, 3))
        {

            print(hit.collider.name);
            if (hit.collider.tag == "Untagged")
            {
                TooltipText.gameObject.SetActive(false);
                
            }
            else
            {
                TooltipText.gameObject.SetActive(true);
                
            }
        }
        else
        {
            TooltipText.gameObject.SetActive(false);
        }
    }

 
    

    public void ReadBook()
    {
        if (Input.GetKeyDown(KeyCode.R) && hit.collider.tag == "book")
        {
            if (!BookOpen)
            {
                LetterFromEm.SetActive(true);
                BookOpen = true;
                Crumple.Play();
                HUD.SetActive(false);
                Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                HUD.SetActive(true);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
                LetterFromEm.SetActive(false);
                BookOpen = false;
            }
        }
    }


    public void CloseBook()
    {
        HUD.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
        LetterFromEm.SetActive(false);
        BookOpen = false;
    }


    private void PCtoggle()
    {
        //if (hit.collider.tag == "PC")
        //{

        if (Input.GetKeyDown(KeyCode.R) && hit.collider.tag == "PC")
        {
            if (PcPuzzleOn == true)
            {
                PCCam.SetActive(false); 
                PcPuzzle.SetActive(false);
                PcPuzzleOn = false;
                Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
                
                PlayerCam.enabled = true;
                
                HUD.SetActive(true);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

            }
            else if (PcPuzzleOn == false)
            {
                PcPuzzle.SetActive(true);
                PcPuzzleOn = true;
                Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
                PCCam.SetActive(true); 
                PlayerCam.enabled = false;
                
                HUD.SetActive(false);
                
                //Cursor.visible = true;
                //Cursor.lockState = CursorLockMode.None;
            }
        }


        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    if (PcPuzzleOn == true)
        //    {
        //        PcPuzzle.SetActive(false);
        //        PcPuzzleOn = false;
        //        Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
        //        HUD.SetActive(true);
        //        Cursor.visible = false;
        //        Cursor.lockState = CursorLockMode.Locked;

        //    }
        //}


    }

   
}
