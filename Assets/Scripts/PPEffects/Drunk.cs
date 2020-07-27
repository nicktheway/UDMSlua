using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace PPEffects
{
    [System.Serializable]
    [PostProcess(typeof(DrunkRenderer), PostProcessEvent.AfterStack, "Custom/Drunk")]
    public sealed class Drunk : PostProcessEffectSettings
    {
        public IntParameter Timer = new IntParameter { value = 10 };
        public IntParameter Strength = new IntParameter { value = 100 };
    }

    public sealed class DrunkRenderer : PostProcessEffectRenderer<Drunk>
    {
        public override void Render(PostProcessRenderContext context)
        {
            var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/Drunk"));
            sheet.properties.SetInt("_Timer", settings.Timer);
            sheet.properties.SetInt("_Strength", settings.Strength);
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        }
    }
}
