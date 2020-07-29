using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace PPEffects
{
    [System.Serializable]
    [PostProcess(typeof(SimpleLUTRenderer), PostProcessEvent.AfterStack, "Custom/SimpleLUT")]
    public sealed class SimpleLUT : PostProcessEffectSettings
    {
        [Tooltip("Texture to use for the lookup. Make sure it has read/write enabled and mipmaps disabled. The height must equal the square root of the width.")]
        public TextureParameter LookupTexture = new TextureParameter();

        [Range(0, 1)]
        [Tooltip("Lerp between original (0) and corrected color (1)")]
        public FloatParameter Amount =  new FloatParameter { value = 1f };

        [Tooltip("Tint color, applied to the final pixel")]
        public ColorParameter TintColor = new ColorParameter { value = Color.white };

        [Range(0, 360)]
        [Tooltip("Hue")]
        public FloatParameter Hue = new FloatParameter { value = 0f };

        [Range(-1, 1)]
        [Tooltip("Saturation")]
        public FloatParameter Saturation = new FloatParameter { value = 0f };

        [Range(-1, 1)]
        [Tooltip("Brightness")]
        public FloatParameter Brightness = new FloatParameter { value = 0f };

        [Range(-1, 1)]
        [Tooltip("Contrast")]
        public FloatParameter Contrast = new FloatParameter { value = 0f };

        [Range(0, 1)]
        [Tooltip("Sharpness")]
        public FloatParameter Sharpness = new FloatParameter { value = 0f };
    }

    public sealed class SimpleLUTRenderer : PostProcessEffectRenderer<SimpleLUT>
    {
        private Texture3D _converted3DLut;
        private int _lutSize;

        public override void Render(PostProcessRenderContext context)
        {
            if (settings.LookupTexture == null)
            {
                SetIdentityLut();
            }
            else
            {
                Convert(settings.LookupTexture.value as Texture2D);
            }

            if (_converted3DLut == null)
            {
                context.command.BlitFullscreenTriangle(context.source, context.destination);
                return;
            }

            var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/SimpleLUT"));
            sheet.properties.SetTexture("_ClutTex", _converted3DLut);
            sheet.properties.SetFloat("_Amount", settings.Amount);
            sheet.properties.SetColor("_TintColor", settings.TintColor);
            sheet.properties.SetFloat("_Hue", settings.Hue);
            sheet.properties.SetFloat("_Saturation", settings.Saturation + 1.0f);
            sheet.properties.SetFloat("_Brightness", settings.Brightness + 1.0f);
            sheet.properties.SetFloat("_Contrast", settings.Contrast + 1.0f);
            sheet.properties.SetFloat("_Scale", (_lutSize - 1) / (1.0f * _lutSize));
            sheet.properties.SetFloat("_Offset", 1.0f / (2.0f * _lutSize));


            var actualSharpness = settings.Sharpness * 4.0f * 0.2f;
            sheet.properties.SetFloat("_SharpnessCenterMultiplier", 1.0f + (4.0f * actualSharpness));
            sheet.properties.SetFloat("_SharpnessEdgeMultiplier", actualSharpness);
            sheet.properties.SetVector("_ImageWidthFactor", new Vector4(1.0f / context.width, 0.0f, 0.0f, 0.0f));
            sheet.properties.SetVector("_ImageHeightFactor", new Vector4(0.0f, 1.0f / context.height, 0.0f, 0.0f));

            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, QualitySettings.activeColorSpace == ColorSpace.Linear ? 1 : 0);
        }

        public void SetIdentityLut()
        {
            if (!SystemInfo.supports3DTextures)
            {
                return;
            }
            
            _converted3DLut = null;

            var dim = 16;
            var newC = new Color[dim * dim * dim];
            var oneOverDim = 1.0f / (1.0f * dim - 1.0f);

            for (var i = 0; i < dim; i++)
            {
                for (var j = 0; j < dim; j++)
                {
                    for (var k = 0; k < dim; k++)
                    {
                        newC[i + (j * dim) + (k * dim * dim)] = new Color((i * 1.0f) * oneOverDim, (j * 1.0f) * oneOverDim, (k * 1.0f) * oneOverDim, 1.0f);
                    }
                }
            }

            _converted3DLut = new Texture3D(dim, dim, dim, TextureFormat.ARGB32, false);
            _converted3DLut.SetPixels(newC);
            _converted3DLut.Apply();
            _lutSize = _converted3DLut.width;
            _converted3DLut.wrapMode = TextureWrapMode.Clamp;
        }

        
        public bool ValidDimensions(Texture2D tex2d)
        {
            if (tex2d == null)
            {
                return false;
            }

            var h = tex2d.height;
            return h == Mathf.FloorToInt(Mathf.Sqrt(tex2d.width));
        }

        internal bool Convert(Texture2D lookupTexture)
        {
            if (!SystemInfo.supports3DTextures)
            {
                Debug.LogError("System does not support 3D textures");
                return false;
            }

            if (lookupTexture == null)
            {
                SetIdentityLut();
            }
            else
            {
                _converted3DLut = null;

                if (lookupTexture.mipmapCount > 1)
                {
                    Debug.LogError("Lookup texture must not have mipmaps");
                    return false;
                }

                try
                {
                    var dim = lookupTexture.width * lookupTexture.height;
                    dim = lookupTexture.height;

                    if (!ValidDimensions(lookupTexture))
                    {
                        Debug.LogError("Lookup texture dimensions must be a power of two. The height must equal the square root of the width.");
                        return false;
                    }

                    var c = lookupTexture.GetPixels();
                    var newC = new Color[c.Length];

                    for (var i = 0; i < dim; i++)
                    {
                        for (var j = 0; j < dim; j++)
                        {
                            for (var k = 0; k < dim; k++)
                            {
                                var j_ = dim - j - 1;
                                newC[i + (j * dim) + (k * dim * dim)] = c[k * dim + i + j_ * dim * dim];
                            }
                        }
                    }

                    _converted3DLut = new Texture3D(dim, dim, dim, TextureFormat.ARGB32, false);
                    _converted3DLut.SetPixels(newC);
                    _converted3DLut.Apply();
                    _lutSize = _converted3DLut.width;
                    _converted3DLut.wrapMode = TextureWrapMode.Clamp;
                }
                catch (Exception ex)
                {
                    Debug.LogError("Unable to convert texture to LUT texture, make sure it is read/write. Error: " + ex);
                }
            }

            return true;
        }
    }
}
