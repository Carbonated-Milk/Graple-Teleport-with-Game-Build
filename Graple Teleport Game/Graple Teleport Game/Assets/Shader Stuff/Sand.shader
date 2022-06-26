Shader "Unlit/Sand"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Color1("Color1", Color) = (1,1,1,1)
		_Color2("Color2", Color) = (0,0,0,1)
		mix("Value 1", float) = .5
		scale("Scale", float) = 5
		length("Length", float) = 4
		[ShowAsVector3] _location("Location", Vector) = (0,0,0,0)
		parallax("pLax", float) = 0
	}
		SubShader
	{
		Tags { "RenderType" = "Opaque" }

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			#define TAU 6.2831853

			float4 _Color1;
			float4 _Color2;
			float mix;
			float scale;
			float length;
			float4 _location;
			;
			float parallax;

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
			//float4 _MainTex_ST;

			v2f vert(appdata v)
			{
				v2f o;
				o.color = v.color;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				o.worldPos = mul(unity_ObjectToWorld, v.vertex);
				return o;
			}

			float InvLerp(float a, float b, float v)
			{
				return saturate((v - a) / (b - a));
			}

			fixed4 frag(v2f i) : SV_Target
			{
				float2 newuv = -parallax * _location.xy + i.worldPos.xy;
				float t = smoothstep(mix, -mix, cos((newuv.x * TAU + sin(newuv.y * TAU * length)) * scale));
				float4 col = lerp(_Color1, _Color2, t);
				return col * i.color;
			}
			ENDCG
		}
	}
}
