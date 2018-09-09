﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    public int life;
    public int enemyDamage;
    private NavMeshAgent enemyAgent;
    private Player playerInstance;
	// Use this for initialization
	void Start () {
        playerInstance = Player.instance;
        enemyAgent = GetComponent<NavMeshAgent>();
        enemyAgent.SetDestination(playerInstance.transform.position);

    }
	
	// Update is called once per frame
	void Update () {
        if (life <= 0)
        {
            Destroy(gameObject);
            PlayerData.instance.AddScore(50);
        }
	}
    public void OnCollisionEnter(Collision collision)
    {
        Damageable damageable = collision.collider.GetComponent<Damageable>();
        if (damageable != null)
        {
            damageable.SetDamage(enemyDamage);
            Destroy(gameObject);
        }
    }
}
