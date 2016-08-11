Shader "PC/Blood"
{
	Properties
	{
		_MainTex("Base (RGB) Trans (A)", 2D) = "white" {}
	    _r("ratio", Range(0, 1)) = 0.5
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
		sampler2D _MainTex;
	float _r;
	struct appdata
	{
		float4 vertex : POSITION;
		float2 uv : TEXCOORD0;
	};
	struct v2f
	{
		float4 pos : SV_POSITION;
		float2 uv : TEXCOORD0;
	};
	v2f vert(appdata v)
	{
		v2f o;
		o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
		o.uv = v.uv;
		return o;
	}
	half4 frag(v2f i) : COLOR
	{
		fixed4 c = tex2D(_MainTex, i.uv);
	if (i.uv.x >= _r)
		c.a = 0;
	    return c;
	}
		ENDCG
	}
	}
}

