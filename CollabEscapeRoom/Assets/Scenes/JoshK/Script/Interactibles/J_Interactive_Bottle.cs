using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Interactive_Bottle : J_InteractiveObject
{
    [Header("Statue Link")]
    public GameObject Statue;
    internal bool Drunk;

    private MeshCollider BottleCollider;
    private MeshRenderer BottleRenderer;

    private static bool firstInteraction = true;

    private void Start()
    {
        BottleCollider = gameObject.GetComponent<MeshCollider>();
        BottleRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    public override void ExecuteInteractiveAction()
    {
        if (firstInteraction) { J_DialogueManager.Manager.Dialogue("Woah... That's some strong stuff.", null); firstInteraction = false; }

        BottleCollider.enabled = false;
        BottleRenderer.enabled = false;
        Drunk = true;

        Statue.tag = "Interactable";
        StartCoroutine("DrunkDuration");
        J_PostProcessManager.TheManager.ChromaticAberration_Drunk(true);

        J_AudioManager.GlobalSFXManager.PlaySFX(J_AudioManager.GlobalSFXManager.Drink, null);
    }

    public IEnumerator DrunkDuration()
    {
        yield return new WaitForSeconds(15f);
        
        if (Statue.GetComponent<J_InteractiveStatue>().Interacting)
        {
            StartCoroutine("DrunkDuration"); 
        }
        else
        {
            SoberUp();
        }
    }

    public void SoberUp()
    {
        Statue.tag = "Untagged";

        Drunk = false;
        BottleCollider.enabled = true;
        BottleRenderer.enabled = true;
        J_PostProcessManager.TheManager.ChromaticAberration_Drunk(false);
    }
}
