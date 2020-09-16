using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalManager : MonoBehaviour
{

    public List<DocumentItem> Items;

   

    public int JournalLimit;
    public int journalIndex = 0;

    public List<GameObject> ItemSlots = new List<GameObject>();
    public List<GameObject> GlowSlots = new List<GameObject>();

    public GameObject IconsParent;
    public GameObject GlowParent;

    public Collider PaintingTrig;
    public GameObject InventoryPanel;
    public GameObject thisPanel;
    public GameObject PcPuzzlePanel;
    public Image selectedImg;
    public Text ReadText;


    public Sprite Empty;

    public Text NameTxt;


    public AudioSource InvNav;

    public static JournalManager JournalMan;



    public void Start()
    {

        JournalMan = this;

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
       
        UpdateDocuments();
    }

    private void Update()
    {
        

        if (InventoryPanel.GetComponent<Animator>().GetBool("Open") && thisPanel.activeInHierarchy)
        {

            if (Input.GetKeyDown(KeyCode.Return) && !DocumentManagerJH.TheManager.DocPanel.activeInHierarchy && ReadText.gameObject.activeInHierarchy)
            {
                DocumentManagerJH.TheManager.OpenDocumentPanel(JournalManager.JournalMan.Items[JournalManager.JournalMan.journalIndex].Image,
                    JournalManager.JournalMan.Items[JournalManager.JournalMan.journalIndex].Name, JournalManager.JournalMan.Items[JournalManager.JournalMan.journalIndex].DocText);
            }

        }
    }
   
    public void IndexDown()
    {
        if (journalIndex > 0)
        {
            journalIndex--;
            InvNav.Play();
            UpdateDocuments();
        }
    }
    public void SetIndex(int indx)
    {
        journalIndex = indx;
        InvNav.Play();
        UpdateDocuments();
    }

    public void Index()
    {
        if (journalIndex < JournalLimit - 1)
        {
            journalIndex++;
            InvNav.Play();
            UpdateDocuments();
        }
    }
   
    public void UpdateDocuments()
    {
        for (int i = 0; i < JournalLimit; i++)
        {
            ItemSlots[i].GetComponent<Image>().sprite = Empty;
            selectedImg.GetComponent<Image>().sprite = Empty;

        }

        for (int i = 0; i < Items.Count; i++)
        {
            ItemSlots[i].GetComponent<Image>().sprite = Items[i].Image;
        }

        for (int i = 0; i < JournalLimit; i++)
        {
            GlowSlots[i].SetActive(false);
        }
        GlowSlots[journalIndex].SetActive(true);

        if (journalIndex < Items.Count)
        {
            NameTxt.text = Items[journalIndex].Name;
            selectedImg.GetComponent<Image>().sprite = Items[journalIndex].Image;
            ReadText.gameObject.SetActive(true);
        }
        else
        {
            NameTxt.text = "Empty";
            ReadText.gameObject.SetActive(false);
            selectedImg.GetComponent<Image>().sprite = Empty;
        }

        
      

    }

    #region InventoryUtilities

    public void AddItem(DocumentItem X)
    {
        if (Items.Count == JournalLimit)
        {
           

            return;
        }
        Items.Add(X);


        if (X.Name == "Riddle In the toilet")
        {

            TestJH.tester.RiddleRead = true;

        }
        if (X.Name == "Letter from the Matron")
        {

            PaintingTrig.enabled = true;

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

 
    #endregion
}



[System.Serializable]
public class DocumentItem
{
    public string Name;
    public Sprite Image;

    [TextArea(1, 20)]
    public string DocText;




}