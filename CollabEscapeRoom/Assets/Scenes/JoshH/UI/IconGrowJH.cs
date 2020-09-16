using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconGrowJH : MonoBehaviour
{
    public void Grow()
    {
        GetComponent<RectTransform>().localScale = new Vector3(2.5f, 2.5f, 1);
    }

    public void Shrink()
    {
        GetComponent<RectTransform>().localScale = new Vector3(2, 2, 1);
    }

    
}
