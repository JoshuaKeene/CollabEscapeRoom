using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_FadeLiftAudio : MonoBehaviour
{
    public void FadeAudio()
    {
        var LiftAudio = gameObject.transform.Find("Lift").gameObject.GetComponent<AudioSource>();

        StartCoroutine(J_AudioManager.GlobalSFXManager.FadeOut(LiftAudio, 1));
    }
}
