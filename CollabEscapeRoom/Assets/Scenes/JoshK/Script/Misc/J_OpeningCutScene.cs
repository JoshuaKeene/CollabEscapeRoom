using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_OpeningCutScene : MonoBehaviour
{
    internal bool OpeningCutsceneRunning = false;
    
    public void Footstep()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(J_AudioManager.GlobalSFXManager.FootStep);
    }

    public void CamAnimation()
    {
        gameObject.GetComponent<Animator>().Play(J_AnimationManager.OpeningCS_Cam);
    }

    public void IntroCutSceneStart()
    {
        OpeningCutsceneRunning = true;
    }

    public void IntroCutSceneEnd()
    {
        OpeningCutsceneRunning = false;
    }
}
