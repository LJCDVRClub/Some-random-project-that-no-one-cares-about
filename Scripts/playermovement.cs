﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class playermovement : MonoBehaviour {

    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

    public Rigidbody rb;
    public float fly;
    Vector3 axis0, axis1, axis2;
	// Use this for initialization
	void Awake () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        device = SteamVR_Controller.Input((int)trackedObj.index);
       /* axis0 = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0); //Joystick
        axis1 = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis1); //Front Trigger
        axis2 = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis2); //Side Trigger*/

        if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad)) {
            //Debug.Log("Axis: (" + device.GetAxis().x + "," + device.GetAxis().y + ")");
            Vector3 move = new Vector3((-1*device.GetAxis().y*fly), 0, (device.GetAxis().x * fly));
            // Debug.Log(move);
            rb.MovePosition(rb.position + move);
            //Debug.Log("New Position: " + rb.position);
        }
        /*if(device.GetPress(SteamVR_Controller.ButtonMask.Grip))
        {
            rb.velocity = Vector3.zero;
        }*/
        if(device.GetPress(SteamVR_Controller.ButtonMask.Grip)) {
            rb.MovePosition(Vector3.zero);
        }
    }
}