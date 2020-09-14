using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    public string Password;

    public Text KeypadText;




    public GameObject Door;
    public GameObject Door2;

    public AudioSource Beep;
    public AudioSource Correct;
    public AudioSource Fail;

    void Start()
    {
        KeypadText.text = "";
 
    }


    public void ClickOnBtn(string Val)
    {
        

        // if(KeypadText.text=="0000")KeypadText.text = "";
        KeypadText.text += Val;
        Beep.Play();

        
    }

    public IEnumerator PassCheckerCoRoutine()
    {
        yield return new WaitForSeconds(1);
        PassChecker();
        
    }

    public void PassChecker()
    {
        if (KeypadText.text == Password)
        {
            Correct.Play();
      
            Door.GetComponent<InteractiveDoorJH>().NeedsItem = false;
            Door.GetComponentInParent<Animator>().SetBool("Isopen", false);
            Door2.GetComponent<InteractiveDoorJH>().NeedsItem = false;
            UIManagerJH.TheUI.PlayerActive();
            gameObject.SetActive(false);
        }
        else
        {
            Fail.Play();
      
    
        }
        KeypadText.text = "";
        
    }
   

    public void Clear()
    {
        KeypadText.text = "";
    }

    public void Delete()
    {
        KeypadText.text = KeypadText.text.Remove(KeypadText.text.Length - 1, 1);
    }
}
