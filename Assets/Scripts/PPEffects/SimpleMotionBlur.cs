using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace PPEffects
{
    [System.Serializable]
    [PostProcess(typeof(SimpleMotionBlurRenderer), PostProcessEvent.AfterStack, "Custom/SimpleMotionBlur")]
    public sealed class SimpleMotionBlur : PostProcessEffectSettings
    {
        [Range(0, 0.92f)]
        public FloatParameter BlurAmount = new FloatParameter { value = 0.8f };

        public BoolParameter ExtraBlur = new BoolParameter { value = false };
    }

    public sealed class SimpleMotionBlurRenderer : PostProcessEffectRenderer<SimpleMotionBlur>
    {
        private RenderTexture _accumTexture;

        public override void Render(PostProcessRenderContext context)
        {
            var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/SimpleMotionBlur"));

            // Create the accumulation texture
            if (_accumTexture == null || _accumTexture.width != context.width || _accumTexture.height != context.height)
            {
                _accumTexture = new RenderTexture(context.width, context.height, 0)
                {
                    hideFlags = HideFlags.HideAndDontSave
                };
                context.command.BlitFullscreenTriangle(context.source, _accumTexture);
            }

            // If Extra Blur is selected, downscale the texture to 4x4 smaller resolution.
            if (settings.ExtraBlur)
            {
                var blurBuffer = RenderTexture.GetTemporary(context.width / 4, context.height / 4, 0);
                _accumTexture.MarkRestoreExpected();

                context.command.BlitFullscreenTriangle(_accumTexture, blurBuffer);
                context.command.BlitFullscreenTriangle(blurBuffer, _accumTexture);
                RenderTexture.ReleaseTemporary(blurBuffer);
            }

            // Clamp the motion blur variable, so it can never leave permanent trails in the image
            var blurAmount = Mathf.Clamp( settings.BlurAmount, 0.0f, 0.92f );

            // Setup the texture and floating point values in the shader
            sheet.properties.SetFloat("_AccumOrig", 1.0f - blurAmount);

            // We are accumulating motion over frames without clear/discard
            // by design, so silence any performance warnings from Unity
            _accumTexture.MarkRestoreExpected();

            // Render the image using the motion blur shader
            context.command.BlitFullscreenTriangle(context.source, _accumTexture, sheet, 0);
            context.command.BlitFullscreenTriangle(_accumTexture, context.destination);
        }
    }
}
