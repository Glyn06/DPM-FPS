using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageable : Damageable {

    private Player player;
    void Start()
    {
        player = GetComponent<Player>();
    }

    public override void SetDamage(int damage)
    {
        player.life -= damage;
    }
}
