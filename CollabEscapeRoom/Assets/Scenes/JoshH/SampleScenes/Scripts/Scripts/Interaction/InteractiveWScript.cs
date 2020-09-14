using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveWScript : InteractiveObjectJH
{
    public override void ExecuteInteractiveAction()
    {
        base.ExecuteInteractiveAction();

       
        

            
        gameObject.GetComponent<DialogueScriptJH>().DialogueInit();

       

        StartCoroutine(ActivateInXSec(2));
        
    }

}
