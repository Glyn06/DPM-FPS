using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputVR : MonoBehaviour, InputInterface
{
    public VRTK.VRTK_ControllerEvents VRRightController;
    public VRTK.VRTK_ControllerEvents VRLeftController;
    public VRTK.VRTK_InteractGrab VRRightGrab;
    public VRTK.VRTK_InteractGrab VRLeftGrab;
    private bool onRightTriggerDown = false;
    private bool onLeftTriggerDown = false;

    public bool LeftFireButton()
    {

        if (VRRightController.triggerPressed && !onRightTriggerDown)
        {
            onRightTriggerDown = true;
            return true;
        }
        

        if(!VRRightController.triggerPressed && onRightTriggerDown)
        {
            onRightTriggerDown = false;
            return false;
        }

        return false;
    }

    public bool RightFireButton()
    {

        if (VRLeftController.triggerPressed && !onLeftTriggerDown)
        {
            onLeftTriggerDown = true;
            return true;
        }


        if (!VRLeftController.triggerPressed && onLeftTriggerDown)
        {
            onLeftTriggerDown = false;
            return false;
        }

        return false;
    }

    public bool LeftSwordButton() {
        if (VRRightGrab.IsGrabButtonPressed())
        {
            return true;
        }
        return false;
    }

    public bool RightSwordButton() {
        if (VRLeftGrab.IsGrabButtonPressed())
        {
            return true;
        }
        return false;
    }
}
