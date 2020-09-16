using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thump : MonoBehaviour
{
    public AudioSource Thump;

    public void PlayThump()
    {
        Thump.Play();
    }
}
