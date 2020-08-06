using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_OpenHutDoor : MonoBehaviour
{
    //Associated door
    public GameObject Door;
    //Stored door state
    private bool Open = false;
    
    void Update()
    {
        //Update and open/close door based on flag post state
        if (gameObject.GetComponent<J_Interactive_FlagPost>().Raised == true && Open == true)
        {
            Open = false;
            Door.GetComponent<Animator>().Play(J_AnimationManager.HutDoor_Close); 
        }
        else if (gameObject.GetComponent<J_Interactive_FlagPost>().Raised == false && Open == false) 
        {
            Open = true;
            Door.GetComponent<Animator>().Play(J_AnimationManager.HutDoor_Open); 
        }
    }
}
