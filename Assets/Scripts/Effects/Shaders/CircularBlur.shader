Shader "Hidden/Custom/CircularBlur"
{
    HLSLINCLUDE

		#pragma target 3.0
		#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

		TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
		int _Samples;
		float _Strength;

		float4 Frag(VaryingsDefault i) : SV_Target
		{
			float2 offset = i.texcoord - float2(0.5f, 0.5f);
			float radius = length(offset);
			float theta = atan2(offset.y, offset.x);

			float4 finalColor = (float4) 0;
			float2 tapCoords = (float2) 0;

			UNITY_LOOP
			for (int j = 0; j < _Samples; j++)
			{
				float tapTheta = theta + j * (_Strength * 0.1f / _Samples);
				float tapR = radius;
				tapCoords.x = tapR * cos(tapTheta) + 0.5f;
				tapCoords.y = tapR * sin(tapTheta) + 0.5f;

				finalColor += SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, tapCoords);
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