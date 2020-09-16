using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveRockChair : InteractiveObjectJH
{
    public override void ExecuteInteractiveAction()
    {
        base.ExecuteInteractiveAction();

        gameObject.GetComponent<Animator>().SetBool("Pushed", true);
        StartCoroutine(WaitForAnim());
        StartCoroutine(ActivateInXSec(6));
    }

    public IEnumerator WaitForAnim()
    {
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<Animator>().SetBool("Pushed", false);
    }
    
}
