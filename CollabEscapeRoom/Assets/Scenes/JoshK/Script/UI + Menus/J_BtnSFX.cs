using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(EventTrigger))]
[RequireComponent(typeof(AudioSource))]
public class J_BtnSFX : MonoBehaviour
{
    private Button TheButton;
    private AudioSource Audio;

    private void Start()
    {
        TheButton = gameObject.GetComponent<Button>();
        Audio = gameObject.GetComponent<AudioSource>();
    }

    public void OnHover()
    {
        if (!TheButton.interactable || !TheButton.enabled) return;
        Audio.PlayOneShot(J_AudioManager.GlobalSFXManager.OnHoverClick);
    }

    public void OnClick()
    {
        if (!TheButton.interactable || !TheButton.enabled) return;
        Audio.PlayOneShot(J_AudioManager.GlobalSFXManager.OnPressClick);
    }
}
