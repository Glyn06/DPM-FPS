using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    public Vector3 MaxSixe;
    public int swordDamage;
    private Vector3 size;

    private void OnEnable()
    {
        size = MaxSixe;
        size.y = 0;
        transform.localScale = size;
        Invoke("PlayAudio", 1.0f);
    }

    void Start () {
		
	}
	
	void Update () {
        if (size.y < MaxSixe.y)
        {
            size.y += Time.deltaTime;
            transform.localScale = size;

        }
      

    }
    
    private void PlayAudio()
    {
        AudioManager.instance.Play("saber_idle");

    }
    private void OnDisable()
    {
            AudioManager.instance.Stop("saber_idle");

    }

    public void OnCollisionEnter(Collision collision)
    {

        Damageable damageable = collision.collider.GetComponent<Damageable>();
        if (damageable != null)
        {
            damageable.SetDamage(swordDamage);
            AudioManager.instance.Play("saber_crash");

        }
    }
}
