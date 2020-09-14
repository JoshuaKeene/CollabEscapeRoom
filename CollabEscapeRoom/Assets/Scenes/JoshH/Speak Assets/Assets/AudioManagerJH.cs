using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerJH : MonoBehaviour
{
    public static AudioManagerJH GlobalSFXManager;

    public GameObject LeSFXPrefab;

    void Start()
    {
        GlobalSFXManager = this;
    }


    internal AudioSource PlaySFX(AudioClip leClip)
    {
        GameObject GO = Instantiate(LeSFXPrefab);
        GO.GetComponent<AudioSource>().clip = leClip;
        GO.GetComponent<AudioSource>().Play();
        Destroy(GO, GO.GetComponent<AudioSource>().clip.length);
        return GO.GetComponent<AudioSource>();
    }
}
