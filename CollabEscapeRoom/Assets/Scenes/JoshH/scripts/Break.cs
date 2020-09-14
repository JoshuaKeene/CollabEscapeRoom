using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CrackedBox;
    public GameObject Mallet;

    public AudioSource CrateBreak;
    public float breakForce;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void BreakBox()
    {
           GameObject Box = Instantiate(CrackedBox, transform.position, transform.rotation);
        foreach(Rigidbody rb in Box.GetComponentsInChildren<Rigidbody>())
        {
            Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
            rb.AddForce(force);
        }
            Mallet.GetComponent<Collider>().enabled = true;
        Mallet.GetComponent<MeshRenderer>().enabled = true;
        Mallet.GetComponent<Rigidbody>().useGravity = true;
        Mallet.GetComponent<Rigidbody>().isKinematic = false;
        CrateBreak.Play();
            Destroy(gameObject);
    }

 
}
