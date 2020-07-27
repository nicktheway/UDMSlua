using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace PPEffects
{
    [System.Serializable]
    [PostProcess(typeof(EmbossRenderer), PostProcessEvent.AfterStack, "Custom/Emboss")]
    public sealed class Emboss : PostProcessEffectSettings
    {
        [UnityEngine.Rendering.PostProcessing.Min(2)]
        public BoolParameter Greyscale = new BoolParameter { value = false };
        public FloatParameter Strength = new FloatParameter { value = 1.5f };
    }

    public sealed class EmbossRenderer : PostProcessEffectRenderer<Emboss>
    {
        public override void Render(PostProcessRenderContext context)
        {
            var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/Emboss"));
            sheet.properties.SetInt("_Greyscale", settings.Greyscale ? 1 : 0);
            sheet.properties.SetFloat("_Strength", settings.Strength);
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        }
    }
}
