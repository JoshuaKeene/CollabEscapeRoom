using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CryptoTutorial : MonoBehaviour
{

    public Text Tooltip;
    public KeyCode CryptoKey = KeyCode.C;
    public bool AlreadyShown;
    private void Update()
    {
        if (Input.GetKeyDown(CryptoKey))
        {
            if(AlreadyShown)
            {
                StartCoroutine(TooltipReset());
            }
        }
    }

    public void CryptoTT()
    {
        if (!AlreadyShown)
        {
            Tooltip.enabled = true;
            
                Tooltip.text = "Press C to open Cryptogram";
            
            
            AlreadyShown = true;
            
        }
    }

    private IEnumerator TooltipReset()
    {
        yield return new WaitForSeconds(0.1f);
        Tooltip.text = "";
        
    }

    
}
