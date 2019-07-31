// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Phone/Disappear"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	    _Alpha("alpha",Range(0,1))= 0
			_v("vector",vector) = (1,1,1,1)
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always
		Blend SrcAlpha OneMinusSrcAlpha
			Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" }
			LOD 1000
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
				o.uv.x *= _v.x;
				o.uv.y *= _v.y;
				return o;
			}
			
			sampler2D _MainTex;
			float _Alpha;
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 c = tex2D(_MainTex, i.uv);
				// just invert the colors
				c.a -= _Alpha;
				return c;
			}
			ENDCG
		}
	}
}
