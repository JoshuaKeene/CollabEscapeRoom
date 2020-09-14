using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivePainting : InteractiveObjectJH
{

    public AudioSource Scrape;
    public override void ExecuteInteractiveAction()
    {
        base.ExecuteInteractiveAction();




        if (gameObject.GetComponent<Animator>().GetBool("IsMoved") == true)
        {
            gameObject.GetComponent<Animator>().SetBool("IsMoved", false);
            Scrape.Play();

        }
        else if (gameObject.GetComponent<Animator>().GetBool("IsMoved") == false)
        {
            gameObject.GetComponent<Animator>().SetBool("IsMoved", true);
            Scrape.Play();
        }

        StartCoroutine(ActivateInXSec(1));
    }
}
