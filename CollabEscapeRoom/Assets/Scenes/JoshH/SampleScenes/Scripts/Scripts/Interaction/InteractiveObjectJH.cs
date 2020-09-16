using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveObjectJH : MonoBehaviour
{
    public string Tooltip;
    public bool CanBeInteractedWith;
    


    public virtual void ExecuteInteractiveAction()
    {
        CanBeInteractedWith = false;
    }
    public IEnumerator ActivateInXSec(float x)
    {
        yield return new WaitForSeconds(x);
        CanBeInteractedWith = true;
    }
}
