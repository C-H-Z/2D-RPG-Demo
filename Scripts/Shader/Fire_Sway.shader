Shader "Custom/Fire_Realistic"
{
    Properties
    {
        _MainTex ("火焰纹理", 2D) = "white" {}
        _Color ("火焰颜色", Color) = (1,0.5,0,1)
        _Speed ("燃烧速度", Range(0, 10)) = 3
        _HeightStrength ("跳跃幅度", Range(0, 0.1)) = 0.05
        _WarpStrength ("扭曲强度", Range(0, 0.05)) = 0.025
        _NoiseStrength ("随机强度", Range(0, 0.05)) = 0.025
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "RenderPipeline"="UniversalPipeline"
            "PreviewType"="Plane"
        }

        Cull Off
        Lighting Off
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 worldPos : TEXCOORD1;
            };

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);

            CBUFFER_START(UnityPerMaterial)
                float4 _MainTex_ST;
                float4 _Color;
                float _Speed;
                float _HeightStrength;
                float _WarpStrength;
                float _NoiseStrength;
            CBUFFER_END

            
            float rand(float2 co)
            {
                return frac(sin(dot(co.xy, float2(12.9898, 78.233))) * 43758.5453);
            }

            Varyings vert(Attributes input)
            {
                Varyings output;
                
                
                float3 worldPos = TransformObjectToWorld(input.positionOS.xyz);
                
                
                float height = input.uv.y;
                float strength = height * height;
                
                
                float time = _Time.y * _Speed;
                
                
                float jump1 = sin(worldPos.x * 2 + time * 2) * 0.5;
                float jump2 = cos(worldPos.z * 3 + time * 3) * 0.3;
                float jump3 = sin(worldPos.y * 5 + time * 5) * 0.2;
                float verticalJump = (jump1 + jump2 + jump3) * strength * _HeightStrength;
                
               
                float warp1 = sin(worldPos.y * 4 + time * 4) * _WarpStrength;
                float warp2 = cos(worldPos.x * 3 + time * 3) * _WarpStrength;
                
                
                float noise = rand(float2(worldPos.x + time, worldPos.y + time)) * 2 - 1;
                noise *= strength * _NoiseStrength;
                
                
                worldPos.y += verticalJump;
                worldPos.x += warp1 + warp2;
                worldPos.x += noise;
                
               
                output.positionCS = TransformWorldToHClip(worldPos);
                output.uv = TRANSFORM_TEX(input.uv, _MainTex);
                output.worldPos = worldPos;
                
                return output;
            }

            half4 frag(Varyings input) : SV_Target
            {
                half4 col = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, input.uv);
                
               
                float height = input.uv.y;
                float brightness = 0.8 + height * 0.4;
                
                
                float flicker = sin(input.worldPos.x * 10 + _Time.y * 10) * 0.2 + 0.8;
                brightness *= flicker;
                
                col.rgb *= _Color.rgb * brightness;
                
                return col;
            }
            ENDHLSL
        }
    }
}