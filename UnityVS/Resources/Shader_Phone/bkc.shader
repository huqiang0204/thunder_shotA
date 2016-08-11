Shader "Phone/bk_change" {
	Properties{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
	_s("",2D) = "white"{}
	_t("time",range(0,1.8)) = 0
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
	v2f vert(appdata v)
	{
		v2f o;
		o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
		o.uv = v.uv;
		return o;
	}

	sampler2D _MainTex;
	sampler2D _s;
	float _t;
	float4 _v;

	fixed4 frag(v2f i) : SV_Target
	{
		float t = _t;
	fixed2 a = i.uv;
	a.y += t;
	fixed4 col;
	if (a.y > 1.9)
	{
		a.y -= 1.8;
		a.x *= _v.x;
		a.y *= _v.y;
		col = tex2D(_MainTex, a);
	}
	else
		if (a.y > 1.8)
		{
			float y = a.y - 1.8;
			y *= 10;
			float x = 1 - y;
			a.y -= 0.9;
			float2 ft;
			ft.x = a.x*_v.x;
			ft.y = a.y*_v.y;
			col = tex2D(_s, ft);
			a.y -= 0.9;
			ft.y = a.y*_v.y;
			fixed4 c = tex2D(_MainTex, ft);
			col.x *= x;
			c.x *= y;
			col.x += c.x;
			col.y *= x;
			c.y *= y;
			col.y += c.y;
			col.z *= x;
			c.z *= y;
			col.z += c.z;
		}
		else if (a.y > 1)
		{
			a.y -= 0.9;
			a.x *= _v.x;
			a.y *= _v.y;
			col = tex2D(_s, a);
		}
		else if (a.y > 0.9)
		{
			float2 tf;
			tf.x = a.x*_v.x;
			tf.y = a.y*_v.y;
			col = tex2D(_MainTex, tf);
			a.y -= 0.9;
			float y = a.y * 10;
			float x = 1 - y;
			tf.y = a.y*_v.y;
			fixed4 c = tex2D(_s, tf);
			col.x *= x;
			c.x *= y;
			col.x += c.x;
			col.y *= x;
			c.y *= y;
			col.y += c.y;
			col.z *= x;
			c.z *= y;
			col.z += c.z;
		}
		else {
			a.x *= _v.x;
			a.y *= _v.y;
			col = tex2D(_MainTex, a);
		}
		// Metallic and smoothness come from slider variables
	return col;
	}
		ENDCG
	}
	}
		FallBack "Diffuse"
}
