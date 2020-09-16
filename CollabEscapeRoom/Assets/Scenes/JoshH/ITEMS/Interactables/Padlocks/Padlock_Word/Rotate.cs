using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public static event Action<string, int> Rotated = delegate { };

    public bool coroutineAllowed;

    private int numberShown;

    public AudioSource PadlockSpin;

    private void Start()
    {
        coroutineAllowed = true;
        numberShown = 0;
    }

    private void OnMouseDown()
    {

        if(coroutineAllowed)
        {
           StartCoroutine( "RotateWheel");
        }
    }
    
    

    public IEnumerator RotateWheel()
    {
        coroutineAllowed = false;
        PadlockSpin.Play();
        for (int i = 0; i < 10; i++)
        {
            transform.Rotate(-6f,0f,0f);
            yield return new WaitForSeconds(0.01f);
        }

        
        coroutineAllowed = true;

        numberShown += 1;

        if(numberShown > 5)
        {
            numberShown = 0;
        }

        Rotated(name, numberShown);
    }

    public IEnumerator RotateWheelBack()
    {
        coroutineAllowed = false;
        PadlockSpin.Play();
        for (int i = 0; i < 10; i++)
        {
            transform.Rotate(6f, 0f, 0f);
            yield return new WaitForSeconds(0.01f);
        }

        coroutineAllowed = true;

        numberShown -= 1;

        if (numberShown < 0)
        {
            numberShown = 5;
        }

        Rotated(name, numberShown);
    }
}
