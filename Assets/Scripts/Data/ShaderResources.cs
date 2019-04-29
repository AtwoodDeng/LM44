using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtLib.Gallery
{
    [CreateAssetMenu(fileName = "ShaderResources", menuName = "Atlib/ShaderResource" )]
    public class ShaderResources : ScriptableObject
    {
        public Shader AnalogGlitchShader;
        public Shader DigtialGlitchShader;
    }
}