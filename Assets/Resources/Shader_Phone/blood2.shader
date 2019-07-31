// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Phone/blood2"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	_s("",2D) = "white"{}
	_t("",2D) = "white"{}
	_r("ratio",range(0,1))=1
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
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				o.uv.x *= _v.x;
				o.uv.y *= _v.y;
				return o;
			}
			
			sampler2D _MainTex;
			sampler2D _s;
			sampler2D _t;
			float _r;
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col;
			if (_r < 0.5)
			{
				float t = _r  * 2;
				if (i.uv.x > t)
					col = tex2D(_MainTex, i.uv);
				else
				{
					col = tex2D(_s, i.uv);
					if (col.a == 0)
						col = tex2D(_MainTex, i.uv);
				}
			}
			else
			{
				float t = (_r - 0.5)*2;
				if (i.uv.x > t)
				{
					col = tex2D(_s, i.uv);
					if (col.a == 0)
						col = tex2D(_MainTex, i.uv);
				}
				else {
					col = tex2D(_t, i.uv);
					if (col.a == 0)
						col = tex2D(_MainTex, i.uv);
				}
			}
				return col;
			}
			ENDCG
		}
	}
}
