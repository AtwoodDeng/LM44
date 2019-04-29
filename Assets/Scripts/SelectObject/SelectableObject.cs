using System.Collections;
using System.Collections.Generic;
using HutongGames.PlayMaker;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace AtLib.Gallery
{
    public class SelectableObject : MonoBehaviour
    {
        [InlineEditor]
        public SelectableObjectProfile profile;

        [SerializeField]
        private bool m_interactable = true ;

        public bool Interactable
        {
            get { return m_interactable; }
        }

        virtual public void EnableInteraction()
        {
            m_interactable = true;
        }

        virtual public void DisableInteraction()
        {
            m_interactable = false;
        }

        virtual public void Interact()
        {
        }

        public string tips
        {
            get { return profile == null ? "" : profile.scanTips.value; }
        }

        public float range
        {
            get { return profile == null || profile.senseRange < 0 ? 9999f : profile.senseRange; }
        }
        public bool IsOverrideTips
        {
            get { return profile == null ? false : profile.IsOverrideTips; }
        }


        public bool IsAbleToScan(float distance)
        {
            return distance < range && Interactable;
        }

    }
}
