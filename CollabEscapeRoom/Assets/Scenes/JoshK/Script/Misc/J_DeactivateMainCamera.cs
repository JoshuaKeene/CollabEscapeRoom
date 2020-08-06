using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_DeactivateMainCamera : MonoBehaviour
{
    public GameObject MainCamera;
    public Camera FPSCharacter;
    
    private bool MainCamActive = true;

    // Update is called once per frame
    void Update()
    {
        if (FPSCharacter.enabled && MainCamActive)
        {
            MainCamActive = false;
            MainCamera.SetActive(false);
        }

        if (!FPSCharacter.enabled && !MainCamActive)
        {
            MainCamActive = true;
            MainCamera.SetActive(true);
        }
    }
}
