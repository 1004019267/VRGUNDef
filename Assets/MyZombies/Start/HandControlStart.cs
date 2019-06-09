using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]
[RequireComponent(typeof(LineRenderer))]
public class HandControlStart : MonoBehaviour
{
    public Rigidbody attackBody;

    public Transform head;
    Transform cameraRig;
    SteamVR_TrackedObject trackedObj;
    LineRenderer line;
    FixedJoint joint;

    bool hitground;
    Vector3 hitpoint;
    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        cameraRig = transform.parent;
        //Debug.Log(cameraRig.name);
        line = GetComponent<LineRenderer>();
        line.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        var device = SteamVR_Controller.Input((int)trackedObj.index);
        RaycastHit hit;
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            line.enabled = true;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                Debug.DrawLine(transform.position, hit.point, Color.red);
                hitpoint = hit.point;
                hitground = true;

                line.SetPosition(0, transform.position);
                line.SetPosition(1, hitpoint);
            }
            else
            {
                line.SetPosition(0, transform.position);
                line.SetPosition(1, transform.position + transform.forward * 5f);
            }
        }
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            if (hitground)
            {
                cameraRig.position = hitpoint - head.localPosition;
            }
            hitground = false;
            line.enabled = false;
        }
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            var cols = Physics.OverlapSphere(transform.position, 0.5f);
            if (cols.Length > 0)
            {
                var go = cols[0].gameObject;
                joint = go.AddComponent<FixedJoint>();
                joint.connectedBody = attackBody;
            }
        }
        if (joint != null && device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Destroy(joint);
        }
    }
}
