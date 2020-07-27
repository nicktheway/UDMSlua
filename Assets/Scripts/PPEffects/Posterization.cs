using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace PPEffects
{
    [System.Serializable]
    [PostProcess(typeof(PosterizationRenderer), PostProcessEvent.AfterStack, "Custom/Posterization")]
    public sealed class Posterization : PostProcessEffectSettings
    {
        public FloatParameter TonesAmount = new FloatParameter { value = 5 };
        public FloatParameter GammaFactor = new FloatParameter { value = 0.5f };
    }

    public sealed class PosterizationRenderer : PostProcessEffectRenderer<Posterization>
    {
        public override void Render(PostProcessRenderContext context)
        {
            var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/Posterization"));
            sheet.properties.SetFloat("_TonesAmount", settings.TonesAmount);
            sheet.properties.SetFloat("_GammaFactor", settings.GammaFactor);
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        }
    }
}
