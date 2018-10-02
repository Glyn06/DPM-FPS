using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Perk : ScriptableObject {
    public string perkName;
    public Sprite icon;

    public List<Weapon> weapons;

    public abstract void ImplementPerk();
    public abstract void UnimplementPerk();

    public void SetWeapons(Weapon weaponA, Weapon weaponB) {
        weapons.Add(weaponA);
        weapons.Add(weaponB);
    }
}
