using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPC : InputInterface
{
    public bool FireButton()
    {
        return Input.GetMouseButtonDown(0);
    }
}