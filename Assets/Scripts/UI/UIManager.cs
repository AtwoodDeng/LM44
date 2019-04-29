using System.Collections;
using System.Collections.Generic;
using AtLib.Gallery;
using UnityEngine;
using UnityEngine.UI;


namespace AtLib
{
    public class UIManager : MonoBehaviour
    {
        public Text SelectTips;

        public void Update()
        {
            SelectTips.text = SelectSystemManager.instance.temTips;
        }
    }
}
