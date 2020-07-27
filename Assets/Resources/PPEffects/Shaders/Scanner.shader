Shader "Hidden/Custom/Scanner"
{
    HLSLINCLUDE

    #include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

    TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
	float _Timer;
	float _LinesIntensity, _LinesSpeed, _LinesAmount;

    float4 Frag(VaryingsDefault i) : SV_Target
    {
		float4 finalColor = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
		finalColor.br = cos(i.texcoord.y * _LinesAmount + _Timer * _LinesSpeed * 10) * _LinesIntensity;
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