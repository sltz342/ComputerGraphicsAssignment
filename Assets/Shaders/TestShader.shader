Shader "Custom/TestShader"
{
    Properties
    {
        _myColor ("Sample color", Color) = (1, 1,1,1)
        _myEmission ("Sample emission", Color) = (1,1,1,1)
        _myNormal ("Sample normal", Color) = (1,1,1,1)
        
        _myRange ("Sample range", Range(0,5)) = 1
        _myFloat ("Sample float", Float) = 0.5
        _myVector ("Sample vector", Vector) = (0.5,1,1,1)
        _myTex ("Sample Texture", 2D) = "white" {}
        _myCube ("Sample Cube", Cube) = "" {}
    }
    SubShader
    {
        CGPROGRAM
        #pragma surface surf Lambert
        struct Input{
            float2 uv_myTex;
            float3 worldRefl;
        };
        fixed4 _myColor;
        fixed4 _myEmission;
        fixed4 _myNormal;

        half _myRange;
        sampler2D _myTex;
        samplerCUBE _myCube;
        float _myFloat;
        float4 _myVector;

        void surf (Input IN, inout SurfaceOutput o){
            // To Set the color to only display blue, we type the code
            //o.Albedo = fixed3( 0, 0, _myColor.b); // <- as that only lets the material show blue
            //Whereas if we wanna add blue on top of whatever we make, we do the lines below
            //o.Albedo = fixed3(_myColor.r,_myColor.g, 1);

            //Normal Commands Below
            //o.Albedo = _myColor.rgb;
            //o.Emission = _myEmission.rgb;
            //o.Normal = _myNormal;

            //Lect 3 - Problems with o.Emission at Line 46 causing Errors
            o.Albedo = (tex2D(_myTex, IN.uv_myTex) * _myRange).rgb;
            
            o.Emission = texCUBE (_myCube, IN.worldRefl).rgb;
            /* Please find the Error below
            *
            Shader error in 'Custom/MarioShader': Surface shader Input structure needs INTERNAL_DATA for this WorldNormalVector or WorldReflectionVector usage at line 131 (on d3d11)

            Compiling Subshader: 0, Pass: Meta, Fragment program with <no keywords>
            Platform defines: SHADER_API_DESKTOP UNITY_COLORSPACE_GAMMA UNITY_ENABLE_DETAIL_NORMALMAP UNITY_ENABLE_REFLECTION_BUFFERS
                UNITY_LIGHTMAP_FULL_HDR UNITY_LIGHT_PROBE_PROXY_VOLUME UNITY_PASS_META UNITY_PBS_USE_BRDF1 UNITY_SPECCUBE_BLENDING
                UNITY_SPECCUBE_BOX_PROJECTION UNITY_USE_DITHER_MASK_FOR_ALPHABLENDED_SHADOWS
            Disabled keywords: EDITOR_VISUALIZATION INSTANCING_ON SHADER_API_GLES30 UNITY_ASTC_NORMALMAP_ENCODING UNITY_FRAMEBUFFER_FETCH_AVAILABLE
                UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS UNITY_HARDWARE_TIER1 UNITY_HARDWARE_TIER2 UNITY_HARDWARE_TIER3
                UNITY_LIGHTMAP_DLDR_ENCODING UNITY_LIGHTMAP_RGBM_ENCODING UNITY_METAL_SHADOWS_USE_POINT_FILTERING UNITY_NO_DXT5nm
                UNITY_NO_FULL_STANDARD_SHADER UNITY_NO_SCREENSPACE_SHADOWS UNITY_PBS_USE_BRDF2 UNITY_PBS_USE_BRDF3
                UNITY_PRETRANSFORM_TO_DISPLAY_ORIENTATION UNITY_UNIFIED_SHADER_PRECISION_MODEL UNITY_VIRTUAL_TEXTURING
            *
            */

            
        }
        
        
        ENDCG
    }
    FallBack "Diffuse"
}
