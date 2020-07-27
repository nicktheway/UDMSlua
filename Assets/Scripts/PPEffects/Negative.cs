﻿using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace PPEffects
{
    [System.Serializable]
    [PostProcess(typeof(NegativeRenderer), PostProcessEvent.AfterStack, "Custom/Negative")]
    public sealed class Negative : PostProcessEffectSettings
    {

    }

    public sealed class NegativeRenderer : PostProcessEffectRenderer<Negative>
    {
        public override void Render(PostProcessRenderContext context)
        {
            var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/Negative"));
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        }
    }
}
