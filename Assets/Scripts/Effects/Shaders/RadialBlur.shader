Shader "Hidden/Custom/RadialBlur"
{
    HLSLINCLUDE

		#pragma target 3.0
		#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

		TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
		int _Samples;
		float _Strength;
		float _CenterX;
		float _CenterY;

		float4 Frag(VaryingsDefault i) : SV_Target
		{
			float2 center = float2(_CenterX, _CenterY);
			float4 finalColor = (float4) 0;

			UNITY_LOOP
			for (int j = 0; j < _Samples; j++)
			{
				float scale = 1.0f - _Strength * 0.1f * (j / (float) (_Samples - 1));

				finalColor += SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, (i.texcoord - center) * scale + center);
			}

			return finalColor / _Samples;
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