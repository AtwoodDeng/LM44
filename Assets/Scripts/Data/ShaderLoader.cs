
using UnityEngine;

namespace AtLib.Gallery
{

    public class ShaderLoader : MonoBehaviour
    {
        private static ShaderResources resources;

        public static ShaderResources ShaderResources
        {
            get
            {
                if (resources == null)
                {
                    resources = Resources.Load<ShaderResources>("Data/ShaderResources");
                }

                return resources;
            }
        }
    }
}