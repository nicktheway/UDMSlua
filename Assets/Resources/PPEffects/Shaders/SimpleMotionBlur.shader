Shader "Hidden/Custom/SimpleMotionBlur"
{
    HLSLINCLUDE

		#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

		TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
		float _AccumOrig;

		float4 Frag(VaryingsDefault i) : SV_Target
		{
			float4 finalColor = half4(SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord).rgb, _AccumOrig);

			return finalColor;
		}

		float4 DefaultFrag(VaryingsDefault i) : SV_Target
		{
			return SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
		}

    ENDHLSL

    SubShader
    {
        Cull Off ZWrite Off ZTest Always

        Pass
        {
			Blend SrcAlpha OneMinusSrcAlpha
			ColorMask RGB

            HLSLPROGRAM

                #pragma vertex VertDefault
                #pragma fragment Frag

            ENDHLSL
        }

		Pass
        {
			Blend One Zero
			ColorMask A

            HLSLPROGRAM

                #pragma vertex VertDefault
                #pragma fragment DefaultFrag

            ENDHLSL
        }
    }

	SubShader {
		ZTest Always Cull Off ZWrite Off
		Pass 
		{
			Blend SrcAlpha OneMinusSrcAlpha
			ColorMask RGB
			SetTexture [_MainTex] {
				ConstantColor (0,0,0,[_AccumOrig])
				Combine texture, constant
			}
		}
		Pass 
		{
			Blend One Zero
			ColorMask A
			SetTexture [_MainTex] {
				Combine texture
			}
		}
	}
}