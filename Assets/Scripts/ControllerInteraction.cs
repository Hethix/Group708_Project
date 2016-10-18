using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControllerInteraction : MonoBehaviour
{

    private Valve.VR.EVRButtonId menuButton = Valve.VR.EVRButtonId.k_EButton_ApplicationMenu;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private Valve.VR.EVRButtonId padButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;

    public SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;

    HashSet<InteractableItem> objectsHoveringOver = new HashSet<InteractableItem>();

    private InteractableItem closestItem;
    private InteractableItem interactingItem;

    // Use this for initialization
    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {

        if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }

        else
        {
            if (controller.GetPressDown(triggerButton))
            {
                float minDistance = float.MaxValue;

                float distance;
                foreach (InteractableItem item in objectsHoveringOver) //Goes through all the objects and detects which is closest to the controller
                {
                    distance = (item.transform.position - transform.position).sqrMagnitude;

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestItem = item;
                    }
                }
                interactingItem = closestItem;
                closestItem = null;

                if (interactingItem) //Starts interacting with the chosen item
                {
                    if (interactingItem.IsInteracting()) //this statement is used in order to grap an item in the other hand
                    {
                        interactingItem.EndInteraction(this);
                    }

                    interactingItem.BeginInteraction(this);
                }
            }

            if (controller.GetPressUp(triggerButton) && interactingItem != null)
            {
                interactingItem.EndInteraction(this); //Stops interaction with the item held
                interactingItem = null;
            }
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        InteractableItem collidedItem = collider.GetComponent<InteractableItem>();
        if (collidedItem)
        {
            objectsHoveringOver.Add(collidedItem);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        InteractableItem collidedItem = collider.GetComponent<InteractableItem>();
        if (collidedItem)
        {
            objectsHoveringOver.Remove(collidedItem);
        }
    }
}
