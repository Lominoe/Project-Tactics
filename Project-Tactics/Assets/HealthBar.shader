Shader "Unlit/Healthbar"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _HealthAmt ("Health", range(0, 1)) = 0
        _StartColor ("Start Color", Color) = (0, 1, 0, 1)
        _EndColor ("End Color", Color) = (1, 0,0,1)
        _UVOffset ("Uv Offset", range(0, 1)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            float _HealthAmt;
            float _UVOffset;
            float4 _StartColor;
            float4 _EndColor;

            #include "UnityCG.cginc"

            struct MeshData
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Interpolator
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            

            Interpolator vert (MeshData v)
            {
                Interpolator o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                //o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (Interpolator i) : SV_Target
            {
                float4 colGradient = lerp(_EndColor, _StartColor, _HealthAmt);

                //return colGradient;
                
                float4 t = lerp((1,1,1,0), colGradient, i.uv.x + _UVOffset);
                t *= (_HealthAmt);
                return float4(t);
            }
            ENDCG
        }
    }
}