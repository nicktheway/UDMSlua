using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace PPEffects
{
    [System.Serializable]
    [PostProcess(typeof(ThermalVisionRenderer), PostProcessEvent.AfterStack, "Custom/ThermalVision")]
    public sealed class ThermalVision : PostProcessEffectSettings
    {

    }

    public sealed class ThermalVisionRenderer : PostProcessEffectRenderer<ThermalVision>
    {
        public override void Render(PostProcessRenderContext context)
        {
            var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/ThermalVision"));
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        }
    }
}
