using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace PPEffects
{
    [System.Serializable]
    [PostProcess(typeof(ScannerRenderer), PostProcessEvent.AfterStack, "Custom/Scanner")]
    public sealed class Scanner : PostProcessEffectSettings
    {
        public FloatParameter Timer = new FloatParameter { value = 10f };
        public FloatParameter LinesIntensity = new FloatParameter { value = 0.1f };
        public FloatParameter LinesSpeed = new FloatParameter { value = 5f };
        public FloatParameter LinesAmount = new FloatParameter { value = 80f };
    }

    public sealed class ScannerRenderer : PostProcessEffectRenderer<Scanner>
    {
        public override void Render(PostProcessRenderContext context)
        {
            var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/Scanner"));
            sheet.properties.SetFloat("_Timer", settings.Timer);
            sheet.properties.SetFloat("_LinesIntensity", settings.LinesIntensity);
            sheet.properties.SetFloat("_LinesSpeed", settings.LinesSpeed);
            sheet.properties.SetFloat("_LinesAmount", settings.LinesAmount);
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        }
    }
}
