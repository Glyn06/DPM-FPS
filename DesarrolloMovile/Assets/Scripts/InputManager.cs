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

    bool CheckPCPlatform() {
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
            return true;
        return false;
    }
    public bool Fire() {
        if (CheckPCPlatform() && Input.GetMouseButtonDown(0))
            return true;
        return false;
    }

    //CHECKVRPLATFORM DO IT!
}
