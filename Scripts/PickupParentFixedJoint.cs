using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class PickupParentFixedJoint : MonoBehaviour
{

    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

    
    // Use this for initialization
    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
            Debug.Log("You have pressed the Trigger!");
    }

    private void OnTriggerStay(Collider col)
    {
        Debug.Log("You have collided with " + col.name + " and activated OnTriggerStay.");
        if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger) && (col.name == "groundcrew light stick" || col.name == "groundcrew light stick (1)"))
        {
            Debug.Log("You have collided with " + col.name + " while holding down touch.");
            col.gameObject.transform.SetParent(gameObject.transform);
            col.attachedRigidbody.isKinematic = false;
        }
        if ((device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger) || device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger)))
        {
            col.gameObject.transform.SetParent(null);
            col.attachedRigidbody.isKinematic = true;


        }
    }
    
    }
