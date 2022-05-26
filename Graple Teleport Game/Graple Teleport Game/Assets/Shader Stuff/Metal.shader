Shader "Unlit/Metal"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Shean Color", color) = (1,1,1,1)
        _width("Width", float) = 1
        [ShowAsVector3] _location("Location", Vector) = (0,0,0,0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
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
                float4 color : COLOR;
                float4 vertex : SV_POSITION;
                float2 worldPos : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            float4 _Color;
            float _width;
            float4 _location;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.color = v.color;
                o.worldPos = mul(unity_ObjectToWorld, v.vertex);
                return o;
            }

            bool Dist(float2 loc, float width, float offset, float speedOffset, float repeat)
            {
                return abs(loc.x + loc.y + 1 *  (_location.x + _location.y)/speedOffset - offset) % repeat < width;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                //float4 col = tex2D(_MainTex, i.uv);
                float4 spriteCol = i.color;
                spriteCol = lerp(spriteCol, _Color, Dist(i.worldPos.xy, _width, 1, 1, 20));
                spriteCol = lerp(spriteCol, _Color, Dist(i.worldPos.xy, _width * 2, 3, 5, 40));
                spriteCol = lerp(spriteCol, _Color, Dist(i.worldPos.xy, _width * 3, 7, 7, 60));
                return spriteCol;
            }
            ENDCG
        }
    }
}
