using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public TrailRenderer trail;
    public int bulletDamage;
    Vector3 dir;
    float maxLifeTime = 2.5f;
    float timer;

	// Update is called once per frame
	void Update () {
        transform.position += dir;
        timer += Time.deltaTime;
        if (timer >= maxLifeTime)
        {
            GetComponent<PoolObject>().Recycle();
            trail.gameObject.SetActive(false);
        }
	}

    public void Fire(Vector3 _dir) {
        timer = 0;
        dir = _dir;
        trail.gameObject.SetActive(true);
    }
    //レアンドル　
    public void OnCollisionEnter(Collision collision)
    {

        Damageable damageable = collision.collider.GetComponent<Damageable>();
        if (damageable!= null)
        {
            damageable.SetDamage(bulletDamage);
            GetComponent<PoolObject>().Recycle();
        }
    }
}
