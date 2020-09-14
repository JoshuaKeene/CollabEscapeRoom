using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightJH : MonoBehaviour
{

    public bool FlashlightOn = false;

    public Sprite LightOn;
    public Sprite LightOff;

    public GameObject Light;
    public GameObject Pc;
    public GameObject CryptoCan;
    public GameObject FlashlightImage;

    public AudioSource FlashlightClick;

    
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        FlashlightToggle();
        
    }

    
    public void FlashlightToggle()
    {
        if (!UIManagerJH.TheUI.AreAnyUIIsActive())
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
               
                    FlashlightImage.SetActive(false);
                    FlashlightImage.SetActive(true);

                    if (FlashlightOn)
                    {
                        Light.SetActive(false);
                        FlashlightOn = false;
                        FlashlightImage.GetComponent<Image>().sprite = LightOff;
                    }

                    else
                    {
                        Light.SetActive(true);
                        FlashlightOn = true;
                        FlashlightImage.GetComponent<Image>().sprite = LightOn;
                    }
                    FlashlightClick.Play();
                   
                
            }
        }
    }
}
