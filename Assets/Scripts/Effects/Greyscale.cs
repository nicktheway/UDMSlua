using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Effects
{
    [System.Serializable]
    [PostProcess(typeof(GreyscaleRenderer), PostProcessEvent.AfterStack, "Custom/Greyscale")]
    public sealed class Greyscale : PostProcessEffectSettings
    {
        [Range(0f, 1f), Tooltip("Greyscale effect intensity.")]
        public FloatParameter Blend = new FloatParameter { value = 0.5f };
    }

    public sealed class GreyscaleRenderer : PostProcessEffectRenderer<Greyscale>
    {
        public override void Render(PostProcessRenderContext context)
        {
            var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/Greyscale"));
            sheet.properties.SetFloat("_Blend", settings.Blend);
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        }
    }
}
