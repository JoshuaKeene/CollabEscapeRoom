using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFeedback : MonoBehaviour
{
    public AudioSource feedbackSound;

    public void FeedbackSound()
    {
        if(!feedbackSound.isPlaying)
        feedbackSound.Play();
    }
}
