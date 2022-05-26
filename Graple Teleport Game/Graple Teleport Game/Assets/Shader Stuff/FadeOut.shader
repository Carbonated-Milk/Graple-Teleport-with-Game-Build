Shader "Unlit/FadeOut"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Fade("Fade Value", Range(0.0, 1.0)) = 1
        _Scale("Scale Value", float) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }

        Pass
        {
            ZWrite Off
            Blend One OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 color : COLOR;
                float3 worldPos : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            float _Fade;
            float _Scale;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.color = v.color;
                o.worldPos = mul(unity_ObjectToWorld, v.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float3 normalPos = frac(i.worldPos * _Scale);
                float dist = length((normalPos.xy - .5) * 2);
                fixed4 col = tex2D(_MainTex, i.uv);
                return i.color * (dist < _Fade * sqrt(2)) * (1,1,1, _Fade);
            }
            ENDCG
        }
    }
}
