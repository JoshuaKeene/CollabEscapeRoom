using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactSound : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioSource HitSound;
    private bool SoundReady = true;

    private void Start()
    {
        HitSound = GetComponent<AudioSource>();
    }
    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Untagged"))
        {
            if (SoundReady)
            {
                HitSound.Play();
                SoundReady = false;
                StartCoroutine(SoundWait());
            }
        }

    }

    private IEnumerator SoundWait()
    {
        yield return new WaitForSeconds(1);
        SoundReady = true;
    }
}
