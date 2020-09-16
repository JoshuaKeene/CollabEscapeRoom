using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelChairScare : MonoBehaviour
{
    public GameObject WheelChair;
    public GameObject Trigger1;
    public GameObject Trigger2;

    public AudioSource Squeak;
    //public AudioSource stabFx;
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            WheelChair.GetComponent<InteractiveObjectJH>().CanBeInteractedWith = true;
            WheelChair.GetComponent<Animator>().SetBool("Moved", true);
            Squeak.Play();
            gameObject.GetComponent<Collider>().enabled = false;
            Trigger1.SetActive(false);
            Trigger2.SetActive(false);
            //stabFx.Play();
            GetComponent<DialogueScriptJH>().DialogueInit();
        }
    }
}
