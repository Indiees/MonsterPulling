using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour {

    private Rigidbody rb;
    public float force;
    public float lifetime;

    private void OnEnable()

    {
        rb = GetComponent<Rigidbody>();
        Invoke("Deactivate", lifetime);
        ShotBullet();
    }

    private void ShotBullet()
    {
        rb.AddForce(WeaponController.Instance.jointWeapon.forward * force);
        
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
