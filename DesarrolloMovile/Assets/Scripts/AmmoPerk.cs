using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newAmmoPerk", menuName = "Perks/AmmoPerk")]
public class AmmoPerk : Perk {

    public int clipSizeMod;

    public override void ImplementPerk()
    {
        //throw new System.NotImplementedException();
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].
                SetMaxClip(clipSizeMod);
        }
    }

    public override void UnimplementPerk()
    {
        //throw new System.NotImplementedException();
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].
                SetMaxClip(-clipSizeMod);
        }
    }
}
