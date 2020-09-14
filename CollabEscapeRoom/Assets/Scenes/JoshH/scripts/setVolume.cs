using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class setVolume : MonoBehaviour
{
    public AudioMixer Mixer;
    public string MixGroup;
    

    public void SetLevel(float SliderVal)
    {
        Mixer.SetFloat( MixGroup , Mathf.Log10 (SliderVal) * 20);
    }


}
