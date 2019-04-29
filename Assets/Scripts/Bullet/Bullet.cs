using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Hitter
{

    public float speed;
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Hitable") )
        {
            Destroy(gameObject);
        }
    }
}

