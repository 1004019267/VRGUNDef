using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SteamVR_TrackedObject))]
public class HandControl2 : MonoBehaviour
{
    SteamVR_TrackedController controller;
    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device deviec;

    public Fire fire;
    
    // Use this for initialization
    void Start()
    {
        controller = this.GetComponent<SteamVR_TrackedController>();
        trackedObj = this.GetComponent<SteamVR_TrackedObject>();
        deviec = SteamVR_Controller.Input((int)trackedObj.index);

        //controller.TriggerClicked += Controller_TriggerClicjed;
        //controller.TriggerUnclicked += Controller_TriggerUnClicjed;

    }
    //void OnDestroy()
    //{
    //    controller.TriggerClicked -= Controller_TriggerClicjed;
    //    controller.TriggerUnclicked -= Controller_TriggerUnClicjed;
    //}
    //private void Controller_TriggerClicjed(object sender, ClickedEventArgs e)
    //{

    //}
    //private void Controller_TriggerUnClicjed(object sender, ClickedEventArgs e)
    //{

    //}
    IEnumerator Shake(float duration)
    {
        while (duration > 0)
        {
            yield return 0;
            duration -= Time.deltaTime;
            deviec.TriggerHapticPulse(500);
        }
    }
    

    void Update()
    {
        //var value = deviec.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);
        var device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            fire.FireGo();
            StartCoroutine(Shake(1));
        }
    }
}
