using UnityEngine;
using System.Collections;

public class InteractableItem : MonoBehaviour
{
    private Rigidbody rigidbody;

    private ControllerInteraction attachedWand;
    private Transform interactionPoint;
    private bool currentlyInteracting;

    private float velocityFactor = 20000f;
    private Vector3 posDelta;

    private float rotationFactor = 400f;
    private Quaternion rotationDelta;
    private float angle;
    private Vector3 axis;

    //Variables for lerping size of instantiated objects
    private Vector3 startScale;
    private float distance;

    //public GameObject worldPrefab;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        velocityFactor /= rigidbody.mass;
        rotationFactor /= rigidbody.mass;
        interactionPoint = new GameObject().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (attachedWand && currentlyInteracting)
        {
            posDelta = attachedWand.transform.position - interactionPoint.position;
            this.rigidbody.velocity = posDelta * velocityFactor * Time.fixedDeltaTime;

            rotationDelta = attachedWand.transform.rotation * Quaternion.Inverse(interactionPoint.rotation);
            rotationDelta.ToAngleAxis(out angle, out axis);

            if (angle > 180)
            {
                angle -= 360;
            }

            //Apply rotation force
            this.rigidbody.angularVelocity = (Time.fixedDeltaTime * angle * axis) * rotationFactor;
            //Extra adjustment to keep the object oriented in place (standing up)
            //this.transform.localRotation = Quaternion.Euler(0, this.transform.rotation.eulerAngles.y, 0); properly don't need this
        }
    }

    public void BeginInteraction(ControllerInteraction wand)
    {
        
        attachedWand = wand;
        interactionPoint.position = attachedWand.transform.position;
        interactionPoint.rotation = attachedWand.transform.rotation;

        interactionPoint.SetParent(transform, true);
        currentlyInteracting = true;
    }

    public void EndInteraction(ControllerInteraction wand)
    {
        if (wand == attachedWand)
        {
            attachedWand = null;
            currentlyInteracting = false;
        }

    }

    public bool IsInteracting()
    {
        return currentlyInteracting;
    }
}