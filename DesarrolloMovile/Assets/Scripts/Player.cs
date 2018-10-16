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
        instance = this;

        GetAndImplementrPerks();
    }
    #endregion

    public Weapon RightWeapon;
    public Weapon LeftWeapon;
    public int life;

    private PerkSystem perkSystem;

    public void GetAndImplementrPerks()
    {
        perkSystem = GetComponent<PerkSystem>();
        for (int i = 0; i < perkSystem.perks.Count; i++)
        {
            perkSystem.perks[i].SetWeapons(RightWeapon, LeftWeapon);
            perkSystem.perks[i].SetPlayer(this);
            perkSystem.perks[i].ImplementPerk();
        }
    }

    public void SetLife(int _lifeMod) {
        life = _lifeMod;
    }

    public int GetLife() {
        return life;
    }

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

        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
