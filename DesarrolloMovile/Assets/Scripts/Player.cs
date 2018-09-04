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

    public Weapon RightWeapon;
    public Weapon LeftWeapon;

    private void Update()
    {
        if (InputManager.instance.RightFire())
        {
            RightWeapon.Fire();
        }

        if (InputManager.instance.LeftFire())
        {
            LeftWeapon.Fire();
        }
    }
}
