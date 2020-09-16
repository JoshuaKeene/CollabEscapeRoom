using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class InteractTriggerJH : MonoBehaviour
{
    //public GameObject DIR;
    public GameObject AssociatedInteractor;
    public GameObject AltInteractor;
   
    public GameObject Look;
    public bool IsAuto;

    public AudioSource sound;
    //public TimelineController timecon;
    public Animator animator;
    public bool LookAtTrigger;
    public PlayableDirector timeline;
    public int LookAtIndx;

    private void Start()
    {
        //timecon.GetComponent<TimelineController>();
    }

    private void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {   
            
            if(LookAtTrigger)
            {
                Look.GetComponent<LookAtObject>().lookAtIndex = LookAtIndx;
                Look.GetComponent<LookAtObject>().Looking = true;

                if(AltInteractor != null)
                AltInteractor.GetComponent<Collider>().enabled = false;

            }

            if (timeline != null)
            timeline.Play();

            if (sound != null)
            sound.Play();

            if (animator != null)
            animator.SetTrigger("Triggered");

            
            //&& DialogueScript.IsTalkingNow
            if (IsAuto)
            {
                

                if (AssociatedInteractor.GetComponent<DialogueScriptJH>() != null)
                AssociatedInteractor.GetComponent<DialogueScriptJH>().DialogueInit();

                AssociatedInteractor.GetComponent<Collider>().enabled = false;
                
                
            }
        }
        
    }
    
  
}
