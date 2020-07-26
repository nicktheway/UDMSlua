Shader "Hidden/Custom/Drunk"
{
    HLSLINCLUDE

		#pragma target 3.0
		#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

		TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
		int _Timer, _Strength;

		float4 Frag(VaryingsDefault i) : SV_Target
		{
			float2 blurs[12] = {
				-0.326212, -0.405805,
				-0.840144, -0.073580,
				-0.695914,  0.457137,
				-0.203345,  0.620716,
				0.962340, -0.194983,
				0.473434, -0.480026,
				0.519456,  0.767022,
				0.185461, -0.893124,
				0.507431,  0.064425,
				0.896420,  0.412458,
				-0.321940, -0.932615,
				-0.791559, -0.597705
			};
		
			float4 finalColor = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);

			UNITY_LOOP
			for (int j = 0; j < 12; j++)
			{
				finalColor += SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord + (0.001f * _Strength) * blurs[j] * (1 + 3 * cos(_Timer + j * 2)));
			}

			return finalColor / 13;
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