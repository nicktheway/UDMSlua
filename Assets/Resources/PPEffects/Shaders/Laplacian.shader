Shader "Hidden/Custom/Laplacian"
{
    HLSLINCLUDE
	#pragma target 3.0
    #include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

    TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);

    float4 Frag(VaryingsDefault i) : SV_Target
    {
		float4 finalColor = -4 * SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
		float2 offsets[4] = {  
			float2(0, -1),  
			float2(-1, 0),  
			float2(1, 0),  
			float2(0, 1)  
		};

		UNITY_LOOP
		for (int j = 0; j < 4; j++)
		{
			finalColor += SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord + 0.0031f * offsets[j]); 
		}
			 	  
		return (0.5f + 1.0f * finalColor);
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