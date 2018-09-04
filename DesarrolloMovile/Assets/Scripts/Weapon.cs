using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Camera cam;

    Pool bulletPool;
    [SerializeField]
    int maxClip;
    int clip;

    private void Awake()
    {
        clip = maxClip;
    }

    private void Update()
    {
        gameObject.transform.rotation = cam.transform.rotation;
    }

    public void Fire() {
        bulletPool = PoolManager.instance.GetPool("BulletPool");
        GameObject gameObjectInstance = bulletPool.UseObj();
        gameObjectInstance.transform.position = transform.position;
        gameObjectInstance.GetComponent<Bullet>().Fire(transform.forward);
        clip--;
    }

    public void Reload() {
        clip = maxClip;
    }

    public bool EmptyClip() {
        if (clip <= 0)
            return true;
        return false;
    }
}
