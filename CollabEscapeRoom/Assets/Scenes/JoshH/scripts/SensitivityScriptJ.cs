using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SensitivityScriptJ : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject FPS;
    public void SetSensitvity(float SliderVal)
    {
        //FPS.GetComponent<MouseLook>().XSensitivity = 4 * SliderVal;
        //FPS.GetComponent<MouseLook>().YSensitivity = 4 * SliderVal;
    }
}
