using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPlayerActive : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Playerr;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TurnPlayerON()
    {
        Playerr.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    public void invokeTPO()
    {
        Invoke("TurnPlayerON", 1);
    }
}
