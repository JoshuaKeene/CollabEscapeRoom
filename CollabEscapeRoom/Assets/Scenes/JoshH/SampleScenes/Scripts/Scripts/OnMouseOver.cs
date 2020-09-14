using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnMouseOver : MonoBehaviour
{
    // Start is called before the first frame update

      OnMouseOver()
    {
        GameObject.Find("HoveredItemImage").GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
    }
}
