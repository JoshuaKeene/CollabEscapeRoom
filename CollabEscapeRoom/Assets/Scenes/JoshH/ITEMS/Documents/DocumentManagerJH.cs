using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DocumentManagerJH : MonoBehaviour
{

    public GameObject DocPanel;
    public GameObject OverlayTxtPanel;
    public Text fontTypeTxt;

    public GameObject PcTrigger;

  

    public Sprite CandleRiddle;

    public Image DocOnScreen;
    public Text DocTextOnScreen;
    private string CachedDocText;

    public static DocumentManagerJH TheManager;

    public AudioSource Paper;

    public enum TextState
    {
        Appearing,
        Hiding,
        Opaque,
        Transparent
    }

    public TextState CurrentTextState;
    private float AlphaColor = 0;
    public float AlphaColorRate;

    public float TextBackgroundAlphaOffset;

    // Start is called before the first frame update
    void Start()
    {
        TheManager = this;
    }

    // Update is called once per frame
    void Update()
    {

        switch (CurrentTextState)
        {
            case TextState.Appearing:
                AlphaColor += AlphaColorRate;
                //DocTextOnScreen.supportRichText = true;
                if(AlphaColor>=1)
                {
                    AlphaColor = 1;
                    CurrentTextState = TextState.Opaque;
                    
                }

                DocTextOnScreen.GetComponent<CanvasGroup>().alpha = AlphaColor;
                OverlayTxtPanel.GetComponent<Image>().color = new Color(0, 0, 0,
                    AlphaColor - TextBackgroundAlphaOffset);
                break;

            case TextState.Hiding:
                AlphaColor -= AlphaColorRate;
                //DocTextOnScreen.supportRichText = false;
                if (AlphaColor <= 0)
                {
                    AlphaColor = 0;
                    CurrentTextState = TextState.Transparent;
                    
                }
                DocTextOnScreen.GetComponent<CanvasGroup>().alpha = AlphaColor;
                OverlayTxtPanel.GetComponent<Image>().color = new Color(0, 0, 0,
                    AlphaColor - TextBackgroundAlphaOffset);

                break;

        }

        if(DocPanel.activeInHierarchy)
        {


            if(Input.GetKeyDown(InteractorJH.TheInteractor.interactInput))
            {
                if(CurrentTextState == TextState.Opaque)
                {
                    HideText();
                    
                }
                else if (CurrentTextState == TextState.Transparent)
                {
                    ShowText();
                    
                }
            }

        }

        
    }


    #region Document UTILITIES
    public void CloseDocumentPanel()
    {

        HideText(true);
        DocPanel.SetActive(false);

        if(InventoryManagerJH.TheInventory.InventoryPanel.GetComponent<Animator>().GetBool("Open") == false)
        PostProcessManagerJH.PPMan.StartCoroutine("UnBlur");

        Paper.Play();


    }

    public void ShowText()
    {
        CurrentTextState = TextState.Appearing;
        fontTypeTxt.text = "Normal Text";
    }

    private void HideText(bool DisableImmediately = false)
    {
        fontTypeTxt.text = "Clear Text";
        if (DisableImmediately)
        {
            CurrentTextState = TextState.Transparent;
            AlphaColor = 0;
            DocTextOnScreen.GetComponent<CanvasGroup>().alpha = 0;
            OverlayTxtPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            
        }
        else
        {
            CurrentTextState = TextState.Hiding;
        }
    }

    internal void OpenDocumentPanel(Sprite Img, string DocName, string DocText)
    {

        
        DocPanel.SetActive(true);
        DocOnScreen.sprite = Img;
        CachedDocText = "<size=25>[" + DocName + "]</size>\n\n" + DocText;
        DocTextOnScreen.text = CachedDocText;

        if (InventoryManagerJH.TheInventory.InventoryPanel.GetComponent<Animator>().GetBool("Open") == false)
            PostProcessManagerJH.PPMan.StartCoroutine("GradualBlur");

        UIManagerJH.TheUI.PlayerInactive();

        DocTextOnScreen.GetComponent<CanvasGroup>().alpha = 0;
        OverlayTxtPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        CurrentTextState = TextState.Transparent;
        Paper.Play();

    }

    internal void OpenDocumentPanel(DocumentScriptJH DS)
    {
        OpenDocumentPanel(DS.DocSprite, DS.DocName, DS.DocText);
    }
    #endregion
}
