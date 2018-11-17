using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageable : Damageable {

    private Player_PC player;
    private Vector3 attackerPos;
    void Start()
    {
        player = GetComponent<Player_PC>();
    }

    public override void SetDamage(int damage)
    {
        player.life -= damage;
        player.CalculateDistanceToAttacker();
    }

    public void SetAttackerPos(Vector3 _attackerPos) {
        attackerPos = _attackerPos;
    }

    public Vector3 GetAttackerPos() {
        return attackerPos;
    }
}
