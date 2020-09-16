using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelControl : MonoBehaviour
{

    public GameObject CupboardDoor1;
    public GameObject CupboardDoor2;

    public AudioSource Unlock;
    public AudioSource DoorSFX;

    public int[] result, correctCombination;

    public void Start()
    {
        result = new int[] { 0, 0, 0 ,0 };
        correctCombination = new int[] { 2, 1, 0, 3 };
        InteractiveAngel.RotatedAng += CheckResults;
    }

    public void CheckResults(string AngelName, int number)
    {
        switch (AngelName)
        {
            case "Angel1":
                result[0] = number;
                break;

            case "Angel2":
                result[1] = number;
                break;

            case "Angel3":
                result[2] = number;
                break;

            case "Angel4":
                result[3] = number;
                break;

        }

        if (result[0] == correctCombination[0] && result[1] == correctCombination[1] && result[2] == correctCombination[2] && result[3] == correctCombination[3])
        {
            Debug.Log("Opened");
            CupboardDoor1.GetComponentInParent<Animator>().SetBool("Isopen", false);
            CupboardDoor2.GetComponentInParent<Animator>().SetBool("Isopen", false);
            DoorSFX.Play();
            Unlock.Play();
            CupboardDoor1.GetComponent<InteractiveDoorJH>().NeedsItem = false;
            CupboardDoor2.GetComponent<InteractiveDoorJH>().NeedsItem = false;
            //gameObject.GetComponentInChildren<Animator>().SetBool("Solved", true);
            //Invoke("Deactivate", 2f);
            //PadlockCam.enabled = false;
            //PlayerCam.enabled = true;
            //Cursor.visible = false;
            //Cursor.lockState = CursorLockMode.Locked;
            //Chest.GetComponent<InteractiveChest>().enabled = false;
            //Chest.transform.tag = "Untagged";
            //Chest.GetComponent<Animation>().Play();
            //UIManager.TheUI.LockInput(true);
            //Tooltip.text = "";
        }
    }

    public void OnDestroy()
    {
        AngelRot.RotatedAng -= CheckResults;
    }

   
}
