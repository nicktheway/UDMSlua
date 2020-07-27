using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace PPEffects
{
    [System.Serializable]
    [PostProcess(typeof(RadialBlurRenderer), PostProcessEvent.AfterStack, "Custom/RadialBlur")]
    public sealed class RadialBlur : PostProcessEffectSettings
    {
        [UnityEngine.Rendering.PostProcessing.Min(2)]
        public IntParameter Samples = new IntParameter { value = 5 };
        public FloatParameter Strength = new FloatParameter { value = 1.5f };
        public FloatParameter CenterX = new FloatParameter { value = 0.5f };
        public FloatParameter CenterY = new FloatParameter { value = 0.5f };
    }

    public sealed class RadialBlurRenderer : PostProcessEffectRenderer<RadialBlur>
    {
        public override void Render(PostProcessRenderContext context)
        {
            var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/RadialBlur"));
            sheet.properties.SetInt("_Samples", settings.Samples);
            sheet.properties.SetFloat("_Strength", settings.Strength);
            sheet.properties.SetFloat("_CenterX", settings.CenterX);
            sheet.properties.SetFloat("_CenterY", settings.CenterY);
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        }
    }
}
