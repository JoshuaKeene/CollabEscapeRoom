using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive_Sphere : InteractiveObjectJH
{
    public override void ExecuteInteractiveAction()
    {
        base.ExecuteInteractiveAction();

        print("CLICK");

        StartCoroutine(ActivateInXSec(2));


    }

  
}
