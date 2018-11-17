using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
    /*private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    [HideInInspector] public SteamVR_TrackedObject trackedObject;
    [HideInInspector] public SteamVR_Controller.Device Controller;
    */
    [HideInInspector] public bool triggerDown;
    [HideInInspector] public bool grapDown;

    private SteamVR_TrackedController device;
    // Use this for initialization
    void Start () {
        // trackedObject = GetComponent<SteamVR_TrackedObject>();
        device = GetComponent<SteamVR_TrackedController>();
        device.TriggerClicked += TriggerDown;
    }
	
	// Update is called once per frame
	void Update () {
       // Controller = SteamVR_Controller.Input((int)trackedObject.index);

        /*if (Controller.GetPress(triggerButton) || Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Trigger");

            triggerDown = true;
        }
        else
        {
            triggerDown = false;
        }

        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            grapDown = true;
        }
        else
        {
            grapDown = false;
        }*/
    }

    public void TriggerDown(object sender, ClickedEventArgs e)
    {
        Debug.Log("Trigger");
    }


}
