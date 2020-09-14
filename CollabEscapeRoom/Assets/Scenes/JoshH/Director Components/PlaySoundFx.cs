using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundFx : MonoBehaviour
{
    public GameObject AssociatedInteractor;
    public bool IsAuto;
    public AudioSource SFX;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        SFX.Play();
    }
}
