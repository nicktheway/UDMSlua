Shader "Hidden/Custom/Lens"
{
    HLSLINCLUDE

    #include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

    TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
	float _LensDistortion, _CubicDistortion;

    float4 Frag(VaryingsDefault i) : SV_Target
    {
		float dist = pow(abs(i.texcoord.x - 0.5f), 2) + pow(abs(i.texcoord.y - 0.5f), 2);
		float factor = 1 + dist * (_LensDistortion + _CubicDistortion * sqrt(dist));

		float xdistortion = factor * (i.texcoord.x - 0.5f) + 0.5f;
		float ydistortion = factor * (i.texcoord.y - 0.5f) + 0.5f;

        return SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, float2(xdistortion, ydistortion));
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