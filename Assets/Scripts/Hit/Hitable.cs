using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitable : MonoBehaviour
{
    public float health = 1;
    public GameObject hitParticle;
    public float hitInterval = 0.1f;
    public float lastHit = 0;
    public string dieEvent;

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

    public void Update()
    {
        if (health <= 0)
        {
            Die();

            Destroy(gameObject);
        }
    }

    public void Die()
    {
        CreateObjAt(hitParticle , transform.position + Random.onUnitSphere * 0.5f , Vector3.up );
        CreateObjAt(hitParticle, transform.position + Random.onUnitSphere * 0.5f, Vector3.up);
        CreateObjAt(hitParticle, transform.position + Random.onUnitSphere * 0.5f, Vector3.up);

        if ( !string.IsNullOrEmpty(dieEvent) )
            PlayMakerFSM.BroadcastEvent(dieEvent);
    }

    public void CreateObjAt(GameObject effect, Vector3 pos , Vector3 normal )
    {
        var res = Instantiate(effect) as GameObject;
        res.transform.position = pos;
        res.transform.up = normal;
    }
}
