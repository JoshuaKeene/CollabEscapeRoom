using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class J_PauseMenu : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (J_UIManager.TheUI.PauseMenu.activeInHierarchy || J_UIManager.TheUI.OptionsMenu.activeInHierarchy)
            {
                if (J_UIManager.TheUI.PauseMenu.activeInHierarchy)
                {
                    ClosePauseMenu();
                    J_UIManager.TheUI.Background.GetComponent<Animator>().Play(J_AnimationManager.Background_FadeOut);
                    StartCoroutine("WaitForBackground");
                }
                else if (J_UIManager.TheUI.OptionsMenu.activeInHierarchy)
                {
                    OnClickBack();
                }
            }
            else if (!J_UIManager.TheUI.PauseMenu.activeInHierarchy)
            {
                //Checks with UI manager if any UIs active
                if (J_UIManager.TheUI.AreAnyUIsActive()) return;

                OpenPauseMenu();
                J_UIManager.TheUI.Background.GetComponent<Animator>().Play(J_AnimationManager.Background_FadeIn);
            }
        }
    }

    public void OnClickResume()
    {
        ClosePauseMenu();
        J_UIManager.TheUI.Background.GetComponent<Animator>().Play(J_AnimationManager.Background_FadeOut);
        StartCoroutine("WaitForBackground");
    }

    public void OnClickOptions()
    {
        J_UIManager.TheUI.OptionsMenu.SetActive(true);

        J_UIManager.TheUI.OptionsMenu.GetComponent<Animator>().Play(J_AnimationManager.OptionsMenu_Open);
        J_UIManager.TheUI.PauseMenu.GetComponent<Animator>().Play(J_AnimationManager.PauseMenu_Close);
        StartCoroutine("WaitForPauseCloseForOptions");
    }

    public void OnClickBack()
    {
        if (J_UIManager.TheUI.MainCanvas.GetComponent<J_MainMenu>().InMenu) return;

        J_UIManager.TheUI.OptionsMenu.GetComponent<Animator>().Play(J_AnimationManager.OptionsMenu_Close);
        StartCoroutine("WaitForOptionsCloseAnim");
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

    private void OpenPauseMenu()
    {
        J_UIManager.TheUI.PauseMenu.SetActive(true);

        J_UIManager.TheUI.PlayerHUD.SetActive(false);
        J_UIManager.TheUI.InputLockState(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        J_UIManager.TheUI.PauseMenu.GetComponent<Animator>().Play(J_AnimationManager.PauseMenu_Open);
    }

    private void ClosePauseMenu()
    {
        J_UIManager.TheUI.PauseMenu.GetComponent<Animator>().Play(J_AnimationManager.PauseMenu_Close);
        StartCoroutine("WaitForPauseCloseAnim");
    }

    private IEnumerator WaitForPauseCloseAnim()
    {
        yield return new WaitForSeconds(0.2f);
        J_UIManager.TheUI.PauseMenu.GetComponent<Animator>().Play(J_AnimationManager.Nothing);

        J_UIManager.TheUI.PauseMenu.SetActive(false);

        J_UIManager.TheUI.PlayerHUD.SetActive(true);
        J_UIManager.TheUI.InputLockState(true);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private IEnumerator WaitForOptionsCloseAnim()
    {
        yield return new WaitForSeconds(0.4f);
        J_UIManager.TheUI.OptionsMenu.GetComponent<Animator>().Play(J_AnimationManager.Nothing);

        J_UIManager.TheUI.OptionsMenu.SetActive(false);
        J_UIManager.TheUI.PauseMenu.SetActive(true);
        J_UIManager.TheUI.OptionsMenu.GetComponent<Image>().enabled = false;

        J_UIManager.TheUI.PauseMenu.GetComponent<Animator>().Play(J_AnimationManager.PauseMenu_Open);
    }

    private IEnumerator WaitForPauseCloseForOptions()
    {
        yield return new WaitForSeconds(0.3f);
        J_UIManager.TheUI.PauseMenu.GetComponent<Animator>().Play(J_AnimationManager.Nothing);
        J_UIManager.TheUI.PauseMenu.SetActive(false);
    }

    private IEnumerator WaitForBackground()
    {
        yield return new WaitForSeconds(0.3f);
        J_UIManager.TheUI.Background.GetComponent<Animator>().Play(J_AnimationManager.Nothing);
    }
}

