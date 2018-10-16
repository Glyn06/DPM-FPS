using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newRateOfFirePerk", menuName = "Perks/RateOfFirePerk")]
public class FireRatePerk : Perk {

    public float RateOfFireMod;

    public override void ImplementPerk()
    {
        //throw new System.NotImplementedException();

        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].SetRateOfFire(weapons[i].GetRateOfFire() - RateOfFireMod);
        }
    }

    public override void UnimplementPerk()
    {
        //throw new System.NotImplementedException();

        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].SetRateOfFire(weapons[i].GetRateOfFire() + RateOfFireMod);
        }
    }
}
