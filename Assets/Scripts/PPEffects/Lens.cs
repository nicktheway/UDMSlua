using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace PPEffects
{
    [System.Serializable]
    [PostProcess(typeof(LensRenderer), PostProcessEvent.AfterStack, "Custom/Lens")]
    public sealed class Lens : PostProcessEffectSettings
    {
        public FloatParameter LensDistortion = new FloatParameter { value = 0.5f };
        public FloatParameter CubicDistortion = new FloatParameter { value = 0.5f };
    }

    public sealed class LensRenderer : PostProcessEffectRenderer<Lens>
    {
        public override void Render(PostProcessRenderContext context)
        {
            var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/Lens"));
            sheet.properties.SetFloat("_LensDistortion", settings.LensDistortion);
            sheet.properties.SetFloat("_CubicDistortion", settings.CubicDistortion);
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        }
    }
}
