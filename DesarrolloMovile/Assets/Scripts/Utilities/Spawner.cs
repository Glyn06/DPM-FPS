using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public string poolName;

    Pool objectPool;


    public void Spawn() {
        objectPool = PoolManager.instance.GetPool(poolName);
        GameObject obj;
        obj = objectPool.UseObj(transform.position);
    }

}
