using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_TooltipTrigger : MonoBehaviour
{
    [TextArea(1, 10)]
    public string Message;
    public float Duration;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !J_UIManager.TheUI.MainCanvas.GetComponent<J_MainMenu>().InMenu)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            J_UIManager.TheUI.TooltipMessage(Message, Duration);
        }
    }
}

