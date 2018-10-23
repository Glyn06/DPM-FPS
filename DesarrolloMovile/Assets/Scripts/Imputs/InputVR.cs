using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputVR : MonoBehaviour, InputInterface
{

    private bool onRightTriggerDown = false;
    private bool onLeftTriggerDown = false;

    public bool LeftFireButton()
    {
        return false;
    }

    public bool RightFireButton()
    {
        return false;
    }

    public bool RightSwordButton()
    {
        return false;
    }

    public bool LeftSwordButton()
    {
        return false;
    }
}
