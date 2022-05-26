Shader "Unlit/Sawblade"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "green" {}
        _Color("Color", Color) = (1,1,1,1)
        [ShowAsVector4] _config("Blades, Speed, Size, Width", Vector) = (10, 1.5, .8, .08)
        [ShowAsVector4] _angles("Start, End, Wobble, Wave", Vector) = (1.3, 1.5, 125, 1)
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

            #define TAU 6.2831853


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
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            float4 _Color;
            float4 _angles;
            float4 _config;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.color = v.color;
                return o;
            }

            float InvLerp(float a, float b, float v)
            {
                return saturate((v - a) / (b - a));
            }

            float Angle(float2 place)
            {
                float angle = atan(place.x / place.y);
                return angle;
            }

            float Angle2(float2 place)
            {
                float angle = atan2(place.x , place.y);
                return angle;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 place = (i.uv.xy - .5) * 2;
                float4 col = tex2D(_MainTex, i.uv);
                float angle = Angle(place);
                float t = InvLerp(_angles.x + sin(_angles.z * TAU * _Time.x)/50, _angles.y + sin(_angles.z * TAU * _Time.x) / 50, .3 + abs(angle) - _angles.w * sin(length(200 * place) + _Time.x * 800) / 100);
                col = lerp(i.color, _Color, t );

                float angle2 = Angle2(place);
                col *= length(place) - frac(_config.x * angle2/TAU - _config.y * _Time.x) * _config.w < _config.z;
                //return angle;
                return col;
            }
            ENDCG
        }
    }
}
