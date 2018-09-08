using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    public Player player;

    public Weapon getWeapon(string side) {
        switch (side)
        {
            case "Left":
                return player.LeftWeapon;
            case "Right":
                return player.RightWeapon;
            default:
                Debug.LogWarning("No such weapon");
                return null;
        }
    }
}
