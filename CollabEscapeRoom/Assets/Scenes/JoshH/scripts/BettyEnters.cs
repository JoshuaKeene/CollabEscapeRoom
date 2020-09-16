using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BettyEnters : MonoBehaviour
{
    public GameObject Betty;
    
    private void OnTriggerEnter(Collider other)
    {
          if (other.gameObject == Betty)
        {
                Betty.GetComponent<MoveTo>().enabled = false;
                Betty.GetComponent<NavMeshAgent>().enabled = false;
                Betty.GetComponent<Animator>().SetBool("End", true);
                gameObject.GetComponent<Collider>().enabled = false;
        }
    }

 
    
}
