using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace PPEffects
{
    [System.Serializable]
    [PostProcess(typeof(SobelRenderer), PostProcessEvent.AfterStack, "Custom/Sobel")]
    public sealed class Sobel : PostProcessEffectSettings
    {
        public BoolParameter ShowBackground = new BoolParameter { value = false };
        public FloatParameter Threshold = new FloatParameter { value = 0.2f };
        public ColorParameter EdgeColor = new ColorParameter {value = new Color(0, 0, 0)};
        public ColorParameter BackgroundColor = new ColorParameter {value = new Color(1, 1, 1)};
    }

    public sealed class SobelRenderer : PostProcessEffectRenderer<Sobel>
    {
        public override void Render(PostProcessRenderContext context)
        {
            var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/Sobel"));
            sheet.properties.SetInt("_ShowBackground", settings.ShowBackground ? 1 : 0);
            sheet.properties.SetFloat("_Threshold", settings.Threshold);
            sheet.properties.SetColor("_EdgeColor", settings.EdgeColor);
            sheet.properties.SetColor("_BackgroundColor", settings.BackgroundColor);
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        }
    }
}
