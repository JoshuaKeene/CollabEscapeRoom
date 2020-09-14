using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManagerJH: MonoBehaviour
{

    public List<string> SFXNames = new List<string>();
    public List<AudioClip> SFXClips = new List<AudioClip>();

    public Dictionary<string, AudioClip> LeSFX_Lib = new Dictionary<string, AudioClip>();

    public GameObject SFXPrefab;

    public static SFXManagerJH TheSFXGuy;

    private void Start()
    {
        for (int i = 0; i < SFXNames.Count; i++)
        {
            LeSFX_Lib.Add(SFXNames[i], SFXClips[i]);
        }

        TheSFXGuy = this;
    }

    public void PlaySFX(string X)
    {
        if (LeSFX_Lib.ContainsKey(X))
        {
            GameObject GO = Instantiate(SFXPrefab);
            GO.GetComponent<AudioSource>().clip = LeSFX_Lib[X];
            GO.GetComponent<AudioSource>().Play();

            Destroy(GO, GO.GetComponent<AudioSource>().clip.length);

        }
    }






}
