using UnityEngine;
using System.Collections;
using Valve.VR;

public class Movement : MonoBehaviour {

    //public GameObject player;

    SteamVR_Controller.Device device;
    public SteamVR_TrackedObject controller;

    Vector2 touchpad;

    private float sensitivityX = 1.5f;
    private Vector3 playerPos;

	// Use this for initialization
	void Start () {
        //controller = gameObject.GetComponent<SteamVR_TrackedObject>();
	
	}
	
	// Update is called once per frame
	void Update () {
        device = SteamVR_Controller.Input((int)controller.index);
        //If finger is on touchpad
        if(device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            //Reading the values from touchpad
            touchpad = device.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);

            //Move based on the y input of the touchpad
            if(touchpad.y > 0.2 || touchpad.y < -0.2)
            {
                transform.position -= transform.forward * Time.deltaTime * (touchpad.y * 5f);
            }

            //Rotate based on x input of the touchpad
            if(touchpad.x > 0.3f || touchpad.x < -0.3f)
            {
                transform.Rotate(0, touchpad.x * sensitivityX, 0);
            }
        }
	}
}
