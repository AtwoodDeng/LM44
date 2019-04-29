using System.Collections;
using System.Collections.Generic;
using AtLib.Gallery;
using Jam.LM44;
using Sirenix.OdinInspector;
using UnityEngine;

public class PickSelectable : ActionSelectable
{
    public float tempWeight;

    [Button]
    public void GetWeight()
    {
        if (gameObject.GetComponent<Rigidbody>() != null)
            tempWeight = gameObject.GetComponent<Rigidbody>().mass;

    }


    public void Start()
    {
        profile = Instantiate(profile) as SelectableObjectProfile;

        profile.scanTips.ch += " (dmg:" + tempWeight + ")";
        profile.scanTips.eng += " (dmg:" + tempWeight + ")"; 

    }

    public override void Interact()
    {
        base.Interact();

        if (InteractionManager.instance.tollerateWeight > tempWeight)
        {
            InteractionManager.instance.Equip(gameObject);
        }

    }
}
