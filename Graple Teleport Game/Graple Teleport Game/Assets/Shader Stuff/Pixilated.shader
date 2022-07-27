Shader "Hidden/Pixilated"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _pixelSize("PixelSize", float) = 1
        _noise("Noise", float) = 0
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

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
                float4 vertex : SV_POSITION;
                float4 color : TEXCOORD1;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.color = v.color;
                return o;
            }

            float random(float2 uv)
            {
                return frac(sin(dot(uv, float2(12.9898, 78.233))) * 43758.5453123);
            }

            sampler2D _MainTex; 
            float _pixelSize;
            float _noise;

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, floor(i.uv * _pixelSize) / _pixelSize);
                // just invert the colors
                //col.rgb = 1 - col.rgb;
                col = lerp(col, random(i.uv) - .5, _noise);
                //col = lerp(col, i.color, frac(i.uv.x * _pixelSize) + frac(i.uv.x * _pixelSize));
                return col; //* i.color;
            }
            ENDCG
        }
    }
}
