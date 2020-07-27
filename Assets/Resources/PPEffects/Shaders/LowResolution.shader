Shader "Hidden/Custom/LowResolution"
{
    HLSLINCLUDE

    #include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

    TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
	int _PixelsX, _PixelsY;

    float4 Frag(VaryingsDefault i) : SV_Target
    {
        float2 texcoords = i.texcoord;
		texcoords.x = round(texcoords.x * _PixelsX) / _PixelsX;
		texcoords.y = round(texcoords.y * _PixelsY) / _PixelsY;
        return SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, texcoords);
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