using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {

    public Bullet bulletPrefab;
    public int cantBullets = 10;

    List<Bullet> bullets = new List<Bullet>();

    private void Awake()
    {
        for (int i = 0; i < cantBullets; i++)
        {
            bullets.Add(bulletPrefab);
        }
        for (int i = 0; i < cantBullets; i++)
        {
            GameObject bullet;
            bullet = Instantiate(bullets[i].gameObject);
            bullet.SetActive(false);
        }
    }


}
