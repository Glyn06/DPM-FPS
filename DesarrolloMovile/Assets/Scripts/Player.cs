using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    #region Singleton
    public static Player instance;
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

    public Weapon weapon;
    public VRTK.VRTK_ControllerEvents VRController;

    private void Update()
    {
        if (InputManager.instance.Fire() || (VRController != null && VRController.triggerPressed ))
        {
            weapon.Fire();
            Debug.Log("VR fire");
        }
    }
}
