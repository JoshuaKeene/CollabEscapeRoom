using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseunlock : MonoBehaviour
    
{
    public GameObject HUD;
    public AudioSource HB;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MouseLock()
    { 
        HUD.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        HB.Stop();
    }
}
