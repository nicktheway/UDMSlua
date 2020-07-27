Shader "Hidden/Custom/DuoTone"
{
    HLSLINCLUDE

    #include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

    TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
	float4 _Color1, _Color2;
	float _MinLimit, _MaxLimit;

    float4 Frag(VaryingsDefault i) : SV_Target
    {
        float4 finalColor = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
		finalColor.rgb = (finalColor.r + finalColor.g + finalColor.b) / 3;

		finalColor.r = (finalColor.r < _MinLimit || finalColor.r > _MaxLimit) ? _Color1.r : _Color2.r;
		finalColor.g = (finalColor.g < _MinLimit || finalColor.g > _MaxLimit) ? _Color1.g : _Color2.g;
		finalColor.b = (finalColor.b < _MinLimit || finalColor.b > _MaxLimit) ? _Color1.b : _Color2.b;

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