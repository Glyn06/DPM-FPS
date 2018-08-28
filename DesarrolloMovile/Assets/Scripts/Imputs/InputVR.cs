using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputVR : MonoBehaviour, InputInterface
{

    public bool FireButton()
    {
       /* if (GetComponent<VRTK_InteractGrab>().GetGrabbedObject != null)
        {
            var controllerEvents = GetComponent<VRTK_ControllerEvents>();
            if (controllerEvents.IsButtonPressed(VRTK_ControllerEvents.ButtonAlias.Trigger_Press) 
            {
                return true;
            }
        }*/
        return false;
    }
}
