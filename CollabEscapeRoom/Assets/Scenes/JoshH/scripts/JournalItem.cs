using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalItem : MonoBehaviour
{
    [SerializeField]
    public DocumentItem AssociatedItem;

    private void Start()
    {
        if (gameObject.GetComponent<DocumentScriptJH>() != null)
        {
            gameObject.GetComponent<JournalItem>().AssociatedItem.DocText = gameObject.GetComponent<DocumentScriptJH>().DocText;
        }
    }
}

