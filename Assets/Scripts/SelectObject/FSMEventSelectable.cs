using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtLib.Gallery
{

    public class FSMEventSelectable : SelectableObject
    {

        public string FSMEventName;

        public PlayMakerFSM target;
        public override void Interact()
        {
            base.Interact();

            Debug.Log("Fire " + FSMEventName);

            if ( target ==null )
                PlayMakerFSM.BroadcastEvent(FSMEventName);
            else 
                target.SendEvent(FSMEventName);
        }
    }

}