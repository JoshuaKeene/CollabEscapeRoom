using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveObjects : MonoBehaviour
{
    public List<GameObject> ObjectsToTurnOff;
    void Start()
    {
        foreach (GameObject item in ObjectsToTurnOff)
        {
            item.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
