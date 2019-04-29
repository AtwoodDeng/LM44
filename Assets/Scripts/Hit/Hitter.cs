using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitter : MonoBehaviour
{
    public float Dmg;

    public bool IsOn;

    virtual  public bool IsActive()
    {
        return IsOn;
    }
}
