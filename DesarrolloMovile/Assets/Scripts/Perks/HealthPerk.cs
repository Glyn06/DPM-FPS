using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newHealthPerk", menuName = "Perks/HealthPerk")]
public class HealthPerk : Perk {

    public int healthMod;

    public override void ImplementPerk()
    {
        //throw new System.NotImplementedException();
        player.SetLife(player.GetLife() + healthMod);
    }

    public override void UnimplementPerk()
    {
        //throw new System.NotImplementedException();
        player.SetLife(player.GetLife() - healthMod);
    }
}
