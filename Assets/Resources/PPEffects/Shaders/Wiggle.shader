Shader "Hidden/Custom/Wiggle"
{
    HLSLINCLUDE

    #include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

    TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
	float _Timer, _Speed;
	float _AmplitudeX, _AmplitudeY;
	float _DistortionX, _DistortionY;

    float4 Frag(VaryingsDefault i) : SV_Target
    {
        float2 texcoords = i.texcoord;
		texcoords.x += sin(_Timer * _Speed + texcoords.x * _AmplitudeX) * _DistortionX * 0.01f;
		texcoords.y += cos(_Timer * _Speed + texcoords.y * _AmplitudeY) * _DistortionY * 0.01f;
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