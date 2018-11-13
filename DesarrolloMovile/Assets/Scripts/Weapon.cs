using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Camera cam;
    public GameObject pistolModel;
    public GameObject swordModel;

    Pool bulletPool;
    [SerializeField]
    float rateOfFire = 0.25f;
    float timer;
    bool isSword = false;

    private void Update()
    {
        gameObject.transform.rotation = cam.transform.rotation;
        timer += Time.deltaTime;

        if (isSword)
        {
            pistolModel.SetActive(false);
            swordModel.SetActive(true);
        }
        else
        {
            pistolModel.SetActive(true);
            swordModel.SetActive(false);
        }
    }

    public void Fire() {
        if (!isSword && timer >= rateOfFire)
        {
            bulletPool = PoolManager.instance.GetPool("BulletPool");
            GameObject gameObjectInstance = bulletPool.UseObj(transform.position);
            gameObjectInstance.GetComponent<Bullet>().Fire(transform.forward);

            timer = 0;
        }

        if (isSword)
        {
            Debug.Log("Oooo you tocuhed my tra lla laa in " + gameObject.name);
        }
    }

    public float GetRateOfFire() {
        return rateOfFire;
    }

    public void SetRateOfFire(float _rateOfFire) {
        rateOfFire = _rateOfFire;
    }

    public void SetIsSword(bool _isSword) {
        isSword = _isSword;
    }

    public bool GetIsSword() {
        return isSword;
    }
}
