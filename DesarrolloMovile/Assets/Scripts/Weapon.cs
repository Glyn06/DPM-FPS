using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Camera cam;

    Pool bulletPool;
    [SerializeField]
    float rateOfFire = 0.25f;
    float timer;

    private void Update()
    {
        gameObject.transform.rotation = cam.transform.rotation;
        timer += Time.deltaTime; 
    }

    public void Fire() {
        if (timer >= rateOfFire)
        {
            bulletPool = PoolManager.instance.GetPool("BulletPool");
            GameObject gameObjectInstance = bulletPool.UseObj(transform.position);
            gameObjectInstance.GetComponent<Bullet>().Fire(transform.forward);

            timer = 0;
        }
    }
}
