using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveBook : InteractiveObjectJH
{
    private bool BookOpen = false;
    public AudioSource Crumple;
    public GameObject HUD;
    public GameObject Player;
    public GameObject BookUI;
    public override void ExecuteInteractiveAction()
    {
        base.ExecuteInteractiveAction();

            
                if (!BookOpen)
                {
                    gameObject.SetActive(true);
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
                    gameObject.SetActive(false);
                    BookOpen = false;
                }
            
     
    }

}
