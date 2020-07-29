Shader "Hidden/Custom/SimpleLUT"
{
    HLSLINCLUDE

    #include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

    TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
	TEXTURE3D_SAMPLER3D(_ClutTex, sampler_ClutTex);
	float _Amount;
	float4 _TintColor;
	float _Hue;
	float _Saturation;
	float _Brightness;
	float _Contrast;
	float _Scale;
	float _Offset;
	float2 _ImageWidthFactor;
	float2 _ImageHeightFactor;
	float _SharpnessCenterMultiplier;
	float _SharpnessEdgeMultiplier;

	inline float3 applyHue(float3 aColor)
	{
		float angle = radians(_Hue);
		float3 k = float3(0.57735, 0.57735, 0.57735);
		float cosAngle = cos(angle);

		return aColor * cosAngle + cross(k, aColor) * sin(angle) + k * dot(k, aColor) * (1 - cosAngle);
	}

	inline float3 applyHSBEffect(float3 c)
	{
		c.rgb = applyHue(c.rgb);
		c.rgb = ((c.rgb - 0.5f) * _Contrast) + 0.5f;
		c.rgb *= _Brightness;
		float3 intensity = dot(c.rgb, float3(0.299, 0.587, 0.114));
		c.rgb = lerp(intensity, c.rgb, _Saturation);

		return c;
	}

	inline float3 applySharpness(float3 c, float2 uv)
	{
		return (c * _SharpnessCenterMultiplier) -
		(
			(SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, uv - _ImageWidthFactor).rgb * _SharpnessEdgeMultiplier) +
			(SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, uv + _ImageWidthFactor).rgb * _SharpnessEdgeMultiplier) +
			(SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, uv + _ImageHeightFactor).rgb * _SharpnessEdgeMultiplier) +
			(SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, uv - _ImageHeightFactor).rgb * _SharpnessEdgeMultiplier)
		);
	}

    float4 Frag(VaryingsDefault i) : SV_Target
    {
		float4 c = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
		c.rgb = applySharpness(c.rgb, i.texcoord);
		c.rgb = applyHSBEffect(c.rgb);
		float3 correctedColor = SAMPLE_TEXTURE3D(_ClutTex, sampler_ClutTex, c.rgb * _Scale + _Offset).rgb;
		c.rgb = lerp(c.rgb, correctedColor, _Amount) * _TintColor.rgb;

        return c;
    }

	float4 FragLinear(VaryingsDefault i) : SV_Target
	{
		float4 c = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
		c.rgb = applySharpness(c.rgb, i.texcoord);
		c.rgb = sqrt(c.rgb);
		c.rgb = applyHSBEffect(c.rgb);
		float3 correctedColor = SAMPLE_TEXTURE3D(_ClutTex, sampler_ClutTex, c.rgb * _Scale + _Offset).rgb;
		c.rgb = lerp(c.rgb, correctedColor, _Amount) * _TintColor.rgb;
		c.rgb *= c.rgb;

		return c;
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
				#pragma target 3.0

            ENDHLSL
        }

		Pass
        {
            HLSLPROGRAM

                #pragma vertex VertDefault
                #pragma fragment FragLinear
				#pragma target 3.0

            ENDHLSL
        }
    }
}