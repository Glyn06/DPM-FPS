using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    public int life;
    public int enemyDamage;
    private NavMeshAgent enemyAgent;
    private Player playerInstance;
    [SerializeField]
    private int maxLife;
    private float enabletimer;
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
            enemyAgent.enabled = false;
        }
        if (PlayerData.instance != null)        
        PlayerData.instance.AddScore(50);

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
        }
	}
    public void OnCollisionEnter(Collision collision)
    {
        Damageable damageable = collision.collider.GetComponent<Damageable>();
        if (damageable != null && !collision.gameObject.CompareTag("Enemy"))
        {
            damageable.SetDamage(enemyDamage);
            GetComponent<PoolObject>().Recycle();
        }
    }
}
