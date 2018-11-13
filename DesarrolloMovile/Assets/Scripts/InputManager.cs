using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    #region Singleton
    public static InputManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    InputInterface input;
    
    private void Start()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            input = new InputPC();
        }
        else
        {
            input = GetComponentInChildren<InputVR>();
        }
        //input = GetComponentInChildren<InputVR>();
    }

    public bool RightFire()
    {
        if (input.RightFireButton())
            return true;
        return false;
    }

    public bool LeftFire()
    {
        if (input.LeftFireButton())
            return true;
        return false;
    }

    public bool RightSword() {
        if (input.RightSwordButton())
            return true;
        return false;
    }

    public bool LeftSword()
    {
        if (input.LeftSwordButton())
            return true;
        return false;
    }
}
