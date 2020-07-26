Shader "Hidden/Custom/NightVision"
{
    HLSLINCLUDE

		#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

		TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
		float _Timer;
		float _LuminosityThreshold;
		float _Amplification;
		float _NoiseStrength, _LinesStrength;
		float _TextureOffset;
		int _LinesAmount, _NoiseSaturation;

		float4 Frag(VaryingsDefault i) : SV_Target
		{
			float4 cameraTex = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);

			float x = i.texcoord.x * i.texcoord.y * _Timer * 1000 + 10;
			x = fmod(x, 20) * fmod(x, 150);
			float dx = fmod(x, 0.01f);

			float3 noise = cameraTex.rgb + cameraTex.rgb * saturate(0.2f + dx.xxx * 100);

			float2 sclines;
			sincos(i.texcoord.y * _LinesAmount, sclines.x, sclines.y);
			noise += cameraTex.rgb * float3(sclines.x, sclines.y, sclines.x) * _LinesStrength;

			if (_NoiseSaturation == 1)
				noise = lerp(cameraTex.xyz, noise, saturate(_NoiseStrength));
			else
				noise = lerp(cameraTex.xyz, noise, _NoiseStrength);

			float4 noiseResult = float4(noise, 1);

			float3 finalColor = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord + noiseResult.xy * 0.005f * _TextureOffset).rgb;

			float green = dot(float3(0.3f, 0.59f, 0.11f), finalColor);
			if (green < _LuminosityThreshold) finalColor *= _Amplification;

			float3 vision = float3(0.1f, 0.9f, 0.2f);


			return float4((finalColor + (noiseResult.xyz * 0.2f)) * vision, 1);
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