using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScriptJH : MonoBehaviour
{

    public float TextSpeed;

    public int StartingDialogueBranch;

    private Text DialogueText;
    private float CurTextInterval;

    private Queue<string> TextsToDisplay = new Queue<string>();

    private string TempText;
    private int CurCharIndex;
    public int CurrentBranch;

    private List<string> Branch_Text = new List<string>();
    private List<AudioClip> Branch_Audio = new List<AudioClip>();

    private static bool IsTalkingNow;

    

    public enum BranchType
    {
        TextOnly,
        TextAudio,
        Waiting,
        ChangeTextSpeed,
        Ending,
        EndingWithNewStartPoint
    }

    [System.Serializable]
    public struct BranchData
    {
        public BranchType branchType;
        public string branchText;
        public AudioClip branchClip;
    }

    public List<BranchData> DialogueBranches = new List<BranchData>();

    private string BufferText = "";

    internal string PlayerString;
    internal GameObject CharacterTalking;
    private AudioSource TheSFXPlaying;

    void Start()
    {
        DialogueText = GameObject.Find("Dialogue").GetComponent<Text>();

        for (int i = 0; i < DialogueBranches.Count; i++)
        {
            switch (DialogueBranches[i].branchType)
            {
                case BranchType.TextOnly:
                    Branch_Text.Add(DialogueBranches[i].branchText);
                    //Branch_Audio.Add(DialogueBranches[i].branchClip);
                    break;
                case BranchType.TextAudio:
                    Branch_Text.Add(DialogueBranches[i].branchText);
                    Branch_Audio.Add(DialogueBranches[i].branchClip);
                    break;
                case BranchType.Waiting:
                    Branch_Text.Add("***WAIT:" + DialogueBranches[i].branchText);
                    Branch_Audio.Add(DialogueBranches[i].branchClip);
                    break;
                case BranchType.ChangeTextSpeed:
                    Branch_Text.Add("***CHANGESPEED:" + DialogueBranches[i].branchText);
                    Branch_Audio.Add(DialogueBranches[i].branchClip);
                    break;
                case BranchType.Ending:
                    Branch_Text.Add("---");
                    Branch_Audio.Add(null);
                    break;
                case BranchType.EndingWithNewStartPoint:
                    Branch_Text.Add("---" + DialogueBranches[i].branchText);
                    Branch_Audio.Add(null);
                    break;

                default:
                    break;
            }

        }
    }


    void Update()
    {
        if (TextsToDisplay.Count > 0)
        {
            // Is it still typing?
            if (DialogueText.text != TempText)
            {
                // Typewriter Effect.
                CurTextInterval += Time.deltaTime;
                if (CurTextInterval > TextSpeed)
                {
                    CurTextInterval = 0;

                    DialogueText.text += TempText[CurCharIndex];
                    CurCharIndex++;
                }
            }
            else
            {
                // Pressing Jump will move on to the next item.
                if (!TheSFXPlaying)
                {
                    TextsToDisplay.Dequeue();

                    if (TextsToDisplay.Count > 0)
                    {
                        DialogueText.text = "";
                        CurCharIndex = 0;
                        TempText = TextsToDisplay.Peek();
                    }

                    MoveBranch();
                }

            }
        }
    }

    public void MoveBranch()
    {
        //Do we have more lines?
        if (Branch_Text.Count > CurrentBranch + 1)
        {

            if (Branch_Text[CurrentBranch + 1].Contains("***"))
            {
                float SecondsToWait = 0;

                if (Branch_Text[CurrentBranch + 1].Contains("NEXT"))
                {
                    // Do absolutely nothing.
                    CurrentBranch++;
                    Speak(Branch_Text[CurrentBranch], Branch_Audio[CurrentBranch]);

                }
                else if (Branch_Text[CurrentBranch + 1].Contains("WAIT:"))
                {
                    // Make holder Wait a couple of sec without doing anything

                    int INDX = Branch_Text[CurrentBranch + 1].IndexOf(":") + 1;
                    float SecString = (float)System.Convert.ToDouble(Branch_Text[CurrentBranch + 1].Replace("***WAIT:", ""));

                    SecondsToWait = SecString;
                }
                else if (Branch_Text[CurrentBranch + 1].Contains("CHANGESPEED:"))
                {
                    // Make holder Wait a couple of sec without doing anything

                    int INDX = Branch_Text[CurrentBranch + 1].IndexOf(":") + 1;
                    float SecString = (float)System.Convert.ToDouble(Branch_Text[CurrentBranch + 1].Replace("***CHANGESPEED:", ""));

                    TextSpeed = SecString;
                }

               
                CurrentBranch++;
                DialogueText.text = "";

                StartCoroutine(WaiterMoveBranch(SecondsToWait));
            }
            else if (Branch_Text[CurrentBranch + 1].Contains("---"))
            {
                // Branch end.
                EndDialogue();

                if (Branch_Text[CurrentBranch + 1].Length > 3)
                {
                    // New starting branch!
                    StartingDialogueBranch = System.Convert.ToInt16(Branch_Text[CurrentBranch + 1].Remove(0, 3));
                }
            }
            else
            {
                CurrentBranch++;
                Speak(Branch_Text[CurrentBranch], Branch_Audio[CurrentBranch]);

            }
        }
        else
        {
            EndDialogue();
        }

    }

    IEnumerator WaiterMoveBranch(float Sec)
    {
        yield return new WaitForSeconds(Sec);

        MoveBranch();
    }

    private void EndDialogue()
    {
        StartCoroutine(LeaveTextFor(1));

        DialogueScriptJH.IsTalkingNow = false;
    }

    internal void DialogueInit()
    {
        if (!DialogueScriptJH.IsTalkingNow && DialogueText.text == "")
        {
            DialogueScriptJH.IsTalkingNow = true;
            CurrentBranch = StartingDialogueBranch;

            if (Branch_Text[CurrentBranch].Contains("***NEXT"))
                CurrentBranch++;

            Speak(Branch_Text[CurrentBranch], Branch_Audio[CurrentBranch]);
        }
        
    }

    public void Speak(string Text, AudioClip LeClip = null)
    {
        TextsToDisplay.Enqueue(Text);

        DialogueText.text = "";
        CurCharIndex = 0;
        TempText = TextsToDisplay.Peek();

        if (LeClip)
        {
            TheSFXPlaying = AudioManagerJH.GlobalSFXManager.PlaySFX(LeClip);
        }
    }

    public IEnumerator LeaveTextFor(float time)
    {
        yield return new WaitForSeconds(time);
        DialogueText.text = "";
    }
}
