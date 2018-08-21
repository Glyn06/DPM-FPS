using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public void Fire() {
        Debug.Log("Fire from: " + gameObject.name);
    }
}
