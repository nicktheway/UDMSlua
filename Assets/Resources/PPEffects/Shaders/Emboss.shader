Shader "Hidden/Custom/Emboss"
{
    HLSLINCLUDE

		#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

		TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
		int _Greyscale;
		float _Strength;

		float4 Frag(VaryingsDefault i) : SV_Target
		{
			float4 finalColor = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);

			finalColor -= SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord - _Strength * 0.001f) * 2.7f;
			finalColor += SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord + _Strength * 0.001f) * 2.7f;

			if (_Greyscale == 1)
			{
				finalColor.rgb = (finalColor.r + finalColor.g + finalColor.b) / 3;
			}

			return finalColor;
		}

    ENDHLSL

    SubShader
    {
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            HLSLPROGRAM

                #pragma vertex VertDefault
                #pragma fragment Frag

            ENDHLSL
        }
    }
}