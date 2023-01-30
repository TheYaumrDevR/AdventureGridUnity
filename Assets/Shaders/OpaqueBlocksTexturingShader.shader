Shader "Custom/OpaqueBlocksTexturingShader"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2DArray) = "white" {}
    }

    SubShader
    {
        Tags { "RenderType" = "Opaque" }

        CGPROGRAM

        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows vertex:vert

        UNITY_DECLARE_TEX2DARRAY(_MainTex);

        struct Input
        {
            float2 textureUvValues;
            float textureArrayIndex;
        };

        void vert(inout appdata_full inputData, out Input inputForSurfaceShader)
        {
            inputForSurfaceShader.textureUvValues = inputData.texcoord.xy;
            inputForSurfaceShader.textureArrayIndex = inputData.texcoord.z;
        }

        void surf (Input surfaceShaderInput, inout SurfaceOutputStandard surfaceShaderOutput)
        {
            // Albedo comes from a texture tinted by color
            fixed4 colour = UNITY_SAMPLE_TEX2DARRAY(_MainTex, float3(surfaceShaderInput.textureUvValues, surfaceShaderInput.textureArrayIndex));
            surfaceShaderOutput.Albedo = colour.rgb;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
