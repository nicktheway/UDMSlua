Shader "Hidden/Custom/Posterization"
{
    HLSLINCLUDE

    #include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

    TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
	float _TonesAmount, _GammaFactor;

    float4 Frag(VaryingsDefault i) : SV_Target
    {
		float3 finalColor = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord).rgb;
        
		finalColor = pow(abs(finalColor), float3(_GammaFactor, _GammaFactor, _GammaFactor));
		finalColor *= _TonesAmount;
		finalColor = floor(finalColor);
		finalColor /= _TonesAmount;
		finalColor = pow(abs(finalColor), (float3)(1 / _GammaFactor));

        return float4(finalColor, 1);
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