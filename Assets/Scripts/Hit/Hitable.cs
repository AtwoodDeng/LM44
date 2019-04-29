using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitable : MonoBehaviour
{
    public float health;
    public GameObject hitParticle;
    public float hitInterval = 0.1f;
    public float lastHit = 0;


    public void OnCollisionEnter(Collision col)
    {
        Debug.Log("On Coll enter " + col.collider.name );
        var hitter = col.collider.GetComponent<Hitter>();


        if (hitter != null && hitter.IsActive() && (Time.time - lastHit )> hitInterval)
        {

            lastHit = Time.time;
            health -= hitter.Dmg;

            CreateObjAt(hitParticle , col.contacts[0].point , col.contacts[0].normal);
        }
    }

    public void CreateObjAt(GameObject effect, Vector3 pos , Vector3 normal )
    {
        var res = Instantiate(effect) as GameObject;
        res.transform.position = pos;
        res.transform.up = normal;
    }
}
