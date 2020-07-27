using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace PPEffects
{
    [System.Serializable]
    [PostProcess(typeof(WiggleRenderer), PostProcessEvent.AfterStack, "Custom/Wiggle")]
    public sealed class Wiggle : PostProcessEffectSettings
    {
        public FloatParameter Timer = new FloatParameter { value = 10f };
        public FloatParameter Speed = new FloatParameter { value = 15f };
        public FloatParameter AmplitudeX = new FloatParameter { value = 5f };
        public FloatParameter AmplitudeY = new FloatParameter { value = 5f };
        public FloatParameter DistortionX = new FloatParameter { value = 5f };
        public FloatParameter DistortionY = new FloatParameter { value = 5f };
    }

    public sealed class WiggleRenderer : PostProcessEffectRenderer<Wiggle>
    {
        public override void Render(PostProcessRenderContext context)
        {
            var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/Wiggle"));
            sheet.properties.SetFloat("_Timer", settings.Timer);
            sheet.properties.SetFloat("_Speed", settings.Speed);
            sheet.properties.SetFloat("_AmplitudeX", settings.AmplitudeX);
            sheet.properties.SetFloat("_AmplitudeY", settings.AmplitudeY);
            sheet.properties.SetFloat("_DistortionX", settings.DistortionX);
            sheet.properties.SetFloat("_DistortionY", settings.DistortionY);
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        }
    }
}
