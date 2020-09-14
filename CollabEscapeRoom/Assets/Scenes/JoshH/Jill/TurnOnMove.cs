using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TurnOnMove : MonoBehaviour
{

   
    // Start is called before the first frame update
    public void WalkOn()
    {
        gameObject.GetComponent<MoveTo>().enabled = true;
        gameObject.GetComponent<NavMeshAgent>().enabled = true;
        gameObject.GetComponent<NavMeshAgent>().speed = 1;
    }

    public void TurnOffBetty()
    {
        gameObject.GetComponent<MoveTo>().enabled = false;
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);
        gameObject.GetComponent<DialogueScriptJH>().StartingDialogueBranch = 6;
        gameObject.GetComponent<DialogueScriptJH>().DialogueInit();
    }
}
