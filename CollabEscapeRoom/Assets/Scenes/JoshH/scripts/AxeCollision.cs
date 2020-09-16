using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeCollision : MonoBehaviour
{
    public AudioSource BreakSFX;
    
    private void OnCollisionEnter(Collision collision)
    {
         if(collision.gameObject.name == "Axe")
        {
           
            gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
            collision.gameObject.SetActive(false);
            BreakSFX.Play();
        }
        if (collision.gameObject.name == "Death Mallet(Clone)")
        {

            gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
        }
    }
 
        
}
