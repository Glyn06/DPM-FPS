using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    public int life;
    public int enemyDamage;
    private NavMeshAgent enemyAgent;
    private Player playerInstance;
    private bool isAttacking;
    private Damageable target;
    [SerializeField] private int maxLife;
    [SerializeField] private float attackSpeed = 1.5f;
    

    private float enabletimer;
    private float attackSpeedTimer;
    // Use this for initialization

    private void Start()
    {
        playerInstance = Player.instance;
        enemyAgent = GetComponent<NavMeshAgent>();
    }


    private void OnEnable()
    {
        life = maxLife;
        enabletimer = 0;
    }

    private void OnDisable()
    {
        if (enemyAgent != null)
        {
            enemyAgent.isStopped = false;
            enemyAgent.enabled = false;
            isAttacking = false;
            target = null;
        }
    }

    // Update is called once per frame
    void Update () {

        if (enemyAgent != null)
        {
            if (enemyAgent.enabled == false)
            {
                enabletimer += Time.deltaTime;
                if (enabletimer >= 1)
                {
                    enemyAgent.enabled = true;
                    enemyAgent.SetDestination(playerInstance.transform.position);
                }
            }
        }

        if (life <= 0)
        {
            GetComponent<PoolObject>().Recycle();

            if (PlayerData.instance != null)        
            PlayerData.instance.AddScore(50);
        }

        if (isAttacking)
        {
            attackSpeedTimer += Time.deltaTime;
        }
	}

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            target = collision.gameObject.GetComponent<Damageable>();
            isAttacking = true;
            enemyAgent.isStopped = true;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if ( target != null && attackSpeedTimer >= attackSpeed)
        {
            Attack(target, enemyDamage);
            attackSpeedTimer = 0;
        }
    }

    public void Attack(Damageable _target, int _enemyDamage) {
        _target.SetDamage(_enemyDamage);
    }
}
