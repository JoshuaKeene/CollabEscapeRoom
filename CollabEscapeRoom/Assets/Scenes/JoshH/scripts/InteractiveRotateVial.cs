using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveRotateVial : InteractiveObjectJH
{
    public bool coroutineReady;
    public int DirectionShown;
    public GameObject OtherVial;
    public int spins;
    public int spinsMulti;
    
    public AudioSource rotateFX;
    public static event Action<string, int> RotatedVial = delegate { };
    // Start is called before the first frame update
    void Start()
    {
        coroutineReady = true;
        
    }
    public override void ExecuteInteractiveAction()
    {
        base.ExecuteInteractiveAction();


        if (coroutineReady)
        {
            if(OtherVial != null)
            OtherVial.GetComponent<InteractiveRotateVial>().StartCoroutine(RotateVial((spinsMulti), OtherVial));

            StartCoroutine(RotateVial(spins, gameObject));

            

            rotateFX.Play();
        }

        StartCoroutine(ActivateInXSec(0.5f));

    }
   

    public IEnumerator RotateVial(int spins, GameObject itemToSpin)
    { 
       
        coroutineReady = false;

        

        for (int i = 0; i < 10; i++)
        {
            itemToSpin.transform.Rotate(0f, -(spins * 9f), 0f); 
            yield return new WaitForSeconds(0.01f);
            
        }

        coroutineReady = true;

        itemToSpin.GetComponent<InteractiveRotateVial>().DirectionShown += spins;

       

        if (itemToSpin.GetComponent<InteractiveRotateVial>().DirectionShown == 4)
        {
            itemToSpin.GetComponent<InteractiveRotateVial>().DirectionShown = 0;
        }
        if(itemToSpin.GetComponent<InteractiveRotateVial>().DirectionShown == 5)
        {
            itemToSpin.GetComponent<InteractiveRotateVial>().DirectionShown = 1;
        }

       

        RotatedVial(itemToSpin.gameObject.name, itemToSpin.GetComponent<InteractiveRotateVial>().DirectionShown);
    }
}
