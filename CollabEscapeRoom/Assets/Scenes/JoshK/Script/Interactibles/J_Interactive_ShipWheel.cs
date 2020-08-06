using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Interactive_ShipWheel : J_InteractiveObject
{
    
    
    public override void ExecuteInteractiveAction()
    {
        gameObject.GetComponent<Animator>().Play(J_AnimationManager.CombinationWheel, -1, 0f);
        gameObject.GetComponent<MeshCollider>().enabled = false;
        StartCoroutine("WaitForAnim");
    }

    public IEnumerator WaitForAnim()
    {
        yield return new WaitForSeconds(11f);
        gameObject.GetComponent<MeshCollider>().enabled = true;
        gameObject.GetComponent<Animator>().Play(J_AnimationManager.Nothing, -1, 0f);
    }

    
}
