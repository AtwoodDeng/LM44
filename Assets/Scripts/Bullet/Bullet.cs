using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Hitter
{

    public float speed = 20f;
    public Rigidbody rigidbody;
    
    public void Update()
    {
        //transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void Shoot(Transform root)
    {
        transform.position = root.transform.position - root.transform.right * 0.7f;

        transform.forward = - root.right;

        rigidbody.velocity = -root.right * speed;
    }

    public void ShootNew(Transform origianlWeapon)
    {
        transform.position = origianlWeapon.transform.position;

        transform.forward = origianlWeapon.transform.forward;

        rigidbody.velocity = -origianlWeapon.transform.forward * speed;

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Hitable") )
        {
            Destroy(gameObject);
        }
    }
}

