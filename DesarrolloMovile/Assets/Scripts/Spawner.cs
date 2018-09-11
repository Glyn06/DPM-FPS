using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public string poolName;
    public float spawnTime;

    float timer;
    Pool objectPool;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            objectPool = PoolManager.instance.GetPool(poolName);
            GameObject obj;
            obj = objectPool.UseObj(transform.position);
            timer = 0;
        }
    }

}
