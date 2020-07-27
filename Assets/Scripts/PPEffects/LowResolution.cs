using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace PPEffects
{
    [System.Serializable]
    [PostProcess(typeof(LowResolutionRenderer), PostProcessEvent.AfterStack, "Custom/LowResolution")]
    public sealed class LowResolution : PostProcessEffectSettings
    {
        public IntParameter PixelsX = new IntParameter { value = 600 };
        public IntParameter PixelsY = new IntParameter { value = 400 };
    }

    public sealed class LowResolutionRenderer : PostProcessEffectRenderer<LowResolution>
    {
        public override void Render(PostProcessRenderContext context)
        {
            var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/LowResolution"));
            sheet.properties.SetInt("_PixelsX", settings.PixelsX);
            sheet.properties.SetInt("_PixelsY", settings.PixelsY);
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        }
    }
}
