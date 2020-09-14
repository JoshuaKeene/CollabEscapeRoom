using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessManagerJH : MonoBehaviour
{
    public static PostProcessManagerJH PPMan;

    public bool Blurred;

    private PostProcessVolume PostProcessing;
    private DepthOfField DepthOfField;

    private float OriginalFocalDis = 3f;
    private float OriginalAperture = 5.6f;
    private float OriginalFocalLength = 50f;

    public void Start()
    {
        PPMan = this;

        PostProcessing = gameObject.GetComponent<PostProcessVolume>();
        DepthOfField = PostProcessing.profile.GetSetting<DepthOfField>();
    }

   public IEnumerator GradualBlur()
    {
        if (DepthOfField.focusDistance.value == OriginalFocalDis)
        {
            for (int i = 0; i < 20; i++)
            {

                DepthOfField.focusDistance.value -= 0.15f;
                yield return new WaitForSeconds(0.05f);

            }
            Blurred = true;
            if (DepthOfField.focusDistance.value <= 0)
            {
                DepthOfField.focusDistance.value = 0;
            }
        }
            
   }
    public IEnumerator UnBlur()
    {
        if (DepthOfField.focusDistance.value != OriginalFocalDis)
        {
            for (int i = 0; i < 20; i++)
            {

                DepthOfField.focusDistance.value += 0.15f;
                yield return new WaitForSeconds(0.05f);

            }
            Blurred = false;
            if (DepthOfField.focusDistance.value >= OriginalFocalDis)
            {
                DepthOfField.focusDistance.value = OriginalFocalDis;
            }
        }
    }

    public void StartUnblur()
    {
        StartCoroutine(UnBlur());
    }

    

}


