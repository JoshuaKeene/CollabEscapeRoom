using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameFinTrigger : MonoBehaviour
{
    //public GameObject DIR;
    
    public bool IsAuto;

    public TimelineController timecon;


    public PlayableDirector timeline;

    public GameObject player;
    public GameObject Betty;
    public GameObject BettySpawn;
    public GameObject AssociatedInteractor;
    public GameObject Camera;
    private void Start()
    {
        timecon.GetComponent<TimelineController>();
    }


    private void OnTriggerEnter(Collider other)
    {

        


        print("1");
        if (other.CompareTag("Player"))
        {
            
            print("2");
            //&& DialogueScript.IsTalkingNow
            if (IsAuto)
            {

                print("3");
                //AssociatedInteractor.GetComponent<DialogueScript>().DialogueInit();
                
                AssociatedInteractor.GetComponent<Collider>().enabled = false;
                timecon.Play();
                Camera.GetComponent<CinemachineBrain>().enabled = true;
                Betty.GetComponent<MoveTo>().GameEnd = true;
                Betty.transform.position = BettySpawn.transform.position;
                UIManagerJH.TheUI.PlayerInactive();
                //StartCoroutine(BettyAnim());

                player.SetActive(false);
            }
        }

    }
    private IEnumerator BettyAnim()
    {
        yield return new WaitForSeconds(3);
        Betty.GetComponent<MoveTo>().enabled = false;
        Betty.GetComponent<Animator>().SetBool("End", true);
    }
}
