using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public bool IndexPressed;
    public static InputManager IMan;
    public GameObject Flashlight;
    public Text EXITTEXT;
    public Text ReadTxt;

 

//flashlight tooltip
//All text components of controls in settings

    public enum eInputState
    {
        MouseKeyboard,
        Controler
    }

    public eInputState m_State = eInputState.MouseKeyboard;

    public List<Image> ControllerImgs = new List<Image>();
    public List<Image> PCImgs = new List<Image>();

    public void Start()
    {
        IMan = this;
        IndexPressed = false;

    }

    // Update is called once per frame
    public void Update()
    {

        //if (Input.GetAxis("IndexBig") == 0 && Input.GetAxis("Index") == 0)
        //{
        //    IndexPressed = false;
        //}

    }
    void OnGUI()
    {
        switch (m_State)
        {
            case eInputState.MouseKeyboard:
                if (isControlerInput())
                {
                    m_State = eInputState.Controler;
                    //flashlight tooltip = UP
                    
                    Flashlight.GetComponent<TutorialTT>().Tip = "Press DOWN to toggle flashlight";
                    EXITTEXT.text = "B Exit";
                    ReadTxt.text = "X Read";
                    //All text componenets in settings change
                    //All backspace change to B
                    //Tab changes to weird joystick button
                    foreach (Image item in ControllerImgs)
                    {
                        item.enabled = false;
                    }
                    foreach (Image item in PCImgs)
                    {
                        item.enabled = true;
                    }
                }
                break;
            case eInputState.Controler:
                if (isMouseKeyboard())
                {
                    m_State = eInputState.MouseKeyboard;

                    Flashlight.GetComponent<TutorialTT>().Tip = "Press F to toggle flashlight";
                    EXITTEXT.text = "BACKSPACE Exit";
                    ReadTxt.text = "ENTER Read";
                    //flashlight tooltip = F

                    //All text componenets in settings change
                    //All B change to Backspace
                    //Weird share button becomes Tab
                    foreach (Image item in ControllerImgs)
                    {
                        item.enabled = true;
                    }
                    foreach (Image item in PCImgs)
                    {
                        item.enabled = false;
                    }
                }
                break;
        }
    }

    //***************************//
    // Public member methods     //
    //***************************//

    public eInputState GetInputState()
    {
        return m_State;
    }

    //****************************//
    // Private member methods     //
    //****************************//

    private bool isMouseKeyboard()
    {
        // mouse & keyboard buttons
        if (Event.current.isKey ||
            Event.current.isMouse)
        {
            return true;
        }
        //// mouse movement
        //if (Input.GetAxis("Mouse X") != 0.0f ||
        //    Input.GetAxis("Mouse Y") != 0.0f)
        //{
        //    return true;
        //}
        return false;
    }

    private bool isControlerInput()
    {
        // joystick buttons
        if (Input.GetKey(KeyCode.Joystick1Button0) ||
           Input.GetKey(KeyCode.Joystick1Button1) ||
           Input.GetKey(KeyCode.Joystick1Button2) ||
           Input.GetKey(KeyCode.Joystick1Button3) ||
           Input.GetKey(KeyCode.Joystick1Button4) ||
           Input.GetKey(KeyCode.Joystick1Button5) ||
           Input.GetKey(KeyCode.Joystick1Button6) ||
           Input.GetKey(KeyCode.Joystick1Button7) ||
           Input.GetKey(KeyCode.Joystick1Button8) ||
           Input.GetKey(KeyCode.Joystick1Button9) ||
           Input.GetKey(KeyCode.Joystick1Button10) ||
           Input.GetKey(KeyCode.Joystick1Button11) ||
           Input.GetKey(KeyCode.Joystick1Button12) ||
           Input.GetKey(KeyCode.Joystick1Button13) ||
           Input.GetKey(KeyCode.Joystick1Button14) ||
           Input.GetKey(KeyCode.Joystick1Button15) ||
           Input.GetKey(KeyCode.Joystick1Button16) ||
           Input.GetKey(KeyCode.Joystick1Button17) ||
           Input.GetKey(KeyCode.Joystick1Button18) ||
           Input.GetKey(KeyCode.Joystick1Button19))
        {
            return true;
        }

        //if (Input.GetAxis("Horizontal") != 0.0f ||
        //    Input.GetAxis("Vertical") != 0.0f)
        //{
        //    return true;
        //}



        return false;
    }
}




    

    

