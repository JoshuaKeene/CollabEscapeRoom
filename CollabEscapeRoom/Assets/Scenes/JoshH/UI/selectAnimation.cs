using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectAnimation : MonoBehaviour
{
    private Animation HoverAnim;
    // Start is called before the first frame update
    void Start()
    {
        HoverAnim = GameObject.Find("PlayText").GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HoverAnimation()
    {
        HoverAnim.Play();
    }
}
