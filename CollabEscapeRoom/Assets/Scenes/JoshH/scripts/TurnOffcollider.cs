using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffcollider : MonoBehaviour
{
    public GameObject Trigger;


    private void OnTriggerEnter(Collider other)
    {

        Trigger.SetActive(false);



    }
}
