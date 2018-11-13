using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageable : Damageable {

    private Player player;
    private Vector3 attackerPos;
    void Start()
    {
        player = GetComponent<Player>();
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
