using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace AtLib.Gallery
{
    [CreateAssetMenu( fileName = "SelectableObjectProfile" , menuName = "Gallery/SelectableObjectProfile", order = 0)]
    public class SelectableObjectProfile : ScriptableObject
    {
        public enum Type
        {
            Normal,
            Delay,
            
        }

        public bool IsOverrideTips;

        [ShowIf("IsOverrideTips")]public MWord scanTips;
        public float senseRange = -1f;

        public Type type = Type.Normal;
        [ShowIf("type" , Type.Delay)]
        public float delayFocusDuration = 1f;
    };
}
