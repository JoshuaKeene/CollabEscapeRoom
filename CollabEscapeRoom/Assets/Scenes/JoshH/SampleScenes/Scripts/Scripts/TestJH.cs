using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TestJH : MonoBehaviour 
{
    public Text KeyPadText;
    public string Password;
    public Material Green;
    public Material Red;
    private Material Original;
    public GameObject LED;
    public GameObject rayScript;
    public AudioSource Correct;
    public AudioSource Incorrect;
    public GameObject Player;
    public GameObject HUD;
    public GameObject PC;

    public AudioSource beep;
    public Color StartCol;
    int arrayIndex;

    public Material newMat;

    public bool PasswordEntered;

    public GameObject KeyChest;

    public GameObject MatchChest;

    private bool SteamyEntered;
    private bool CandleEntered;

    public bool RiddleRead;
    private int riddleGuesses = 0;

    public int CurrentCharIndex;
    public List<Button> Characters = new List<Button>();
    public GameObject ButtonParent;
    public List<GameObject> GlowSlots = new List<GameObject>();
    public GameObject GlowParent;


    public static TestJH tester;

    ArrayList charList = new ArrayList();
    char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    void Start()
    {
        tester = this;
        CurrentCharIndex = 0;
        charList.AddRange(letters);
        KeyPadText.text = "";
        Original = LED.GetComponent<MeshRenderer>().material;

        for (int i = 0; i < ButtonParent.transform.childCount; i++)
        {
            Characters.Add(ButtonParent.transform.GetChild(i).GetComponent<Button>());
        }
        foreach (var item in Characters)
        {

            arrayIndex = Random.Range(0, charList.Count - 1);
            item.GetComponentInChildren<Text>().text = charList[arrayIndex].ToString();
            charList.RemoveAt(arrayIndex);


        }
        for (int i = 0; i < GlowParent.transform.childCount; i++)
        {
            GlowSlots.Add(GlowParent.transform.GetChild(i).gameObject);
        }

        Characters[Characters.Count - 1].gameObject.GetComponentInChildren<Text>().text = "ENTER";
        UpdateGlow();
    }

    private void Update()
    {
        if (gameObject.activeSelf == true)
        {
            //if (Input.GetButtonDown("Submit"))
            //{
            //    Checker();
            //}

            Leave();
            //AddChar();
            // if (Input.GetAxis("Index") < -0.1)
            //{
            //    if (!InputManager.IMan.IndexPressed)
            //    {
            //        MinusIndex();
            //    }
            //}
            //else if (Input.GetAxis("Index") > 0.1)
            //{
            //    if (!InputManager.IMan.IndexPressed)
            //    {
            //        AddIndex();
            //    }
            // }
            //else if (Input.GetAxis("IndexBig") > 0)
            //{
            //    if (!InputManager.IMan.IndexPressed)
            //    {
            //        MinusBigIndex();
            //    }
            //}
            //else if (Input.GetAxis("IndexBig") < 0)
            //{
            //    if (!InputManager.IMan.IndexPressed)
            //    {
            //        AddBigIndex();
            //    }
            //}
            
            
        }

       
    }
    public void MinusIndex()
    {
        if (CurrentCharIndex > 0)
        {
            CurrentCharIndex--;
            
        }
         if(CurrentCharIndex <= 0)
            {
                CurrentCharIndex = 0;
            }
        InputManager.IMan.IndexPressed = true;
        UpdateGlow();
    }

    public void AddIndex()
    {
        if (CurrentCharIndex < Characters.Count - 1)
        {
            CurrentCharIndex++;
            
        }
        if (CurrentCharIndex > Characters.Count-1)
            {
                CurrentCharIndex = Characters.Count - 1;
            }
        InputManager.IMan.IndexPressed = true;
        UpdateGlow();
    }
    public void MinusBigIndex()
    {
        if (CurrentCharIndex > 0)
        {
            CurrentCharIndex-= 16;
            
        }
        if (CurrentCharIndex <= 0)
        {
            CurrentCharIndex = 0;
        }
        InputManager.IMan.IndexPressed = true;
        UpdateGlow();
    }

    public void AddBigIndex()
    {
        if (CurrentCharIndex < Characters.Count - 1)
        {
            CurrentCharIndex += 16;
           
        }
        if (CurrentCharIndex > Characters.Count - 1)
        {
            CurrentCharIndex = Characters.Count - 1;
        }
        InputManager.IMan.IndexPressed = true;
        UpdateGlow();
    }

    public void UpdateGlow()
    {
        for (int i = 0; i < Characters.Count; i++)
        {
            GlowSlots[i].SetActive(false);
            Characters[i].GetComponentInChildren<Text>().color = Color.green;
        }
        GlowSlots[CurrentCharIndex].SetActive(true);
        Characters[CurrentCharIndex].GetComponentInChildren<Text>().color = Color.black;
    }
    public void Leave()
    {


        //if (Input.GetButtonDown("Cancel"))
        //{
        //    gameObject.SetActive(false);
        //    rayScript.GetComponent<MouseRaycastJH>().PcPuzzleOn = false;
        //    Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
        //    HUD.SetActive(true);
        //}
    }

    
    public void Checker()
    {

        
        
            if (KeyPadText.text == Password)
            {
                // PlayerSuccessSFX
                LED.GetComponent<MeshRenderer>().material = Green;
                KeyPadText.text = "";
                Correct.Play();
                StartCoroutine(LEDColourReset());
                PasswordEntered = true;
                PC.GetComponent<InteractivePC>().PcInteract();

            }

            else if (KeyPadText.text == "STEAMY")
            {
                if (!SteamyEntered)
                {
                    KeyChest.GetComponent<Animator>().SetTrigger("Open");
                    KeyChest.GetComponent<Collider>().enabled = false;
                }

                SteamyEntered = true;
                LED.GetComponent<MeshRenderer>().material = Green;
                KeyPadText.text = "";
                Correct.Play();
                StartCoroutine(LEDColourReset());
                PC.GetComponent<InteractivePC>().PcInteract();

            }

            else if (KeyPadText.text == "CANDLE")
            {
                if (!CandleEntered)
                {
                    MatchChest.GetComponent<Animator>().SetTrigger("Open");
                MatchChest.GetComponent<Collider>().enabled = false;
                }
                CandleEntered = true;
                LED.GetComponent<MeshRenderer>().material = Green;
                KeyPadText.text = "";
                Correct.Play();
                StartCoroutine(LEDColourReset());
                PC.GetComponent<InteractivePC>().PcInteract();

            }

            else
            {
                LED.GetComponent<MeshRenderer>().material = Red;
                KeyPadText.text = "";
                StartCoroutine(LEDColourReset());
                Incorrect.Play();

                if (RiddleRead)
                    riddleGuesses++;

                if (riddleGuesses == 6)
                {
                    PC.GetComponent<Renderer>().material = newMat;
                }
                //PlayFailSFX
            }
        }
    

    public void Backspace()
    {

            KeyPadText.text = KeyPadText.text.Remove(KeyPadText.text.Length - 1, 1);
        
    }



    public void ClickOnBtn()
    {
        if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text != "ENTER")
        {
            KeyPadText.text += UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
            beep.Play();
        }

        else
            Checker();
    }

    //public void AddChar()
    //{
    //    if(Input.GetButtonDown("Interact"))
    //    {
    //        if(Characters[CurrentCharIndex].gameObject.GetComponentInChildren<Text>().text != "ENTER")
    //        {
    //            KeyPadText.text += Characters[CurrentCharIndex].gameObject.GetComponentInChildren<Text>().text;
    //            beep.Play();
    //        }
    //        else
    //        {
    //            Checker();
    //        }
    //    }
        
    //}
  
 
    public IEnumerator LEDColourReset()
        {
                yield return new WaitForSeconds(1);
        LED.GetComponent<MeshRenderer>().material = Original;

        }

    public void Clear()
    {
        KeyPadText.text = "";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TestJH.tester.CurrentCharIndex = TestJH.tester.Characters.IndexOf(gameObject.GetComponent<Button>());
        TestJH.tester.UpdateGlow();
    }
}
