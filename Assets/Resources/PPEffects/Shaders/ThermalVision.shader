Shader "Hidden/Custom/ThermalVision"
{
    HLSLINCLUDE

    #include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

    TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);

    float4 Frag(VaryingsDefault i) : SV_Target
    {
		float3 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord).rgb;
		float3 colors[3] = {
			float3(0,0,1),
			float3(1,1,0),
			float3(1,0,0)
		};
		float litColor = (color.r + color.g + color.b) / 3;
		float threshold = (litColor < 0.5f) ? 0 : 1;
        float3 finalColor = lerp(colors[threshold], colors[threshold + 1], (litColor - threshold * 0.5f) / 0.5f);
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