Shader "Hidden/Custom/Sobel"
{
    HLSLINCLUDE

		#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

		TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
		int _ShowBackground;
		float _Threshold;
		float4 _EdgeColor, _BackgroundColor;

		float4 Frag(VaryingsDefault i) : SV_Target
		{
			float4 lum = float4(0.30f, 0.59f, 0.11f, 1);

			float sob11 = dot(SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord + float2(-1.0f / 1024.0f, -1.0f / 768.0f)), lum);
			float sob12 = dot(SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord + float2(0, -1.0f / 768.0f)), lum);
			float sob13 = dot(SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord + float2(1.0f / 1024.0f, -1.0f / 768.0f)), lum);
			float sob21 = dot(SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord + float2(-1.0f / 1024.0f, 0)), lum);
			float sob23 = dot(SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord + float2(-1.0f / 1024.0f, 0)), lum);	 
			float sob31 = dot(SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord + float2(-1.0f / 1024.0f, 1.0f / 768.0f)), lum);
			float sob32 = dot(SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord + float2(0, 1.0f / 768.0f)), lum);
			float sob33 = dot(SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord + float2(1.0f / 1024.0f, 1.0f / 768.0f)), lum);
			
			float t1 = sob13 + sob33 + (2 * sob23) - sob11 - (2 * sob21) - sob31;
			float t2 = sob31 + (2 * sob32) + sob33 - sob11 - (2 * sob12) - sob13;
			
			float4 finalColor;

			if ((t1 * t1) + (t2 * t2) > _Threshold * 0.01f)
			{
				finalColor = _EdgeColor;
			}
			else 
			{
				if (_ShowBackground == 1)
				{
					finalColor = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
				}
				else 
				{
					finalColor = _BackgroundColor;
				}
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