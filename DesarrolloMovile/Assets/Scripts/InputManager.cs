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
        DontDestroyOnLoad(gameObject);
        instance = this;
    }
    #endregion

    InputInterface input;

    /*  bool CheckPCPlatform() {
          if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
              return true;
          return false;
      }

    */
    
    private void Start()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            //input = new InputPC();
        }
        else
        {
            //input = GetComponentInChildren<InputVR>();
        }
        input = GetComponentInChildren<InputVR>();


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
    //CHECKVRPLATFORM DO IT!
}
