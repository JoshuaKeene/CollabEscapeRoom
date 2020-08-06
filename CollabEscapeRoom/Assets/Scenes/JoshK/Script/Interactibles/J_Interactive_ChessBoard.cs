using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class J_Interactive_ChessBoard : J_InteractiveObject //NxF7 BxA3
{
    [Tooltip("Use board coordinates")]
    [Header("Solution")]
    public string KnightPosition;
    public string BishopPosition;

    [Header("Puzzle Variables")]
    public GameObject ChessboardCam;
    public GameObject Buttons;
    public GameObject RayBlocker;
    public GameObject PuzzleUI;
    public GameObject KnightSelection;
    public GameObject BishopSelection;
    public GameObject ChessKeyItem;

    private GameObject KnightBorder;
    private GameObject BishopBorder;

    private GameObject KnightImage;
    private GameObject BishopImage;

    private GameObject KnightText;
    private GameObject BishopText;

    private GameObject ActiveKnight;
    private GameObject ActiveBishop;

    private bool KnightPlaced = false;
    private bool BishopPlaced = false;

    private bool Solved = false;

    private int interactions = 0;

    private static bool firstInteraction = true;

    public override void ExecuteInteractiveAction()
    {
        base.ExecuteInteractiveAction();

        OpenUI();

        if (firstInteraction) { J_UIManager.TheUI.TooltipMessage("'W' and 'S' to select between pieces.\nClick on spaces to place selected piece.", 6); firstInteraction = false; }

        if (J_InventoryManager.TheInventory.HasItem("Knight")) { KnightImage.SetActive(true); KnightText.SetActive(false); }
        else if (!KnightPlaced) { KnightImage.SetActive(false); KnightText.SetActive(true); }
        if (J_InventoryManager.TheInventory.HasItem("Bishop")) { BishopImage.SetActive(true); BishopText.SetActive(false); }
        else if (!BishopPlaced) { BishopImage.SetActive(false); BishopText.SetActive(true); }

        print("CLICK");

        StartCoroutine(ActivateInXSec(2));    
    }

    public void Start()
    {
        KnightBorder = KnightSelection.transform.Find("Selector").gameObject;
        BishopBorder = BishopSelection.transform.Find("Selector").gameObject;

        KnightImage = KnightSelection.transform.Find("Image").gameObject;
        BishopImage = BishopSelection.transform.Find("Image").gameObject;

        KnightText = KnightSelection.transform.Find("Text").gameObject;
        BishopText = BishopSelection.transform.Find("Text").gameObject;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && ChessboardCam.activeInHierarchy)
        {
            CloseUI();
        }

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && ChessboardCam.activeInHierarchy)
        {
            J_AudioManager.GlobalSFXManager.PlaySFX(J_AudioManager.GlobalSFXManager.InventoryMove, null);
            KnightBorder.SetActive(true);
            BishopBorder.SetActive(false);
        }
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && ChessboardCam.activeInHierarchy)
        {
            J_AudioManager.GlobalSFXManager.PlaySFX(J_AudioManager.GlobalSFXManager.InventoryMove, null);
            BishopBorder.SetActive(true);
            KnightBorder.SetActive(false);
        }

        if (Buttons.transform.Find(KnightPosition).gameObject.transform.Find("Knight").gameObject.activeInHierarchy && Buttons.transform.Find(BishopPosition).gameObject.transform.Find("Bishop").gameObject.activeInHierarchy && !Solved)
        {
            Solved = true;
            StartCoroutine("Success");
        }
    }

    public void OnBtnClick(string ID)
    {
        interactions++;
        Hints();

        var buttonPressed = Buttons.transform.Find(ID).gameObject;

        if (buttonPressed.transform.Find("Bishop").gameObject.activeInHierarchy || buttonPressed.transform.Find("Knight").gameObject.activeInHierarchy)
        {
            J_UIManager.TheUI.TooltipMessage("Space occupied.", 2f);
            return;
        }

        if (ActiveKnight == null && KnightBorder.activeInHierarchy && KnightImage.activeInHierarchy)
        {
            J_AudioManager.GlobalSFXManager.PlaySFX(J_AudioManager.GlobalSFXManager.ChessMove, null);

            buttonPressed.transform.Find("Knight").gameObject.SetActive(true);
            ActiveKnight = buttonPressed.transform.Find("Knight").gameObject;

            J_InventoryManager.TheInventory.RemoveItem("Knight");
            KnightPlaced = true;
        }
        else if (ActiveBishop == null && BishopBorder.activeInHierarchy && BishopImage.activeInHierarchy)
        {
            J_AudioManager.GlobalSFXManager.PlaySFX(J_AudioManager.GlobalSFXManager.ChessMove, null);

            buttonPressed.transform.Find("Bishop").gameObject.SetActive(true);
            ActiveBishop = buttonPressed.transform.Find("Bishop").gameObject;

            J_InventoryManager.TheInventory.RemoveItem("Bishop");
            BishopPlaced = true;
        }
        else if (ActiveKnight != null && KnightBorder.activeInHierarchy && KnightImage.activeInHierarchy)
        {
            J_AudioManager.GlobalSFXManager.PlaySFX(J_AudioManager.GlobalSFXManager.ChessMove, null);

            buttonPressed.transform.Find("Knight").gameObject.SetActive(true);
            ActiveKnight.SetActive(false);
            ActiveKnight = buttonPressed.transform.Find("Knight").gameObject;
        }
        else if (ActiveBishop != null && BishopBorder.activeInHierarchy && BishopImage.activeInHierarchy)
        {
            J_AudioManager.GlobalSFXManager.PlaySFX(J_AudioManager.GlobalSFXManager.ChessMove, null);

            buttonPressed.transform.Find("Bishop").gameObject.SetActive(true);
            ActiveBishop.SetActive(false);
            ActiveBishop = buttonPressed.transform.Find("Bishop").gameObject;
        }
        else
        {
            J_UIManager.TheUI.TooltipMessage("Selection unavailable.", 2f);
        }
    }

    private void Hints()
    {
        if ((interactions == 5) && (!KnightImage.activeInHierarchy || !BishopImage.activeInHierarchy))
        {
            J_DialogueManager.Manager.Dialogue("I think I need to find all the missing pieces.", null);
            return;
        }
        
        if (interactions == 10)
        {
            J_DialogueManager.Manager.Dialogue("What did that note say? 'put those pieces back EXACTLY where they were'.", null);
        }
        else if (interactions == 40)
        {
            J_DialogueManager.Manager.Dialogue("The Castle on F4 stops the King from moving to F7 and F8.", null);
        }
        else if (interactions == 50)
        {
            J_DialogueManager.Manager.Dialogue("I just need to make sure the King can't stay where he is or move to D7 or D8.", null);
        }
        else if (interactions == 65)
        {
            J_DialogueManager.Manager.Dialogue("I think the Bishops goes on C6.", null);
        }
        else if (interactions == 75)
        {
            J_DialogueManager.Manager.Dialogue("I think the Knight goes on B7.", null);
        }
    }

    public void OpenUI()
    {
        if (J_UIManager.TheUI.AreAnyUIsActive()) return;

        J_UIManager.TheUI.MainCamera.SetActive(true);

        gameObject.tag = "Untagged";

        J_UIManager.TheUI.PlayerHUD.SetActive(false);
        J_UIManager.TheUI.CurItemFrame.SetActive(false);
        J_UIManager.TheUI.ExitHint("Q", true);
        J_UIManager.TheUI.InputLockState(false);
        J_UIManager.TheUI.FPSCamera.enabled = false;

        J_PostProcessManager.TheManager.SetFocalDistanceChessPuzzle();

        if(!Solved)
        {
            foreach (Transform child in Buttons.transform)
            {
                child.GetComponent<Button>().interactable = true;
            }
        }

        ChessboardCam.SetActive(true);
        PuzzleUI.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseUI()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        PuzzleUI.SetActive(false);
        ChessboardCam.SetActive(false);

        foreach (Transform child in Buttons.transform)
        {
            child.GetComponent<Button>().interactable = false;
        }

        J_PostProcessManager.TheManager.SetFocalDistanceDefault();

        J_UIManager.TheUI.FPSCamera.enabled = true;
        J_UIManager.TheUI.InputLockState(true);
        J_UIManager.TheUI.PlayerHUD.SetActive(true);
        J_UIManager.TheUI.CurItemFrame.SetActive(true);
        J_UIManager.TheUI.ExitHint("Q", false);

        gameObject.tag = "Interactable";

        J_UIManager.TheUI.MainCamera.SetActive(false);
    }

    public IEnumerator Success()
    {
        RayBlocker.GetComponent<Image>().raycastTarget = true;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<Animator>().Play(J_AnimationManager.Chessboard_KeyReveal);
        yield return new WaitForSeconds(1.5f);
        CloseUI();
        ChessKeyItem.tag = ("Pickupable");
    }

    public void SpringSFX()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(J_AudioManager.GlobalSFXManager.Spring);
    }

    public void ImpactSFX()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(J_AudioManager.GlobalSFXManager.Impact);
    }
}
