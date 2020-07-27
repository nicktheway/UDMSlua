using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace PPEffects
{
    [System.Serializable]
    [PostProcess(typeof(LaplacianRenderer), PostProcessEvent.AfterStack, "Custom/Laplacian")]
    public sealed class Laplacian : PostProcessEffectSettings
    {

    }

    public sealed class LaplacianRenderer : PostProcessEffectRenderer<Laplacian>
    {
        public override void Render(PostProcessRenderContext context)
        {
            var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/Laplacian"));
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        }
    }
}
