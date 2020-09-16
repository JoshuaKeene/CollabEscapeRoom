using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManagerJH : MonoBehaviour
{

    public List<InventoryItem> Items;

    public List<string> DocumentNames;

    public int InventoryLimit;
    public int CurrentInventoryIndex = 0;

    public List<GameObject> ItemSlots = new List<GameObject>();
    public List<GameObject> GlowSlots = new List<GameObject>();

    public GameObject IconsParent;
    public GameObject GlowParent;

    public Text TutTT;

    public KeyCode InventoryButton = KeyCode.Tab;
   

    public GameObject InventoryPanel;
    public GameObject HUD;
    public GameObject MainMenu;

    public GameObject FolderImg;
    public GameObject CharacterPanel;
    public GameObject DocumentPanel;


    public GameObject Player;
    public GameObject PcPuzzlePanel;

    public GameObject CurrentItemFrame;
    public GameObject eqpSlotSprite;

    public Image CurrentItemImage;

    private int currentTabIndx;



    public Sprite Empty;

    public Text NameTxt;
    public Text DescTxt;

    public AudioSource InvNav;
  

    public GameObject Betty;
    public GameObject Fire;
    public GameObject Crate;

    public static InventoryManagerJH TheInventory;

   

    public void Start()
    {
        currentTabIndx = 0;
        TheInventory = this;

        for (int i = 0; i < IconsParent.transform.childCount; i++)
        {
            ItemSlots.Add(IconsParent.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < GlowParent.transform.childCount; i++)
        {
           
            GlowSlots.Add(GlowParent.transform.GetChild(i).gameObject);
        }

        foreach (var item in ItemSlots)
        {
            item.GetComponent<Image>().sprite = Empty;
        }
        InventoryPanel.SetActive(false);
    }

    private void Update()
    {
         
        if (InventoryPanel.GetComponent<Animator>().GetBool("Open"))
        {
            //if(Input.GetButtonDown("NextTab"))
            //{
            //    currentTabIndx++;
            //}
            //if (Input.GetButtonDown("PreviousTab"))
            //{
            //    currentTabIndx--;
            //}
            //if (currentTabIndx >= 2)
            //{
            //    currentTabIndx = 0;
            //}
            //else if (currentTabIndx <= -1)
            //{
            //    currentTabIndx = 1;
            //}
            TabControl();


            if (!DocumentPanel.activeInHierarchy)
            {
                //if (Input.GetAxis("Index") < -0.1)
                //{
                //    if (!InputManager.IMan.IndexPressed)
                //    {
                //        InputManager.IMan.IndexPressed = true;

                //        if (CurrentInventoryIndex > 0)
                //        {
                //            CurrentInventoryIndex--;
                //            InvNav.Play();
                //            UpdateInventory();
                //        }
                //    }
                //}
                //else if (Input.GetAxis("Index") > 0.1)
                //{
                //    if (!InputManager.IMan.IndexPressed)
                //    {
                //        InputManager.IMan.IndexPressed = true;

                //        if (CurrentInventoryIndex < InventoryLimit - 1)
                //        {
                //            CurrentInventoryIndex++;
                //            InvNav.Play();
                //            UpdateInventory();
                //        }
                //    }
                //}
                //else if (Input.GetAxis("IndexBig") > 0.1)
                //{
                //    if (!InputManager.IMan.IndexPressed)
                //    {
                //        InputManager.IMan.IndexPressed = true;

                        
                        
                //            CurrentInventoryIndex = (CurrentInventoryIndex - 3);
                //            InvNav.Play();
                //            if (CurrentInventoryIndex == -1)
                //            {
                //                CurrentInventoryIndex = InventoryLimit -1;
                //            }
                //            else if(CurrentInventoryIndex == -2)
                //            {
                //                CurrentInventoryIndex = InventoryLimit - 2;
                //            }
                //            else if (CurrentInventoryIndex == -3)
                //            {
                //                CurrentInventoryIndex = InventoryLimit - 3;
                //            }
                //            else if (CurrentInventoryIndex == -4)
                //            {
                //                CurrentInventoryIndex = InventoryLimit - 4;
                //            }
                //        UpdateInventory();
                        
                //    }
                //}
                //else if (Input.GetAxis("IndexBig") < -0.1)
                //{
                //    if (!InputManager.IMan.IndexPressed)
                //    {
                //        InputManager.IMan.IndexPressed = true;

                       
                //            CurrentInventoryIndex = (CurrentInventoryIndex + 3);
                //            InvNav.Play();
                //            if (CurrentInventoryIndex == InventoryLimit)
                //            {
                //                CurrentInventoryIndex = 0;
                //            }
                //            else if(CurrentInventoryIndex == InventoryLimit +1)
                //            {
                //                CurrentInventoryIndex = 1;
                //            }
                //            else if (CurrentInventoryIndex == InventoryLimit + 2)
                //            {
                //                CurrentInventoryIndex = 2;
                //            }
                //            else if (CurrentInventoryIndex == InventoryLimit + 3)
                //            {
                //                CurrentInventoryIndex = 3;
                //            }
                //        UpdateInventory();
                        
                //    }
                //}
            }
           
        }


        if (Input.GetKeyDown(InventoryButton))
        {
                if (UIManagerJH.TheUI.AreAnyUIIsActive() == false)
                {

                   
                         OpenInventory();
                         StartCoroutine(TooltipReset(0.1f));
                }
                

                else if (InventoryPanel.GetComponent<Animator>().GetBool("Open") == true && !DocumentManagerJH.TheManager.DocPanel.activeInHierarchy)
                {
                    
                    CloseInventory();
                }

                else if(InventoryPanel.GetComponent<Animator>().GetBool("Open") == true && DocumentManagerJH.TheManager.DocPanel.activeInHierarchy)
                {
                    DocumentManagerJH.TheManager.CloseDocumentPanel();
                }
            

            
        }

        

    }

    public void TabControl()
    {
        if (currentTabIndx == 2) currentTabIndx = 0;
        else if (currentTabIndx == -1) currentTabIndx = 1;
        
        if (currentTabIndx == 1)
        {
            GlowParent.SetActive(false);
            FolderImg.SetActive(false);
            CharacterPanel.SetActive(false);
            DocumentPanel.SetActive(true);
        }
        if (currentTabIndx ==0)
        {
            GlowParent.SetActive(true);
            FolderImg.SetActive(true);
            CharacterPanel.SetActive(true);
            DocumentPanel.SetActive(false);
        }
    }

    public void NextTab()
    {
        currentTabIndx++;
        UpdateInventory();

    }
    public void OpenInventory()
    {
        if(!InventoryPanel.activeInHierarchy) InventoryPanel.SetActive(true);
        InventoryPanel.GetComponent<Animator>().SetBool("Open",true);
        CurrentItemFrame.SetActive(false);
        UIManagerJH.TheUI.PlayerInactive();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        //HUD.SetActive(false);
        GetComponent<AudioSource>().Play();
        PostProcessManagerJH.PPMan.StartCoroutine("GradualBlur");
        UpdateInventory();
        JournalManager.JournalMan.UpdateDocuments();
        UIManagerJH.TheUI.ExitText.enabled = true;
    }

    public void CloseInventory()
    { 
        InventoryPanel.GetComponent<Animator>().SetBool("Open",false);
        GetComponent<AudioSource>().Play();
        UIManagerJH.TheUI.PlayerActive();
        HUD.SetActive(true);
        CurrentItemFrame.SetActive(false);
        UIManagerJH.TheUI.ExitText.enabled = false;

        PostProcessManagerJH.PPMan.StartCoroutine("UnBlur");
        if (CurrentInventoryIndex < Items.Count)
        {
            CurrentItemFrame.SetActive(true);
            CurrentItemImage.sprite = Items[CurrentInventoryIndex].Image;
        }
        else
        {
            CurrentItemFrame.SetActive(false);
        }


    }
    public void UpdateInventory()
    {
        for (int i = 0; i < InventoryLimit; i++)
        {
            ItemSlots[i].GetComponent<Image>().sprite = Empty;
            eqpSlotSprite.GetComponent<Image>().sprite = Empty;
           
        }

        for (int i = 0; i < Items.Count; i++)
        {
            ItemSlots[i].GetComponent<Image>().sprite = Items[i].Image;
        }

        for (int i = 0; i < InventoryLimit; i++)
        {
            GlowSlots[i].SetActive(false);
        }
        GlowSlots[CurrentInventoryIndex].SetActive(true);

        if(CurrentInventoryIndex < Items.Count)
        {
            NameTxt.text = Items[CurrentInventoryIndex].Name;
            DescTxt.text = Items[CurrentInventoryIndex].Description;
           eqpSlotSprite.GetComponent<Image>().sprite = Items[CurrentInventoryIndex].Image; 
            CurrentItemImage.sprite = Items[CurrentInventoryIndex].Image;
        } 
        else
        {
            NameTxt.text = "Empty";
            DescTxt.text = "No Item Selected";
            CurrentItemImage.sprite = Empty;
        }
       
        //document reading from inventory

        //Changing betty tooltips
        if (NameTxt.text == "Empty Syringe" || NameTxt.text == "Syringe - 1" || NameTxt.text == "Syringe - 2" || NameTxt.text == "Syringe - 3" || NameTxt.text == "Syringe - 4" || NameTxt.text == "Syringe - 5" || NameTxt.text == "Syringe - 6")
        {
            Betty.GetComponent<InteractiveBetty>().Tooltip = "Inject";
            Betty.GetComponent<DialogueScriptJH>().StartingDialogueBranch = 0;
        }
        else if (NameTxt.text == "Crowbar")
        {
            Betty.GetComponent<InteractiveBetty>().Tooltip = "Hit";
            Betty.GetComponent<DialogueScriptJH>().StartingDialogueBranch = 8;
        }
        else if (NameTxt.text == "Matchstick")
        {
            Betty.GetComponent<InteractiveBetty>().Tooltip = "Burn";
            Betty.GetComponent<DialogueScriptJH>().StartingDialogueBranch = 8;
        }
        else  
        {
            Betty.GetComponent<InteractiveBetty>().Tooltip = "Speak";
            Betty.GetComponent<DialogueScriptJH>().StartingDialogueBranch = 4;
        }
        //Changing fire tooltip
        if(NameTxt.text == "Fire extinguisher")
        {
            Fire.GetComponent<InteractiveFire>().Tooltip = "Extinguish";
        }
        else
        {
            Fire.GetComponent<InteractiveFire>().Tooltip = "Touch";
        }

        //Changing Crate Tooltip
        if(NameTxt.text == "Axe")
        {
            Crate.GetComponent<InteractiveCrateJH>().Tooltip = "Break Open";
        }

    }
    public void ClickOnBtn(int Val)
    {


        
        CurrentInventoryIndex = Val;
        UpdateInventory();
    


    }


    #region InventoryUtilities

    public void AddItem(InventoryItem X)
    {
        if(Items.Count == InventoryLimit)
        {
            print("InventoryFull");
            TutTT.text = "Inventory Full";
            StartCoroutine(TooltipReset(0.5f));
            
            return;
        }
        Items.Add(X);

        if (X.Name == "Bedroom Door Key")
        {
            TutTT.enabled = true;

            TutTT.text = "Press [TAB] to open Inventory";
        }
          
            

            
        
        if (X.Name == "Riddle In the toilet")
        {
            
            TestJH.tester.RiddleRead = true;

        }
        if (X.Name == "Syringe - 1")
        {
            TutTT.text = "Syringe Filled with liquid from Vial 1";
            StartCoroutine(TooltipReset(3f));
        }
        if (X.Name == "Syringe - 2")
        {
            TutTT.text = "Syringe Filled with liquid from Vial 2";
            StartCoroutine(TooltipReset(3f));
        }
        if (X.Name == "Syringe - 3")
        {
            TutTT.text = "Syringe Filled with liquid from Vial 3";
            StartCoroutine(TooltipReset(3f));
        }
        if (X.Name == "Syringe - 4")
        {
            TutTT.text = "Syringe Filled with liquid from Vial 4";
            StartCoroutine(TooltipReset(3f));
        }
        if (X.Name == "Syringe - 5")
        {
            TutTT.text = "Syringe Filled with liquid from Vial 5";
            StartCoroutine(TooltipReset(3f));
        }
        if (X.Name == "Syringe - 6")
        {
            TutTT.text = "Syringe Filled with liquid from Vial 6";
            StartCoroutine(TooltipReset(3f));
        }
    }

    public bool HasItem(string Name)
    {
        bool hasItem = false;
        foreach (var item in Items)
        {
            if (item.Name == name)
            {
                hasItem = true;
            }
        }
        return hasItem;

    }
    public void RemoveItem(string Name)
    {
        if (HasItem(Name))
        {
            int INDX = GetIndexOfItem(Name);
            Items.RemoveAt(INDX);
        }
    }

    public void RemoveItem(int Index)
    {
        Items.RemoveAt(Index);
    }

    public int GetIndexOfItem(string Name)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].Name == Name) return i;
        }
        return -1;
    }

    public Sprite GetSpriteOfItem(string Name)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].Name == Name) return Items[i].Image;
        }
         return null;
    }

    private IEnumerator TooltipReset(float time)
    {
        yield return new WaitForSeconds(time);
        TutTT.text = "";
    }
    #endregion
}

[System.Serializable]
public class InventoryItem
{
    public string Name;
    public string Description;
    public Sprite Image;
    public string DocText;




}