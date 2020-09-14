using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightJH : MonoBehaviour
{
    //private Color startcolor;
    //public Color Red;

    private Material StartMat;
    public Material NewMat;
  

    public GameObject Player;
    //private float MaxDist = 3;

    private void Awake()
    {
        
        if (gameObject.GetComponent<Renderer>() != null)
        {
            StartMat = GetComponent<Renderer>().material;
        }
        else
        {
            
                StartMat = GetComponentInChildren<Renderer>().material;
            
        }
    }

    private void Update()
    {
        if (Player.GetComponent<InteractorJH>() != null)
        {
            if (Player.GetComponent<InteractorJH>().TargetObject != gameObject)
            {
               
                ReturnMat();
                
                
            }
        }
        else if (Player.GetComponentInChildren<InteractorJH>() != null)
        {
            if (Player.GetComponentInChildren<InteractorJH>().TargetObject != gameObject)
            {
                ReturnMat();


            }
        
        }
    }

    //void OnMouseEnter()

    //{
    //    if (Vector3.Distance(Player.transform.position, transform.position) <= MaxDist)
    //    {
    //        if (gameObject.GetComponent<Renderer>() != null)
    //        {

    //            GetComponent<Renderer>().material = NewMat;
    //        }
    //        else
    //        {

    //            GetComponentInChildren<Renderer>().material = NewMat;
    //        }
    //    }
    //    else
    //    {
    //        if (gameObject.GetComponent<Renderer>() != null)
    //        {
    //            GetComponent<Renderer>().material = StartMat;
    //        }
    //        else
    //        {
    //            GetComponentInChildren<Renderer>().material = StartMat;
    //        }
    //    }

    //}
    //void OnMouseExit()
    //{
    //    ReturnMat();

    //}
    public void ChangeMat()
    {
        if (gameObject.GetComponent<Renderer>() != null)
        {

            gameObject.GetComponent<Renderer>().material = NewMat;
        }
        else
        {
            foreach (Renderer rd in GetComponentsInChildren<Renderer>())
            {
                if(rd.name != "WoodPlank")
                rd.GetComponent<Renderer>().material = NewMat;
            }
            
        }
    }

    public void ReturnMat()
    {
        if (gameObject.GetComponent<Renderer>() != null)
        {
            gameObject.GetComponent<Renderer>().material = StartMat;
        }
        else
        {
            foreach (Renderer rd in GetComponentsInChildren<Renderer>())
            {
                if (rd.name != "WoodPlank")
                    rd.GetComponent<Renderer>().material = StartMat;
            }
        }
    }
}
