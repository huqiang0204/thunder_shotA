// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "PC/BlendColor"
{
	Properties
	{
		_V1("blend color",Vector) = (1,1,1,1)
		_V2("blend color",Vector) = (1,1,1,1)
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		//Cull Off ZWrite Off ZTest Always
		Blend SrcAlpha OneMinusSrcAlpha
		//Tags{ "RenderType" = "Opaque" }
		Tags { "RenderType" = "Opaque" "Queue" = "Transparent" "IgnoreProjector" = "True" }
		
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
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _V1;
			float4 _V2;
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
			if (i.uv.y < 0.21f)
			{
				col.x *= _V1.x;
				col.y *= _V1.y;
				col.z *= _V1.z;
				col.w *= _V1.w;
			}
			else
			{
				col.x *= _V2.x;
				col.y *= _V2.y;
				col.z *= _V2.z;
				col.w *= _V2.w;
			}
				// apply fog
				//UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
