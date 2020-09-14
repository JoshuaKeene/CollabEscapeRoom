using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class InteractorJH : MonoBehaviour
{

    public float InteractionLength;

    public GameObject RaycastOrigin;

    public Text Tooltip;

    public bool RaycastReady = true;

    //private Color TargetObjectOriginalColor;
    //public Color Red;

    public KeyCode interactInput = KeyCode.E;

    private enum RaycastObject
    {
        Nothing,
        Interactable,
        Physical,
        Pickupable,
        Document
    }
    private RaycastObject LastRaycastedObject;
    public GameObject TargetObject;

    public AudioSource Pickup;

    private GameObject PhysicalObject;
    public GameObject HoldOrigin;
    public float ThrowStrength;

    public GameObject Cryptogram;
    public GameObject Ded1;
    public GameObject Ded2;
    public GameObject StorageTrigger;

    public AudioSource Scare;
    public GameObject bear;

    public GameObject NewDoc;
    public AudioSource Scribble;

    public PlayableDirector BearDir;
    public static InteractorJH TheInteractor;

    void Start()
    {
        TheInteractor = this;
        LastRaycastedObject = RaycastObject.Nothing;
    }

    public void Update()
    {
        RaycastHit hit;
        
        if(LastRaycastedObject == RaycastObject.Nothing)
        {
            Tooltip.gameObject.GetComponent<Animator>().SetBool("On", false);
            //Tooltip.text = "";
        }
        else
        {
            Tooltip.gameObject.GetComponent<Animator>().SetBool("On", true);
        }

        TargetObject = null;
        
        LastRaycastedObject = RaycastObject.Nothing;

        if (!PhysicalObject && !UIManagerJH.TheUI.AreAnyUIIsActive())
        {
           
            
                if (Physics.Raycast(RaycastOrigin.transform.position, transform.forward, out hit, InteractionLength))
                {

                    //Have I hit something? 
                    //If I have, I should get in this If.
                    if (hit.transform)
                    {
                        if (hit.collider.gameObject.GetComponent<HighlightJH>() != null)
                        {
                            hit.collider.gameObject.GetComponent<HighlightJH>().ChangeMat();
                        }

                        if (hit.transform.CompareTag("Interactable"))
                        {
                            TargetObject = hit.transform.gameObject;

                        if (TargetObject.GetComponent<InteractiveObjectJH>() != null)
                        {
                            if (TargetObject.GetComponent<InteractiveObjectJH>().CanBeInteractedWith)
                            {
                                LastRaycastedObject = RaycastObject.Interactable;

                                 Tooltip.text = "E " + TargetObject.GetComponent<InteractiveObjectJH>().Tooltip; 
                            }
                            else
                            {
                                Tooltip.text = "";
                            }
                        }

                        }
                        else if (hit.transform.CompareTag("Pickup"))
                        {
                            LastRaycastedObject = RaycastObject.Pickupable;
                            TargetObject = hit.transform.gameObject;
                        Tooltip.text = "E Pick Up";
                            
                        }
                        else if (hit.transform.CompareTag("Physical"))
                        {
                            LastRaycastedObject = RaycastObject.Physical;
                            TargetObject = hit.transform.gameObject;
                            Tooltip.text = "[RMB] Hold Object";
                        }
                        else if (hit.transform.CompareTag("Document"))
                        {
                            LastRaycastedObject = RaycastObject.Document;
                            TargetObject = hit.transform.gameObject;

                            if(TargetObject.GetComponent<JournalItem>() != null)
                            {
                             Tooltip.text = "E Take"; 
                        }
                            else
                            {
                           Tooltip.text = "E Read";
                        }
                            
                        }
                    }
                }
            
        }

        if (Input.GetKeyDown(interactInput))
        {
            if (LastRaycastedObject == RaycastObject.Interactable)
            {
                TargetObject.GetComponent<InteractiveObjectJH>().ExecuteInteractiveAction();
                InventoryManagerJH.TheInventory.UpdateInventory();
                //StartCoroutine(RayReset());
            }
            else if (LastRaycastedObject == RaycastObject.Pickupable)
            {
                InventoryManagerJH.TheInventory.AddItem(TargetObject.GetComponent<InventoryPickupJH>().AssociatedItem);
                Pickup.Play();
                TargetObject.SetActive(false);
                InventoryManagerJH.TheInventory.UpdateInventory();
                if (TargetObject.GetComponent<InventoryPickupJH>().AssociatedItem.Name == "Axe")
                {

                    StorageTrigger.SetActive(true);
                    
                }
            }
            else if (LastRaycastedObject == RaycastObject.Document)
            {
                if (UIManagerJH.TheUI.AreAnyUIIsActive()) return;

               
                
                

                if (TargetObject.gameObject != Cryptogram && TargetObject.gameObject != Ded1 && TargetObject.gameObject != Ded2)

                {
                    TargetObject.GetComponent<JournalItem>().AssociatedItem.DocText = TargetObject.GetComponent<DocumentScriptJH>().DocText;
                    JournalManager.JournalMan.AddItem(TargetObject.GetComponent<JournalItem>().AssociatedItem);
                    NewDoc.SetActive(true);
                    Scribble.Play();
                    TargetObject.SetActive(false);

                    if(TargetObject.gameObject == Cryptogram)
                    {
                        TargetObject.SetActive(false);
                    }
                }
                else
                {
                    DocumentManagerJH.TheManager.OpenDocumentPanel(TargetObject.GetComponent<DocumentScriptJH>());
                }

                
                
            }
            Tooltip.text = "";
            InventoryManagerJH.TheInventory.UpdateInventory();
        }


        //Physical object manipulation
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {

            //if im not holding anything i need to make some checks
            if(!PhysicalObject)
            {
                if(TargetObject)
                {
                    if(LastRaycastedObject == RaycastObject.Physical)
                    {
                        PhysicalObject = TargetObject;
                        PhysicalObject.GetComponent<Collider>().enabled = false;
                        PhysicalObject.GetComponent<Rigidbody>().isKinematic = true;
                        PhysicalObject.GetComponent<Rigidbody>().useGravity = false;
                        
                    }
                }
            }
            //If I AM holding something I probably need to throw it
            else
            {
                PhysicalObject.GetComponent<Collider>().enabled = true;
                PhysicalObject.GetComponent<Rigidbody>().isKinematic = false;
                PhysicalObject.GetComponent<Rigidbody>().useGravity = true;
                PhysicalObject.GetComponent<Rigidbody>().velocity = (transform.position + (transform.forward * ThrowStrength) - transform.position);
                PhysicalObject = null;
            }
        }

        if(PhysicalObject)
        {
            PhysicalObject.transform.position = Vector3.Lerp(PhysicalObject.transform.position, HoldOrigin.transform.position, 0.9f);
        }
    }



    //public IEnumerator RayReset()
    //{
    //    RaycastReady = false;
    //    yield return new WaitForSeconds(1);
    //    RaycastReady = true;
    //}

    
}
