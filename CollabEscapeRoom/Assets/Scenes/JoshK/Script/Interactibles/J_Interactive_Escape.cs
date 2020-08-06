using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class J_Interactive_Escape : J_InteractiveObject
{
    public GameObject CreditsDirector;

    public override void ExecuteInteractiveAction()
    {
        gameObject.tag = "Untagged";
        J_UIManager.TheUI.MainCamera.SetActive(true);
        J_UIManager.TheUI.MainCanvas.GetComponent<AudioSource>().enabled = true;
        CreditsDirector.SetActive(true);
        StartCoroutine(J_AudioManager.GlobalSFXManager.FadeOut(J_AudioManager.GlobalSFXManager.gameObject.GetComponent<AudioSource>(), 3));
    }
}