using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace PPEffects
{
    [System.Serializable]
    [PostProcess(typeof(DuoToneRenderer), PostProcessEvent.AfterStack, "Custom/DuoTone")]
    public sealed class DuoTone : PostProcessEffectSettings
    {
        [UnityEngine.Rendering.PostProcessing.Min(0)]
        public FloatParameter MinLimit = new FloatParameter { value = 0.25f };
        [UnityEngine.Rendering.PostProcessing.Min(0)]
        public FloatParameter MaxLimit = new FloatParameter { value = 0.75f };
        public ColorParameter Color1 = new ColorParameter {value = new Color(1, 1, 1)};
        public ColorParameter Color2 = new ColorParameter {value = new Color(0.63f, 0.28f, 0.28f)};
    }

    public sealed class DuoToneRenderer : PostProcessEffectRenderer<DuoTone>
    {
        public override void Render(PostProcessRenderContext context)
        {
            var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/DuoTone"));
            sheet.properties.SetFloat("_MinLimit", settings.MinLimit);
            sheet.properties.SetFloat("_MaxLimit", settings.MaxLimit);
            sheet.properties.SetColor("_Color1", settings.Color1);
            sheet.properties.SetColor("_Color2", settings.Color2);
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        }
    }
}
