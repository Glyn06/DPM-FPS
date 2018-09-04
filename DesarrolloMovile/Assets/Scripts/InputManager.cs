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
            input = new InputPC();
        }
        else
        {
            input = new InputVR();
           // input.VRController = 
        }
           // input = new InputVR();


    }

    public bool Fire()
    {
        if (input.FireButton())
            return true;
        return false;
    }

    //CHECKVRPLATFORM DO IT!
}
