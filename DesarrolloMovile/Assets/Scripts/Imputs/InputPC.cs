﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPC : InputInterface
{
    public bool LeftFireButton()
    {
        return Input.GetMouseButton(0);
    }
    public bool RightFireButton()
    {
        return Input.GetMouseButton(1);
    }
    public bool RightSwordButton() {
        return Input.GetKeyDown(KeyCode.C);
    }
    public bool LeftSwordButton() {
        return Input.GetKeyDown(KeyCode.X);
    }
}