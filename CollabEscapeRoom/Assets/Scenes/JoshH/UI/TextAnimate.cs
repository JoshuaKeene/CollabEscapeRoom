using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAnimate : MonoBehaviour
{
    public Color original;
    private Vector3 Prevector = new Vector3 (1, 1, 1);
    public AudioSource HB;
    
    
    // Start is called before the first frame update
    public Text AnimText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TextAnim()
    {
        AnimText.GetComponent<Animator>().enabled = true;
        HB.Play();
    }

    public void TextAnimStop()
    {
        AnimText.GetComponent<Animator>().enabled = false;
        AnimText.GetComponent<Text>().color = original;
        AnimText.GetComponent<RectTransform>().localScale = Prevector ;
        HB.Stop();
        
    }
}
