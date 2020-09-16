using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PcPointerEnter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool MM;
    public bool SM;
    public bool KM;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!MM && !SM && !KM)
        {
            TestJH.tester.CurrentCharIndex = TestJH.tester.Characters.IndexOf(gameObject.GetComponent<Button>());
            TestJH.tester.UpdateGlow();
        }
        else if(MM)
        {
           
        }
        else if (SM)
        {

           
        }
        else if (KM)
        {
            switch (gameObject.name)
            {
                case "btn1":
                    KeyPadManager.KPman.currentIndx = 0;
                    break;
                case "btn2":
                    KeyPadManager.KPman.currentIndx = 1;
                    break;
                case "btn3":
                    KeyPadManager.KPman.currentIndx = 2;
                    break;
                case "btn4":
                    KeyPadManager.KPman.currentIndx = 3;
                    break;
                case "btn5":
                    KeyPadManager.KPman.currentIndx = 4;
                    break;
                case "btn6":
                    KeyPadManager.KPman.currentIndx = 5;
                    break;
                case "btn7":
                    KeyPadManager.KPman.currentIndx = 6;
                    break;
                case "btn8":
                    KeyPadManager.KPman.currentIndx = 7;
                    break;
                case "btn9":
                    KeyPadManager.KPman.currentIndx = 8;
                    break;
                case "btn0":
                    KeyPadManager.KPman.currentIndx = 9;
                    break;
                case "ButtonEnter":
                    KeyPadManager.KPman.currentIndx = 10;
                    break;
                case "ButtonClear":
                    KeyPadManager.KPman.currentIndx = 11;
                    break;

                default:
                break;
            }
            KeyPadManager.KPman.UpdateKeys();
        }
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if(SM)
        {
           
        }
    }
}
