using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CryptoSolved : MonoBehaviour
{
    public Text Input1;
    public Text Input2;
    public Text Input3;
    public Text Input4;
    public Text Input5;
    public Text Input6;
    public Text Input7;

    public Text InfoText;

    private string Input1Answer = "A";
    private string Input2Answer = "U";
    private string Input3Answer = "G";
    private string Input4Answer = "U";
    private string Input5Answer = "S";
    private string Input6Answer = "T";
    private string Input7Answer = "A";

    private string Input1Answer2 = "a";
    private string Input2Answer2 = "u";
    private string Input3Answer2 = "g";
    private string Input4Answer2 = "u";
    private string Input5Answer2 = "s";
    private string Input6Answer2 = "t";
    private string Input7Answer2 = "a";
    private void Update()
    {
        if (gameObject.GetComponent<Animator>().GetBool("Open") == true)
        {
            if ((Input1.text == Input1Answer || Input1.text == Input1Answer2) && 
                (Input2.text == Input2Answer || Input2.text == Input2Answer2) && 
                (Input3.text == Input3Answer || Input3.text == Input3Answer2) && 
                (Input4.text == Input4Answer || Input4.text == Input4Answer2) &&
                (Input5.text == Input5Answer || Input5.text == Input5Answer2) &&
                (Input6.text == Input6Answer || Input6.text == Input6Answer2 )&&
                (Input7.text == Input7Answer || Input7.text == Input7Answer2))
            {
                InfoText.text = "That looks right. I should type this into the terminal";
            }

        }
    }
}
