using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Camera cam;
    public GameObject pistolModel;
    public GameObject swordModel;
    public AudioSource audioSource;

    Pool bulletPool;
    [SerializeField]
    float rateOfFire = 0.25f;
    [SerializeField]
    float swordAttackDelay = 1.5f;
    float gunTimer;
    float swordTimer;
    bool isSword = false;
    Animator swordAnimation;

    private void Start()
    {
        swordAnimation = swordModel.GetComponent<Animator>();
    }

    private void Update()
    {
        if(cam != null)
            gameObject.transform.rotation = cam.transform.rotation;
        gunTimer += Time.deltaTime;
        swordTimer += Time.deltaTime;

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
        if (!isSword && gunTimer >= rateOfFire)
        {
            bulletPool = PoolManager.instance.GetPool("BulletPool");
            GameObject gameObjectInstance = bulletPool.UseObj(transform.position);
            gameObjectInstance.GetComponent<Bullet>().Fire(transform.forward);

            gunTimer = 0;

            AudioManager.instance.Play("WeaponSound");
        }

        if (isSword && swordTimer >= swordAttackDelay)
        {
            Debug.Log("Oooo you tocuhed my tra lla laa in " + gameObject.name);
            swordAnimation.SetTrigger("SwordAttack");
            swordTimer = 0;
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
