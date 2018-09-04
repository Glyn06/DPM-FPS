using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputVR : MonoBehaviour, InputInterface
{
    public VRTK.VRTK_ControllerEvents VRRightController;
    public VRTK.VRTK_ControllerEvents VRLeftController;

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

    public bool LeftReloadButton() {
        if (VRLeftController.buttonOnePressed)
        {
            return true;
        }
        return false;
    }

    public bool RightReloadButton() {
        if (VRRightController.buttonOnePressed)
        {
            return true;
        }
        return false;
    }
}
