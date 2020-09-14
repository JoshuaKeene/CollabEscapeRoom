using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockControl : MonoBehaviour
{
    public int[] result, correctCombination;


    public Camera PadlockCam;
    public Camera PlayerCam;

    public GameObject Chest;

    public GameObject Esc;

    public GameObject Crosshair;
    public Text IntTT;

    public AudioSource ChestUnlock;
    bool Solved;



    public void Start()
    {
        result = new int[] { 0, 0, 0 };
        correctCombination = new int[] { 3, 4, 3 };
        Rotate.Rotated += CheckResults;
    }
    private void Update()
    {
        if (PadlockCam.enabled)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (Solved)
                {
                    gameObject.GetComponentInChildren<Animator>().SetBool("Solved", true);
                    Invoke("Deactivate", 2f);

                    
                    Chest.GetComponent<InteractiveChestJH>().enabled = false;

                    Chest.transform.tag = "Untagged";
                    Chest.GetComponent<Animation>().Play();
                    
                    IntTT.text = "";

                    Invoke("SwitchCam",1);
                    Invoke("ChestUnlockPlay", 0.8f);
                }
                else
                {
                    gameObject.GetComponentInChildren<Animator>().SetTrigger("Wrong");
                }
            }
        }
    }

    public void CheckResults(string wheelName, int number)
    {
        switch (wheelName)
        {
            case "weel_01":
                result[0] = number;
                break;

            case "weel_02":
                result[1] = number;
                break;

            case "weel_03":
                result[2] = number;
                break;
        }


        if (result[0] == correctCombination[0] && result[1] == correctCombination[1] && result[2] == correctCombination[2])
        {
            Solved = true;
        }
        else
        {
            Solved = false;
        }
    }

    public void OnDestroy()
    {
        Rotate.Rotated -= CheckResults;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);

    }

    public void ChestUnlockPlay()
    {
        ChestUnlock.Play();
    }

    public void SwitchCam()
    {
        PadlockCam.enabled = false;
        PlayerCam.enabled = true;
        UIManagerJH.TheUI.PlayerActive();
        Crosshair.SetActive(true);
    }
}
