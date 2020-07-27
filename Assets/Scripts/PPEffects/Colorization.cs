using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace PPEffects
{
    [System.Serializable]
    [PostProcess(typeof(ColorizationRenderer), PostProcessEvent.AfterStack, "Custom/Colorization")]
    public sealed class Colorization : PostProcessEffectSettings
    {
        public FloatParameter RChannel = new FloatParameter { value = 0.5f };
        public FloatParameter GChannel = new FloatParameter { value = 0.5f };
        public FloatParameter BChannel = new FloatParameter { value = 0.5f };
    }

    public sealed class ColorizationRenderer : PostProcessEffectRenderer<Colorization>
    {
        public override void Render(PostProcessRenderContext context)
        {
            var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/Colorization"));
            sheet.properties.SetFloat("_RChannel", settings.RChannel);
            sheet.properties.SetFloat("_GChannel", settings.GChannel);
            sheet.properties.SetFloat("_BChannel", settings.BChannel);
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        }
    }
}
