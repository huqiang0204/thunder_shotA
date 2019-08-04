// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "PC/bc01" {
	Properties{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
	_c("_c",color)=(1,1,1,1)
	}
//		SubShader{
//		Tags{ "Queue" = "Transparent" }
//
//		CGPROGRAM
//		// Physically based Standard lighting model, and enable shadows on all light types
//#pragma surface surf Lambert alpha
//
//		// Use shader model 3.0 target, to get nicer looking lighting
//#pragma target 3.0
//
//		sampler2D _MainTex;
//	fixed4 _c;
//	struct Input {
//		float2 uv_MainTex;
//	};
//
//	void surf(Input IN, inout SurfaceOutput o) {
//		// Albedo comes from a texture tinted by color
//		fixed4 c = tex2D(_MainTex, IN.uv_MainTex);// *_Color;									  //o.Albedo = c.rgb;
//		o.Emission = _c;
//		// Metallic and smoothness come from slider variables
//		o.Alpha = c.rgb;
//	}
//	ENDCG
//	}
//		FallBack "Diffuse"
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
		o.vertex = UnityObjectToClipPos(v.vertex);
		o.uv = v.uv;
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