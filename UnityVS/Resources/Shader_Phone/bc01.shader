Shader "Phone/bc01" {
	Properties{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
	_c("_c",color) = (1,1,1,1)
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
		o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
		o.uv = v.uv;
		o.uv.x*= _v.x;
		o.uv.y *= _v.y;
		return o;
	}

	sampler2D _MainTex;
	fixed4 _c;
	
	fixed4 frag(v2f i) : SV_Target
	{
		fixed4 col;
	
	col.w= tex2D(_MainTex, i.uv);
	col.w *= _c.w;
	col.xyz = _c.xyz;
	return col;
	}
		ENDCG
	}
	}
}