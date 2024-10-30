Shader "Custom/SpecularShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _MetallicTex ("Metallic (R)", 2D) = "white" {}
        
    }
    SubShader
    {
        Tags
        {
            "Queue" = "Geometry"
        }
        
        
        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf StandardSpecular
        
        struct Input
        {
            float2 uv_MetallicTex;
        };

        half _Metallic;
        fixed4 _Color;
        sampler2D _MetallicTex;


        void surf (Input IN, inout SurfaceOutputStandardSpecular o)
        {
            o.Albedo = _Color.rgb;
            o.Smoothness = tex2D (_MetallicTex, IN.uv_MetallicTex).rgb;
            o.Specular = _Metallic;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
