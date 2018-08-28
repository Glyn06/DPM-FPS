using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Vector3 dir;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += dir;
	}

    public void Fire(Vector3 _dir) {
        dir = _dir;
    }
}
