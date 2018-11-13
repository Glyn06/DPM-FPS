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
    private Vector3 distanceToEnemy;

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

    public void CalculateDistanceToAttacker() {
        PlayerDamageable pdmg = GetComponent<PlayerDamageable>();
        Vector3 attackerPos = pdmg.GetAttackerPos();

        distanceToEnemy = transform.position - attackerPos;
        distanceToEnemy.Normalize();
    }

    public Vector3 GetDistanceToEnemy() {
        return distanceToEnemy;
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

        if (InputManager.instance.RightSword())
        {
            if (RightWeapon.GetIsSword())
                RightWeapon.SetIsSword(false);
            else
                RightWeapon.SetIsSword(true);
        }

        if (InputManager.instance.LeftSword())
        {
            if (LeftWeapon.GetIsSword())
                LeftWeapon.SetIsSword(false);
            else
                LeftWeapon.SetIsSword(true);
        }

        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
