using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public delegate void OnClipChange();
    public OnClipChange onClipChangeCallBack;

    public Camera cam;

    Pool bulletPool;
    [SerializeField]
    int maxClip;
    int clip;

    private void Start()
    {
        clip = maxClip;

        CheckAndInvokeClipCallBack();
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

        CheckAndInvokeClipCallBack();
    }

    public void Reload() {
        clip = maxClip;

        CheckAndInvokeClipCallBack();
    }

    public bool EmptyClip() {
        if (clip <= 0)
            return true;
        return false;
    }

    public int GetClip() {
        return clip;
    }

    void CheckAndInvokeClipCallBack() {
        if (onClipChangeCallBack != null)
            onClipChangeCallBack.Invoke();
    }
}
