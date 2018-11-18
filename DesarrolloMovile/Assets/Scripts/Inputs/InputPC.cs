﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPC : InputInterface
{
    public bool LeftFireButton()
    {
        return Input.GetMouseButtonDown(0);
    }
    public bool RightFireButton()
    {
        return Input.GetMouseButtonDown(1);
    }

    public bool LeftSwordButton()
    {
        return Input.GetKeyDown(KeyCode.Z);
    }

    public bool RightSwordButton()
    {
        return Input.GetKeyDown(KeyCode.X);
    }
}