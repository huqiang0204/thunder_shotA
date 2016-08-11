Shader "Phone/light1"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
	_v("vector",vector) = (1,1,1,1)
	}
		SubShader
	{
		Cull Off ZWrite Off ZTest Always
		Blend SrcAlpha OneMinusSrcAlpha
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" }

		Pass
	{
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
		// make fog work
#pragma multi_compile_fog

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

	sampler2D _MainTex;

	float4 _v;
	v2f vert(appdata v)
	{
		v2f o;
		o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
		o.uv = v.uv;
		return o;
	}

	fixed4 frag(v2f i) : SV_Target
	{
		// sample the texture
float2 f;
	f.x = i.uv.x*_v.x;
	f.y = i.uv.y*_v.y;
		fixed4 col = tex2D(_MainTex, f);
	if (i.uv.x > 0.5)
	{
		float t = _Time.y % 0.3;
		t *= 3.33;
		t -= i.uv.y;
		if (t < 0.1)
		{
			if (t > 0)
			{
				col.x += 1;
				col.y += 1;
				col.z += 1;
			}
		}
	}
	return col;
	}
		ENDCG
	}
	}
}
