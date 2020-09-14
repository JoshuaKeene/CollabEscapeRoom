using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VialControl : MonoBehaviour
{
    public int[] result, correctCombination;
    public AudioSource unlockFX;
    public List<GameObject> vials = new List<GameObject>();
    public void Start()
    {
        result = new int[] { 0, 2, 3, 0 };
        correctCombination = new int[] { 3, 0, 2, 1 };
        InteractiveRotateVial.RotatedVial += CheckResults;
    }

    public void CheckResults(string VialName, int number)
    {
        switch (VialName)
        {
            case "CVial1":
                result[0] = number;
                break;

            case "CVial2":
                result[1] = number;
                break;

            case "CVial3":
                result[2] = number;
                break;

            case "CVial4":
                result[3] = number;
                break;

        }

        if (result[0] == correctCombination[0] && result[1] == correctCombination[1] && result[2] == correctCombination[2] && result[3] == correctCombination[3])
        {
            GetComponent<InteractiveDoorJH>().NeedsItem = false;
            GetComponent<InteractiveDoorJH>().ExecuteInteractiveAction();
            unlockFX.Play();
            foreach (GameObject item in vials)
            {
                GetComponent<Collider>().enabled = false;
            }
        }
    }
}
