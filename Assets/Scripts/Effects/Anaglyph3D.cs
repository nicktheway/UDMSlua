using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Effects
{
    [System.Serializable]
    [PostProcess(typeof(Anaglyph3DRenderer), PostProcessEvent.AfterStack, "Custom/Anaglyph3D")]
    public sealed class Anaglyph3D : PostProcessEffectSettings
    {

    }

    public sealed class Anaglyph3DRenderer : PostProcessEffectRenderer<Anaglyph3D>
    {
        public override void Render(PostProcessRenderContext context)
        {
            var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/Anaglyph3D"));
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        }
    }
}
