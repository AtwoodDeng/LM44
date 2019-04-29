using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestory : MonoBehaviour
{
    public bool OnStart = true;
    private float timer = -1f;
    public float DestoryTime = 1f;
    public GameObject target;

    public void Start()
    {
        if (target == null)
            target = gameObject;
                
        if ( OnStart )
            BeginDestory();
    }

    public void Update()
    {
        if ( timer > 0 )
            timer -= Time.deltaTime;

        if (timer <= 0 )
        {
            Destroy(target);
        }
    }

    public void BeginDestory()
    {
        timer = DestoryTime;
    }
}
