// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Fogs" 
{
	Properties
	{
		_MainTex("Texture", 2D) = "black" {}
	}
	SubShader
	{
		Tags{ "RenderType" = "Opaque" }

		Pass
		{
		
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#pragma multi_compile_fog
		#include "UnityCG.cginc"

		sampler2D _CameraDepthTexture;
		sampler2D _MainTex;
		float4 _MainTex_ST;
	struct v2f 
	{
		float2 uv: TEXCOORD0;
		float4 pos : SV_POSITION;
		float4 scrPos:TEXCOORD1;
	};

	//Vertex Shader
	v2f vert(appdata_base v) 
	{
		v2f o;
		o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
		o.pos = UnityObjectToClipPos(v.vertex);
		o.scrPos = ComputeScreenPos(o.pos);
		return o;
	}

	//Fragment Shader
	half4 frag(v2f i) : COLOR
	{
		half4 color = tex2D(_MainTex, i.uv);
		float depthValue = Linear01Depth(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.scrPos)).r);
		half4 depth;

		depth.r = depthValue + color.r;
		depth.g = depthValue + color.g;
		depth.b = depthValue + color.b;
		
		depth.a = 1;
		return depth;
	}
		ENDCG
	}
	}
		FallBack "Diffuse"
}