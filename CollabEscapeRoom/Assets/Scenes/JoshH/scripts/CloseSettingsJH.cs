using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSettingsJH : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject Pause;
    public void CloseSetting()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
        
        if (!MainMenu.activeInHierarchy && !Pause.activeInHierarchy)
        {
            MainMenu.SetActive(true);
        }
        //UIManager.TheUI.PlayerInactive();
    }
}
