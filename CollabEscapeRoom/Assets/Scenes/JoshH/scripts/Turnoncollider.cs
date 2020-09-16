using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turnoncollider : MonoBehaviour
{
    public GameObject Trigger;
    

    private void OnTriggerEnter(Collider other)
    {

            Trigger.SetActive(true);
        


    }
}
