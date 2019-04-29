using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace AtLib.Gallery
{
    public class SelectSystemManager : MonoBehaviour
    {

        private static SelectSystemManager m_instance;

        public static SelectSystemManager instance
        {
            get
            {
                if (m_instance == null)
                {
#if UNITY_EDITOR
                    m_instance = GameObject.FindObjectOfType<SelectSystemManager>();
#endif
                }

                return m_instance;
            }
        }
        
        public LayerMask cullMask;
        public float maxDistance = 30f;
        public float defaultDistance = 10f;
        public SelectableObjectProfile defaultProfile;

        [SerializeField]
        [ReadOnly]
        private  SelectableObject m_temFocus;


        public float delayTimer = 0;

        public float delayRate
        {
            get
            {
                if (temFocus != null && temFocus.profile.type == SelectableObjectProfile.Type.Delay)
                {
                    float rate = delayTimer / temFocus.profile.delayFocusDuration;

                    return Mathf.Clamp01(rate);
                }

                return 0;
            }
        }

        public SelectableObject temFocus
        {
            get { return m_temFocus; }

            set
            {
                var saveTem = m_temFocus;
                m_temFocus = value;


                if (saveTem != value)
                {
                }
            }
        }

        public string temTips
        {
            get
            {
                return temFocus == null
                    ? ""
                    : (temFocus.IsOverrideTips ? temFocus.tips : defaultProfile.scanTips.value );
            }
        }

        public SelectableObject GetFocusObject()
        {
            var cam = Camera.main;
            RaycastHit rayInfo;

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out rayInfo,
                maxDistance, cullMask.value))
            {
                var obj = rayInfo.collider.gameObject.GetComponent<SelectableObject>();

                if (obj != null)
                {
                    if (obj.IsAbleToScan(rayInfo.distance))
                    {
                        return obj;
                    }
                }
            }

            return null;
        }

        public void Start()
        {
            m_instance = this;
        }

        public void Update()
        {
            temFocus = GetFocusObject();

            if (temFocus != null )
            {
                if (temFocus.profile.type == SelectableObjectProfile.Type.Normal)
                {
                    if ( IsSelected() )
                        temFocus.Interact();
                }
                else if ( temFocus.profile.type == SelectableObjectProfile.Type.Delay )
                {
                    if (IsSelecting())
                    {
                        delayTimer += Time.deltaTime;
                    }
                    else
                    {
                        delayTimer = 0;
                    }

                    if (delayTimer > temFocus.profile.delayFocusDuration)
                    {
                        temFocus.Interact();
                    }
                }
            }

            if (temFocus == null || !IsSelecting())
            {
                delayTimer = 0;
            }
        }

        public bool IsSelected()
        {
            return Input.GetKeyDown(KeyCode.E);
        }

        public bool IsSelecting()
        {
            return false;
        }
    }

   
}
