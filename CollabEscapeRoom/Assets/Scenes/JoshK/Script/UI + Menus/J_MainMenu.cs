using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_MainMenu : MonoBehaviour
{
    public GameObject ActivateGameStartDirector;
    public GameObject ActivateToOptionsDirector;
    public GameObject ActivateFromOptionsDirector;

    public AudioSource CanvasAudioSource;

    public bool InMenu;

    private void Start()
    {
        //InMenu = true;
        J_AudioManager.GlobalSFXManager.gameObject.GetComponent<AudioSource>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) { return; }
    }

    public void StartBtnClick()
    {
        StartCoroutine(J_AudioManager.GlobalSFXManager.FadeOut(CanvasAudioSource, 3));
        //AudioManager.GlobalSFXManager.gameObject.GetComponent<AudioSource>().enabled = true;
        Debug.Log("START");
        ActivateGameStartDirector.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        InMenu = false;
    }

    public void OptionsBtnClick()
    {
        Debug.Log("OPTIONS");
        ActivateToOptionsDirector.SetActive(true);
        Invoke("DeactivateBackDirector", 1);
    }

    public void BackBtnClick()
    {
        if (!J_UIManager.TheUI.MainCanvas.GetComponent<J_MainMenu>().InMenu) return;
        
        Debug.Log("BACK");
        ActivateFromOptionsDirector.SetActive(true);
    }

    public void QuitBtnClick()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }

    public void TestBtnClick()
    {
        Debug.Log("BUTTON_PRESSED");
    }

    public void DeactivateBackDirector()
    {
        ActivateFromOptionsDirector.SetActive(false);
    }
}

