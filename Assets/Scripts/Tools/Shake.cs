using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{

    public bool IsShaking = false;
    public Transform target;
    public float intense = 0.5f;
    public void Update()
    {
        if (IsShaking)
        {
            var delta = intense * Random.onUnitSphere;
            delta.x *= 0.2f;
            delta.z *= 0.2f;
            target.position += intense * Random.onUnitSphere;
        }
    }
}
