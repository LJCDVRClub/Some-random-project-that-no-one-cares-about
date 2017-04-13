using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class FixedJointPickup : MonoBehaviour
{

    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

    public Rigidbody rigidbodyAttachPoint;

    FixedJoint fj;
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
        if (fj == null && device.GetPress(SteamVR_Controller.ButtonMask.Trigger) && (col.name == "groundcrew light stick" || col.name == "groundcrew light stick (1)"))
        {
            fj = col.gameObject.AddComponent<FixedJoint>();
            fj.connectedBody = rigidbodyAttachPoint;
        }
        else if (fj != null && device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            GameObject go = fj.gameObject;
            Rigidbody rb = go.GetComponent<Rigidbody>();
            Object.Destroy(fj);
            fj = null;

        }
    }
}
