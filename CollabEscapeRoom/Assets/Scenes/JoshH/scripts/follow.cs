using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public float Offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(GameObject.Find("FPSController").GetComponent<Transform>().position.x, (GameObject.Find("FPSController").GetComponent<Transform>().position.y - Offset), GameObject.Find("FPSController").GetComponent<Transform>().position.z);
    }
}
