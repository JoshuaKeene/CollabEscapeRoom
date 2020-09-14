using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsTextEnterExit : MonoBehaviour
{
    public Color Red;
    private Color OGcolour;
    public bool notInChildren;

    public Vector3 NewScale;
    private Vector3 OGscale;

    public AudioSource Select;
    

    private void Awake()
    {
        if (NewScale == null || NewScale == new Vector3(0, 0, 0))
        {
            NewScale = new Vector3(1.1f, 1.1f, 1.1f);
        }
        if (notInChildren)
        {
            OGcolour = gameObject.GetComponentInChildren<Text>().color;
            OGscale = gameObject.GetComponentInChildren<Text>().transform.localScale;
        }
        else
        {
            OGcolour = gameObject.GetComponent<Text>().color;
            OGscale = gameObject.GetComponent<Text>().transform.localScale;
        }
    }

    public void OnEnter()
    {
        if (notInChildren)
        {
            gameObject.GetComponentInChildren<Text>().color = Red;
            gameObject.GetComponentInChildren<Text>().transform.localScale = NewScale;
            
        }
        else
        {
            gameObject.GetComponent<Text>().color = Red;
            gameObject.GetComponent<Text>().transform.localScale = NewScale;
        }
        
        Select.Play();
    }

    public void OnExit()
    {
        if (notInChildren)
        {
            gameObject.GetComponentInChildren<Text>().color = OGcolour;
            gameObject.GetComponentInChildren<Text>().transform.localScale = OGscale;
        }
        else
        {
            gameObject.GetComponent<Text>().color = OGcolour;
            gameObject.GetComponent<Text>().transform.localScale = OGscale;
        }
      
    }
}
