using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverItem : MonoBehaviour

{
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HoverOverItem()
    {
        GameObject.Find("HoveredItemImage").GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
        GameObject.Find("HoveredItemImage").GetComponent<Image>().color = gameObject.GetComponent<Image>().color;

        GameObject.Find("ItemDescription").GetComponent<Text>().text = gameObject.GetComponentInChildren<Text>().text;
        //GameObject.Find("FPSController").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
    }
}
