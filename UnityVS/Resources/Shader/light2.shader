Shader "PC/light2"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
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

	fixed4 frag(v2f i) : SV_Target
	{
		fixed4 col = tex2D(_MainTex, i.uv);
	if (i.uv.x > 0.1288)
	{
		float c = col - _Time.y % 1;
		if (c > -0.05)
		{
			if (c < 0.05)
			{
				col.x += 0.2;
				col.y += 0.2;
				col.z += 0.2;
			}
		}
	}
	else if (i.uv.y < 0.38655)
	{
		float c = col - _Time.y % 1;
		if (c > -0.05)
		{
			if (c < 0.05)
			{
				col.x += 0.2;
				col.y += 0.2;
				col.z += 0.2;
			}
		}
	}
	return col;
	}
		ENDCG
	}
	}
}