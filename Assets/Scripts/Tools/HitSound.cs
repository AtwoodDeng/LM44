using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HitSound : MonoBehaviour
{
    public AudioClip sound;
    public float threshold = 0.2f;
    public float multipy = 0.5f;
    public void OnCollisionEnter( Collision col )
    {
        var relativeVel = col.relativeVelocity.magnitude;

        if (relativeVel > threshold && sound != null )
        {
            AudioSource.PlayClipAtPoint(sound , col.contacts[0].point , Mathf.Clamp01(( relativeVel - threshold ) * multipy) );
        }
    }
}
