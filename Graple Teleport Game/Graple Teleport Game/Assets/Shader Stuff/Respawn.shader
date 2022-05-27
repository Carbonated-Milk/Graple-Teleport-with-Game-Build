Shader "Unlit/Respawn"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_ColorA("Color A", Color) = (1,1,1,1)
		_ColorB("Color B", Color) = (1,1,1,1)
		timeScale("TimeScale", float) = 1
	}
		SubShader
	{
		Tags { "RenderType" = "Opaque"
				"Queue" = "Geometry" }


		Pass
		{
			ZWrite Off
			Blend One OneMinusSrcAlpha

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			float4 _ColorA;
			float4 _ColorB;
			float timeScale;

		struct appdata
		{
			float4 vertex : POSITION;
			float2 uv : TEXCOORD0;
		};

		struct v2f
		{
			float2 uv : TEXCOORD0;
			UNITY_FOG_COORDS(1)
			float4 vertex : SV_POSITION;
		};

		sampler2D _MainTex;
		float4 _MainTex_ST;

		v2f vert(appdata v)
		{
			v2f o;
			o.vertex = UnityObjectToClipPos(v.vertex);
			o.uv = TRANSFORM_TEX(v.uv, _MainTex);
			return o;
		}

		float Pointy(float2 place)
		{
			float angle = atan(place.x / place.y);
			return angle;
		}

		fixed4 frag(v2f i) : SV_Target
		{
			float2 place = (i.uv.xy - .5) * 2;
			float mult = ceil(cos(30 * length(place) + 6 * Pointy(place) + timeScale * _Time) / 3);
			mult *= saturate(1 - length(place));
			fixed4 col = lerp(_ColorB, _ColorA, mult);

			float mult2 = ceil(cos(30 * length(place) - timeScale * _Time) / 3);
			mult2 *= saturate(1 - length(place));
			col *= saturate(1 - length(place) * length(place));

			col -= lerp(_ColorB, _ColorA, mult2);
			col *= saturate(1 - length(place));
			return col;
		}
		ENDCG
	}
	}
}
