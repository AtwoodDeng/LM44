using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;
using Path = System.IO.Path;

namespace AtLib.Gallery
{
    public class MaterialCreater : OdinEditorWindow
    {
        public List<Texture> textures;
        [MenuItem("Gallery/Tools/Material")]
        public static void Open()
        {
            GetWindow<MaterialCreater>(true);
        }

        [Button]
        public void CreateMaterial()
        {
            if (textures == null || textures.Count < 0)
            {
                Debug.LogError("No Textures Found ");
                return;
            }

            var path = AssetDatabase.GetAssetPath(textures[0]);
            var name = Path.GetFileName(path);
            var matName = name.Split('_')[0] + "_" + name.Split('_')[1] + ".mat";
            path = path.Replace(name, matName);

            var material = new Material(Shader.Find("HDRP/Lit"));

            foreach (var tex in textures)
            {
                if (tex.name.Contains("BaseColor"))
                    material.SetTexture("_BaseColorMap", tex);
                if (tex.name.Contains("MADR"))
                    material.SetTexture("_MaskMap", tex);
                if (tex.name.Contains("Normal"))
                    material.SetTexture("_NormalMap", tex);
            }
            material.SetFloat("_Metallic" , 1f );

            textures.Clear();

            AssetDatabase.CreateAsset(material, path);

            Debug.Log("successfully create material at " + path);

        }


        [Button]
        public void Clear()
        {
            textures.Clear();
        }
    }
}
