using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Bullet bullet;
    public Camera cam;

    private void Update()
    {
        gameObject.transform.rotation = cam.transform.rotation;
    }

    public void Fire() {
        Bullet instance;
        instance = Instantiate(bullet, transform.position, Quaternion.identity, null);
        instance.Fire(transform.forward);
    }
}
