using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCanvas : MonoBehaviour {
    private Player player;
    private Vector2 effectPos;
    private Vector3 aux;
    public GameObject dmgSourcePrefab;

    private void Start()
    {
        player = Player.instance;
        aux = Vector3.zero;
    }

    private void Update()
    {
        if (effectPos != null)
        {
            if (aux != player.GetDistanceToEnemy())
            {
                DamageEffect();
                aux = player.GetDistanceToEnemy();
            }
        }
    }

    public void DamageEffect() {
        effectPos.x = player.GetDistanceToEnemy().x;
        effectPos.y = player.GetDistanceToEnemy().z;

        Instantiate(dmgSourcePrefab, effectPos, Quaternion.identity, transform);
        Debug.Log("Damage Efect");
    }
}
