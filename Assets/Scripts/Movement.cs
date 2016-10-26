﻿using UnityEngine;
using System.Collections;
using Valve.VR;

public class Movement : MonoBehaviour {

    //Headbobbing variables
    public bool Headbobbing;
    public Transform lookingDir;
    public GameObject camera;
    private float[] posData;
    private int i = 0;
    private int count = 0;

    //Variables used for steam devices
    SteamVR_Controller.Device device;
    public SteamVR_TrackedObject controller;
    private Vector2 touchpad;


    private float movementSpeed = 4f;
    private float sensitivityX = 1.1f;
    private Vector3 playerPos;
    private Vector3 newCameraPosition;
    

    //Velocity variables for movement
    private float initialVelocity = 0.0f;
    private float finalVelocity = 2.5f;
    private float currentVelocity = 0.0f;
    private float accelerationRate = 5.0f;
    private float decelerationRate = 10.0f;

    //Variables for rotation velocity
    private float initialRotationVelocity = 0.0f;
    private float finalRotationVelocity = 1.0f;
    private float currentRotationVelocity = 0.0f;
    private float rotationAccelerationRate = 2.0f;
    private float rotationDecelerationRate = 10.0f;

    // Use this for initialization
    void Start () {
        posData = new float[] {0.1012f,0.1014f,0.1010f,0.1003f,0.0997f,0.0995f,0.0992f,0.0988f,0.0989f,0.0995f,0.1002f,0.1007f,0.1013f,0.1018f,0.1018f,0.1012f,0.1003f,0.0996f,0.0994f,0.0994f,0.0993f,0.0990f
    ,0.0987f,0.0982f,0.0985f,0.0995f,0.1007f,0.1011f,0.1007f,0.0992f};


    }

    // Update is called once per frame
    void Update () {
        device = SteamVR_Controller.Input((int)controller.index);

        


        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            //Reading the values from touchpad
            touchpad = device.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);

            //Move based on the y input of the touchpad
            if(touchpad.y > 0.2 || touchpad.y < -0.2)
            {
                currentVelocity += (accelerationRate * Time.deltaTime);
                
                //Headbobbing stuff (Really weird atm)
                if (Headbobbing)
                {
                    for(int i = 0; i < posData.Length - 1;)
                    {
                        camera.transform.position = new Vector3(transform.position.x, transform.position.y + posData[count] * 10, transform.position.z);
                        newCameraPosition = camera.transform.position;
                        newCameraPosition.y = camera.transform.position.y;
                        if (count < 29){
                            count++;
                        }
                        else{
                            count = 0;
                        }
                        if(i >= posData.Length){
                            i = 0;
                        }
                        else {
                            i++;
                        }
                    }
                }
                //transform.position -= transform.forward * Time.deltaTime * (touchpad.y * movementSpeed);
            }
            
            
            
            //Rotate based on x input of the touchpad
            if (touchpad.x > 0.3f || touchpad.x < -0.3f)
            {
                currentRotationVelocity += (rotationAccelerationRate * Time.deltaTime);
            }
        }
        else
        {
            currentVelocity -= decelerationRate * Time.deltaTime;
            currentRotationVelocity -= rotationDecelerationRate * Time.deltaTime;
        }
        currentVelocity = Mathf.Clamp(currentVelocity, initialVelocity, finalVelocity);
        transform.position += lookingDir.transform.forward * Time.deltaTime * currentVelocity * touchpad.y;

        currentRotationVelocity = Mathf.Clamp(currentRotationVelocity, initialRotationVelocity, finalRotationVelocity);
        transform.Rotate(0,currentRotationVelocity * touchpad.x, 0);
    }
}
