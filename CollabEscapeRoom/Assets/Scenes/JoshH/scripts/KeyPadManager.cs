using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPadManager : MonoBehaviour
{
    public static KeyPadManager KPman;
    public List<Button> Btns = new List<Button>();
    public int currentIndx;
    public Color normCol;
    public Color selectedCol;

    private void Start()
    {
        KPman = this;
        currentIndx = 0;
        UpdateKeys();
    }

    //private void Update()
    //{
    //    if(gameObject.activeInHierarchy)
    //    {
    //        if (Input.GetAxis("Index") < -0.1)
    //        {
    //            if (!InputManager.IMan.IndexPressed)
    //            {
    //                if (currentIndx != 0 && currentIndx != 3 && currentIndx != 6 && currentIndx != 10 && currentIndx != 11)
    //                    currentIndx--;

    //                else if (currentIndx == 2 || currentIndx == 5 || currentIndx == 8)
    //                {
    //                    currentIndx = 10;
    //                }
    //                else if (currentIndx == 10)
    //                {
    //                    currentIndx = 5;
    //                }
    //                else if (currentIndx == 11)
    //                {
    //                    currentIndx = 9;
    //                }
    //                InputManager.IMan.IndexPressed = true;
    //                UpdateKeys();
    //            }
    //        }
    //        else if (Input.GetAxis("Index") > 0.1)
    //        {
    //            if (!InputManager.IMan.IndexPressed)
    //            {
    //                if (currentIndx != 2 && currentIndx != 5 && currentIndx != 8 && currentIndx != 9 && currentIndx != 10)
    //                {
    //                    currentIndx++;
    //                }


    //                else if (currentIndx == 2 || currentIndx == 5 || currentIndx == 8)
    //                {
    //                    currentIndx = 10;
    //                }
    //                else if (currentIndx == 10)
    //                {
    //                    currentIndx = 3;
    //                }
    //                else if (currentIndx == 9)
    //                {
    //                    currentIndx = 11;
    //                }
    //                InputManager.IMan.IndexPressed = true;
    //                UpdateKeys();
    //            }
    //        }
    //        else if (Input.GetAxis("IndexBig") > 0.1)
    //        {
    //            if (!InputManager.IMan.IndexPressed)
    //            {
    //                if (currentIndx == 10)
    //                {
    //                    currentIndx = 2;
    //                }
    //                else if (currentIndx == 9)
    //                {
    //                    currentIndx = 7;
    //                }
    //                else
    //                    currentIndx -= 3;

    //                InputManager.IMan.IndexPressed = true;
    //                UpdateKeys();
    //            }
    //        }
    //        else if (Input.GetAxis("IndexBig") < -0.1)
    //        {
    //            if (!InputManager.IMan.IndexPressed)
    //            {
    //                if (currentIndx != 7)
    //                    currentIndx += 3;

    //                else
    //                {
    //                    currentIndx += 2;
    //                }
    //                InputManager.IMan.IndexPressed = true;
    //                UpdateKeys();
    //            }
    //        }

    //        if(Input.GetButtonDown("Interact"))
    //        {
    //            Btns[currentIndx].onClick.Invoke();
    //        }
    //    }
    //}

    public void UpdateKeys()
    {
        if(currentIndx <0 )
        {
            currentIndx = 0;
        }
        else if (currentIndx > 11)
        {
            currentIndx = 11;
        }
        foreach (Button item in Btns)
        {
            item.image.color = normCol;
        }
        Btns[currentIndx].image.color = selectedCol;
    }
}
