using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTT : MonoBehaviour
{
    public Text Tooltip;
    public GameObject player;
    public string Tip;
    private bool keyPressed;
 
    public string input;

    public void Update()
    {
        if (!keyPressed)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (Tooltip.text == Tip)
                {
                    TutorialWait();
                    keyPressed = true;
                    //player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_WalkSpeed = 5;
                    //player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_RunSpeed = 10;
                }
            }
        }

       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Tooltip.enabled = true;
            Tooltip.text = Tip;
            
            
           GetComponent<Collider>().enabled = false;
            
            //player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_WalkSpeed = 0;
            //player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_RunSpeed = 0;

        }
        
        
    }

    private void TutorialWait()
    {
        Tooltip.text = "";
        Tooltip.enabled = false;
        
    }
}
