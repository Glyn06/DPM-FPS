using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputVR : InputInterface
{
    public VRTK.VRTK_ControllerEvents VRController;
    public bool FireButton()
    {
        if (VRController.triggerPressed)
        {
            Debug.Log("VR FireButton");
            return true;
        }
        return false;
    }
}
