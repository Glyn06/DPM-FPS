using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Perk : ScriptableObject {
    public string perkName;
    public Sprite icon;

    protected List<Weapon> weapons;
    protected Player_PC player; 

    public abstract void ImplementPerk();
    public abstract void UnimplementPerk();

    public void SetWeapons(Weapon weaponA, Weapon weaponB) {
        weapons.Add(weaponA);
        weapons.Add(weaponB);
    }

    public void SetPlayer(Player_PC _player) {
        player = _player;
    }
}
