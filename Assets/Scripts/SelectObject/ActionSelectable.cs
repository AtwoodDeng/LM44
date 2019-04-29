using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

namespace AtLib.Gallery
{
    public class ActionSelectable : SelectableObject
    {
        public UnityEvent action;
        override public void Interact()
        {
            action.Invoke();
        }

    }
}