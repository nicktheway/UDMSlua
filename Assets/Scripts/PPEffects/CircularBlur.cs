using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace PPEffects
{
    [System.Serializable]
    [PostProcess(typeof(CircularBlurRenderer), PostProcessEvent.AfterStack, "Custom/CircularBlur")]
    public sealed class CircularBlur : PostProcessEffectSettings
    {
        [UnityEngine.Rendering.PostProcessing.Min(2)]
        public IntParameter Samples = new IntParameter { value = 5 };
        public FloatParameter Strength = new FloatParameter { value = 1.5f };
    }

    public sealed class CircularBlurRenderer : PostProcessEffectRenderer<CircularBlur>
    {
        public override void Render(PostProcessRenderContext context)
        {
            var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/CircularBlur"));
            sheet.properties.SetInt("_Samples", settings.Samples);
            sheet.properties.SetFloat("_Strength", settings.Strength);
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        }
    }
}
