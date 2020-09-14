using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelRot : MonoBehaviour
{
    public static event Action<string, int> RotatedAng = delegate { };

    private bool coroutineReady;

    private int DirectionShown;

    private void Start()
    {
        coroutineReady = true;
        DirectionShown = 0;
    }

    private void OnMouseDown()
    {
        Debug.Log("poo");
        if (coroutineReady)
        {
            StartCoroutine("RotateWheel");
        }
    }
    private void OnMouseEnter()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (coroutineReady)
            {
                StartCoroutine("RotateWheelBack");
            }
        }
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

        DirectionShown += 1;

        if (DirectionShown > 4)
        {
            DirectionShown = 0;
        }

        RotatedAng(name, DirectionShown);
    }

    private IEnumerator RotateAngelBack()
    {
        coroutineReady = false;

        for (int i = 0; i < 10; i++)
        {
            transform.Rotate(0f, 9f, 0f);
            yield return new WaitForSeconds(0.01f);
        }

        coroutineReady = true;

        DirectionShown -= 1;

        if (DirectionShown > 0)
        {
            DirectionShown = 4;
        }

        RotatedAng(name, DirectionShown);
    }
}
