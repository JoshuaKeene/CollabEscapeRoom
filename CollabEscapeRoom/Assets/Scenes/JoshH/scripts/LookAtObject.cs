using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class LookAtObject : MonoBehaviour
{
    // Start is called before the first frame update

    public bool Looking;
    public float lookTime;
  
    public bool coroutineReady;
    public float speed;
    bool lookBack;
    public int lookAtIndex;

    public List<GameObject> lookAts = new List<GameObject>();
    Quaternion currentRot;
    // Use this for initialization
     void Start()
    {
        coroutineReady = true;
      
    }

    private void Update()
    {
        if(Looking)
        {
            GetComponentInParent<FirstPersonController>().enabled = false;
            FollowTarget();
            if(coroutineReady)
            StartCoroutine(StopLooking(lookTime));
        }
        else if(lookBack)
        {
            LookBack();
            StartCoroutine(LookDone(lookTime));
        }
       
    }
    public void FollowTarget()
    {

        //transform.LookAt(Hangman.transform);
        Quaternion lookOnLook =
        Quaternion.LookRotation(lookAts[lookAtIndex].transform.position - transform.position);

        transform.rotation =
        Quaternion.Slerp(transform.rotation, lookOnLook, Time.deltaTime * speed);

    }
    public void LookBack()
    {
        

        transform.rotation =
        Quaternion.Slerp(transform.rotation, currentRot, Time.deltaTime * (speed*2));

    }
    IEnumerator StopLooking(float time)
    {
        currentRot = transform.rotation;
        coroutineReady = false;
        yield return new WaitForSeconds(time/2);
        Looking = false;
        lookBack = true;
        
        
    }
    IEnumerator LookDone(float time)
    {

        yield return new WaitForSeconds(time/3);
        GetComponentInParent<FirstPersonController>().enabled = true;
        coroutineReady = true;
        lookBack = false;
    }
}


