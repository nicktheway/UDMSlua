Shader "Hidden/Custom/Colorization"
{
    HLSLINCLUDE

		#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

		TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
		float _RChannel, _GChannel, _BChannel;

		float4 Frag(VaryingsDefault i) : SV_Target
		{
			float3 channels = float3(_RChannel, _GChannel, _BChannel);
			float4 finalColor = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);

			finalColor.rgb = pow(abs(finalColor.rgb), 1.0f / channels);

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