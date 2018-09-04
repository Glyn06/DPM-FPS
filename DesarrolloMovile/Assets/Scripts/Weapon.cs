using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Camera cam;

    Pool bulletPool;

    private void Update()
    {
        gameObject.transform.rotation = cam.transform.rotation;
    }

    public void Fire() {
        bulletPool = PoolManager.instance.GetPool("BulletPool");
        GameObject gameObjectInstance = bulletPool.UseObj();
        gameObjectInstance.transform.position = transform.position;
        gameObjectInstance.GetComponent<Bullet>().Fire(transform.forward);
    }
}
