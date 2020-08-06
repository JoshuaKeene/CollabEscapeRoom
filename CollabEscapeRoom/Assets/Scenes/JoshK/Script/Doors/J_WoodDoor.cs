using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_WoodDoor : MonoBehaviour
{
    //Associated puzzle
    public GameObject LinkedPodium;
    //Stored puzzle state variable
    private bool Opened = false;

    // Update is called once per frame
    void Update()
    {
        //Update stored variable based on puzzle state
        if (LinkedPodium.GetComponent<J_Interactive_Podium>().Solved && !Opened)
        {
            Opened = true;
            OpenDoor();
        }
    }

    public void OpenDoor()
    {
        //Open door
        gameObject.GetComponent<Animator>().Play(J_AnimationManager.WoodDoor_Open);
        gameObject.GetComponent<AudioSource>().PlayOneShot(J_AudioManager.GlobalSFXManager.WoodDoor);
    }
}
