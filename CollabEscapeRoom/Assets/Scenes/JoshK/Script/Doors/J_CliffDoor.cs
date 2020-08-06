using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_CliffDoor : MonoBehaviour
{
    //Podium that needs to be solved
    public GameObject LinkedPodium;
    //Variable to store podium state
    private bool Opened = false;

    // Update is called once per frame
    void Update()
    {
        //Set stored variable based on state on podium
        if (LinkedPodium.GetComponent<J_Interactive_Podium>().Solved && !Opened)
        {
            Opened = true;
            OpenDoor();
        }
    }

    public void OpenDoor()
    {
        //Open door
        gameObject.GetComponent<Animator>().Play(J_AnimationManager.CliffDoor_Open);
        gameObject.GetComponent<AudioSource>().PlayOneShot(J_AudioManager.GlobalSFXManager.StoneDoor);
    }
}
