using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveWheelchair : InteractiveObjectJH
{
    public AudioSource wheelchairFX;
    public override void ExecuteInteractiveAction()
    {
        base.ExecuteInteractiveAction();
        
        GetComponent<Animator>().SetBool("Moved", false);
        GetComponent<InteractiveWheelchair>().enabled = false;
        wheelchairFX.Play();
    }
}
