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
    // Use this for initialization

    private void Start()
    {
        playerInstance = Player.instance;
        enemyAgent = GetComponent<NavMeshAgent>();
        enemyAgent.SetDestination(playerInstance.transform.position);
    }

    private void OnEnable()
    {
        life = maxLife;
        if (enemyAgent != null)
        {
            enemyAgent.enabled = true;
            enemyAgent.SetDestination(playerInstance.transform.position);
        }
    }

    private void OnDisable()
    {
        if (enemyAgent != null)
        {
            enemyAgent.enabled = false;
        }
    }

    // Update is called once per frame
    void Update () {

        if (life <= 0)
        {
            GetComponent<PoolObject>().Recycle();
            PlayerData.instance.AddScore(50);
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
