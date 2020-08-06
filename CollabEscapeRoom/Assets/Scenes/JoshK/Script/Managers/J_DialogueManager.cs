using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_DialogueManager : MonoBehaviour
{
    public static J_DialogueManager Manager;
    private J_DialogueScript TheDialogueScript;

    void Start()
    {
        Manager = this;
        TheDialogueScript = gameObject.GetComponent<J_DialogueScript>();
    }

    public bool IsTalking()
    {
        if (TheDialogueScript.IsTalking) return true;

        return false;
    }

    public void Dialogue(string dialogue, AudioClip audio)
    {
        if (TheDialogueScript.IsTalking) return;
        TheDialogueScript.AddBranch(dialogue, audio);
    }
}
