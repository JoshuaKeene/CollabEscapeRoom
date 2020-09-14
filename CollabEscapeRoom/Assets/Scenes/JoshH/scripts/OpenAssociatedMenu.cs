using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAssociatedMenu : MonoBehaviour
{
    public GameObject AssociatedMenu;
    public GameObject OtherMenu;
    public void OpenMenu()
    {
        AssociatedMenu.SetActive(true);
        OtherMenu.SetActive(false);
    }
}
