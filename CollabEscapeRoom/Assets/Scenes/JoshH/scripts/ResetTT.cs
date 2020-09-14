using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetTT : MonoBehaviour
{
    private Text Tooltip;

    private void Start()
    {
        Tooltip = GetComponent<Text>();
    }
    public void ResetTooltip()
    {
        Tooltip.text = "";
        Tooltip.color = new Color32(255, 255, 255, 0);
    }
}
