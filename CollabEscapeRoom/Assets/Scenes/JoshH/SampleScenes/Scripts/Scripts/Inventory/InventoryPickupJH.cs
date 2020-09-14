using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPickupJH : MonoBehaviour
{
    [SerializeField]
    public InventoryItem AssociatedItem;

    private void Start()
    {
        if(gameObject.GetComponent<DocumentScriptJH>() != null)
        {
            gameObject.GetComponent<InventoryPickupJH>().AssociatedItem.DocText = gameObject.GetComponent<DocumentScriptJH>().DocText;
        }
    }
}

