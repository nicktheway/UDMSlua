﻿using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace PPEffects
{
    [System.Serializable]
    [PostProcess(typeof(NightVisionRenderer), PostProcessEvent.AfterStack, "Custom/NightVision")]
    public sealed class NightVision : PostProcessEffectSettings
    {
        public FloatParameter Timer = new FloatParameter { value = 1 };
        public IntParameter LinesAmount = new IntParameter { value = 30 };
        public FloatParameter LinesStrength = new FloatParameter { value = 2.2f };
        public BoolParameter NoiseSaturation = new BoolParameter { value = false };
        public FloatParameter NoiseStrength = new FloatParameter { value = 2.0f };
        public FloatParameter LuminosityThreshold = new FloatParameter { value = 0.5f };
        public FloatParameter Amplification = new FloatParameter { value = 2.0f };
        public FloatParameter TextureOffset = new FloatParameter { value = 0.5f };
    }

    public sealed class NightVisionRenderer : PostProcessEffectRenderer<NightVision>
    {
        public override void Render(PostProcessRenderContext context)
        {
            var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/NightVision"));
            sheet.properties.SetFloat("_Timer", settings.Timer);
            sheet.properties.SetInt("_LinesAmount", settings.LinesAmount);
            sheet.properties.SetFloat("_LinesStrength", settings.LinesStrength);
            sheet.properties.SetInt("_NoiseSaturation", settings.NoiseSaturation ? 1 : 0);
            sheet.properties.SetFloat("_NoiseStrength", settings.NoiseStrength);
            sheet.properties.SetFloat("_LuminosityThreshold", settings.LuminosityThreshold);
            sheet.properties.SetFloat("_Amplification", settings.Amplification);
            sheet.properties.SetFloat("_TextureOffset", settings.TextureOffset);
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        }
    }
}
