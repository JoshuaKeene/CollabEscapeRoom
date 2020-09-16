using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveAngel : InteractiveObjectJH
{

    public AudioSource RotateSFX;
    private void Start()
    {
        coroutineReady = true;
        DirectionShown = 0;
    }
    public static event Action<string, int> RotatedAng = delegate { };

    private bool coroutineReady;

    private int DirectionShown;
    public override void ExecuteInteractiveAction()
    {
        base.ExecuteInteractiveAction();


        if (coroutineReady)
        {
            StartCoroutine(RotateAngel());
            RotateSFX.Play();
        }

        StartCoroutine(ActivateInXSec(0.5f));

    }

    private IEnumerator RotateAngel()
    {
        coroutineReady = false;

        for (int i = 0; i < 10; i++)
        {
            transform.Rotate(0f, -9f, 0f);
            yield return new WaitForSeconds(0.01f);
        }

        coroutineReady = true;

        DirectionShown ++;

        if (DirectionShown >= 4)
        {
            DirectionShown = 0;
        }

        RotatedAng(name, DirectionShown);
    }

}
