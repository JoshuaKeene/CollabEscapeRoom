﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class J_SkullLockManager : MonoBehaviour
{
    public GameObject SkullLockPannel;
    private GameObject InteractingChest;
    public GameObject FPSCharacter;

    public void OpenUI()
    {
        //Get reference to the GaemObject being interacted with
        var ray = FPSCharacter.GetComponentInChildren<Camera>().ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3))
        {
            if (hit.transform)
            {
                InteractingChest = hit.transform.gameObject;
            }
        }

        J_UIManager.TheUI.MainCamera.SetActive(true);

        //Disable PlayerHUD
        J_UIManager.TheUI.PlayerHUD.SetActive(false);
        J_UIManager.TheUI.CurItemFrame.SetActive(false);
        J_UIManager.TheUI.ExitHint("Q", true);
        //Enable Lock UI
        SkullLockPannel.SetActive(true);
        //Enable Camera
        InteractingChest.GetComponent<J_Interactive_SkullLock>().ChestCam.SetActive(true);
        //Lock Player
        FPSCharacter.GetComponentInChildren<Camera>().enabled = false;
        //Lock Character
        J_UIManager.TheUI.InputLockState(false);
        //Set Focal Length
        J_PostProcessManager.TheManager.SetFocalDistanceLow();
    }

    public void CloseUI()
    {
        //Disable Lock UI
        SkullLockPannel.SetActive(false);
        //Disable Camera
        InteractingChest.GetComponent<J_Interactive_SkullLock>().ChestCam.SetActive(false);
        //Unlock Player
        FPSCharacter.GetComponentInChildren<Camera>().enabled = true;
        //Lock Character
        J_UIManager.TheUI.InputLockState(true);
        //Enable PlayerHUD
        J_UIManager.TheUI.PlayerHUD.SetActive(true);
        J_UIManager.TheUI.CurItemFrame.SetActive(true);
        J_UIManager.TheUI.ExitHint("Q", false);
        //Set Focal Length
        J_PostProcessManager.TheManager.SetFocalDistanceDefault();

        J_UIManager.TheUI.MainCamera.SetActive(false);
    }

    #region Button Functions

    public void On01EyeBtnClick()
    {
        //Call function from Interactive_SkullLock script
        InteractingChest.GetComponent<J_Interactive_SkullLock>().BtnClick_01();
    }

    public void On02EyeBtnClick()
    {
        //Call function from Interactive_SkullLock script
        InteractingChest.GetComponent<J_Interactive_SkullLock>().BtnClick_02();
    }

    public void On03EyeBtnClick()
    {
        //Call function from Interactive_SkullLock script
        InteractingChest.GetComponent<J_Interactive_SkullLock>().BtnClick_03();
    }

    public void On04EyeBtnClick()
    {
        //Call function from Interactive_SkullLock script
        InteractingChest.GetComponent<J_Interactive_SkullLock>().BtnClick_04();
    }

    public void On05EyeBtnClick()
    {
        //Call function from Interactive_SkullLock script
        InteractingChest.GetComponent<J_Interactive_SkullLock>().BtnClick_05();
    }

    public void On06EyeBtnClick()
    {
        //Call function from Interactive_SkullLock script
        InteractingChest.GetComponent<J_Interactive_SkullLock>().BtnClick_06();
    }

    #endregion
}
