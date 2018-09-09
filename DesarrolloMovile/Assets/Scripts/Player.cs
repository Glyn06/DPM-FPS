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
    public int life;

    private void Update()
    {
        if (!RightWeapon.EmptyClip() && InputManager.instance.RightFire())
        {
            RightWeapon.Fire();
        }

        if (!LeftWeapon.EmptyClip() && InputManager.instance.LeftFire())
        {
            LeftWeapon.Fire();
        }

        if (InputManager.instance.LeftReload())
        {
            LeftWeapon.Reload();
        }

        if (InputManager.instance.RightReload())
        {
            RightWeapon.Reload();
        }

        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
