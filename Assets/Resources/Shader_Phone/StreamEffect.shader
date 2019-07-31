// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Phone/StreamEffect"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	_Speed("Seed", Range(0,1000)) = 0.5
		_Miny("Miny", Range(0,1)) = 0
		_Maxy("Maxy", Range(0,1)) = 1
		_v("vector",vector) = (1,1,1,1)
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always
		Blend SrcAlpha OneMinusSrcAlpha
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" }
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
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			float4 _v;
			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			float _Speed;
			float _Miny;
			float _Maxy;
			fixed4 frag (v2f i) : SV_Target
			{
		    fixed y = _Time*_Speed;
			fixed2 f = i.uv;
			//y = _Pos;
			f.y -= y;
			if (f.y < _Miny) {
				f.y = _Miny + fmod(abs(f.y), _Maxy - _Miny);
			}
			f.x *= _v.x;
			f.y *= _v.y;
			return tex2D(_MainTex, f);// *_Color;
			}
			ENDCG
		}
	}
}
