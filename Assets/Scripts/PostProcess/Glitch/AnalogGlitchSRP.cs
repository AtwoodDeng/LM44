using System;
using AtLib.Gallery;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
namespace Kino
{
    [Serializable]
    [PostProcess(typeof(AnalogGlitchRender) , PostProcessEvent.AfterStack , "Custom/AnalogGlitch", true )]
    public class AnalogGlitchSRP : PostProcessEffectSettings
    {

        #region Public Properties

        // Scan line jitter

        [Range(0, 1)]
        public FloatParameter _scanLineJitter = new FloatParameter { value = 0 };

        //public float scanLineJitter
        //{
        //    get { return _scanLineJitter; }
        //    set { _scanLineJitter = value; }
        //}

        // Vertical jump

        [Range(0, 1)]
        public FloatParameter _verticalJump = new FloatParameter { value = 0 };

        //public float verticalJump
        //{
        //    get { return _verticalJump; }
        //    set { _verticalJump = value; }
        //}

        // Horizontal shake

        [Range(0, 1)]
        public FloatParameter _horizontalShake = new FloatParameter { value = 0 };

        //public float horizontalShake
        //{
        //    get { return _horizontalShake; }
        //    set { _horizontalShake = value; }
        //}

        // Color drift

        //[SerializeField, Range(0, 1)]
        //float _colorDrift = 0;
        [Range(0, 1)]
        public FloatParameter _colorDrift = new FloatParameter { value = 0 };


        //public float colorDrift
        //{
        //    get { return _colorDrift; }
        //    set { _colorDrift = value; }
        //}

        #endregion
    }

    public class AnalogGlitchRender : PostProcessEffectRenderer<AnalogGlitchSRP>
    {
        private Material mat;

        float _verticalJumpTime;
        public override void Init()
        {
            mat = new Material(ShaderLoader.ShaderResources.AnalogGlitchShader);
        }

        public override void Render(PostProcessRenderContext context)
        {
            var cmd = context.command;
            cmd.BeginSample("Glitch");

            _verticalJumpTime += Time.deltaTime * settings._verticalJump * 11.3f;

            // var sheet = context.propertySheets.Get(ShaderLoader.ShaderResources.AnalogGlitchShader);

            var sl_thresh = Mathf.Clamp01(1.0f - settings._scanLineJitter * 1.2f);
            var sl_disp = 0.002f + Mathf.Pow(settings._scanLineJitter, 3) * 0.05f;

            if ( mat == null )
                mat = new Material(ShaderLoader.ShaderResources.AnalogGlitchShader);

            mat.SetVector("_ScanLineJitter", new Vector2(sl_disp, sl_thresh));

            var vj = new Vector2(settings._verticalJump, _verticalJumpTime);
            mat.SetVector("_VerticalJump", vj);

            var cd = new Vector2(settings._colorDrift * 0.04f, Time.time * 606.11f);
            mat.SetVector("_ColorDrift", cd);

            cmd.SetGlobalTexture("_MainTex", context.source);
            cmd.Blit(context.source, context.destination,mat);
            //cmd
            //cmd.BlitFullscreenTriangle(context.source, context.destination, sheet, 0,RenderBufferLoadAction.Load);

            cmd.EndSample("Glitch");
        }
    }
}
