Shader "Phone/def_surf" {
	Properties{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
	_v("vector",vector) = (1,1,1,1)
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
#pragma surface surf Lambert alpha

		// Use shader model 3.0 target, to get nicer looking lighting
#pragma target 3.0

		sampler2D _MainTex;

	struct Input {
		float2 uv_MainTex;
	};
	float4 _v;
	void surf(Input IN, inout SurfaceOutput o) {
		// Albedo comes from a texture tinted by color
		float2 p = IN.uv_MainTex;
		p.x *= _v.x;
		p.y *= _v.y;
		fixed4 c = tex2D(_MainTex, p);// *_Color;
									  //o.Albedo = c.rgb;
		o.Emission = c.rgb;
		// Metallic and smoothness come from slider variables
		o.Alpha = c.a;
	}
	ENDCG
	}
		FallBack "Diffuse"
}