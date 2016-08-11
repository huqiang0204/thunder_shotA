Shader "PC/bk_change" {
	Properties{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
	_s("",2D) = "white"{}
	_t("time",range(0,1.8)) = 0
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
#pragma target 3.0

		sampler2D _MainTex;
	sampler2D _s;
	float _t;
	struct Input {
		float2 uv_MainTex;
	};

	void surf(Input i, inout SurfaceOutputStandard o) {
		// Albedo comes from a texture tinted by color
		float t = _t;
		fixed2 a = i.uv_MainTex;
		a.y += t;
		fixed4 col;
		if (a.y > 1.9)
		{
			a.y -= 1.8;
			col = tex2D(_MainTex, a);
		}
		else
			if (a.y > 1.8)
			{
				float y = a.y - 1.8;
				y *= 10;
				float x = 1 - y;
				a.y -= 0.9;
				col = tex2D(_s, a);
				a.y -= 0.9;
				fixed4 c = tex2D(_MainTex, a);
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
				col = tex2D(_s, a);
			}
			else if (a.y > 0.9)
			{
				col = tex2D(_MainTex, a);
				a.y -= 0.9;
				float y = a.y * 10;
				float x = 1 - y;
				fixed4 c = tex2D(_s, a);
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
				col = tex2D(_MainTex, a);
			}
			// Metallic and smoothness come from slider variables
			o.Emission = col.rgb;
			o.Alpha = col.a;
	}
	ENDCG
	}
		FallBack "Diffuse"
}
