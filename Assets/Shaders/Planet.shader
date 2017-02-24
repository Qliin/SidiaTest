Shader "Custom/Planet" 
{
	Properties
	{

		_MainTex ("Main Texture", 2D) = "white" {}
		_SecondTex ("Seconday Texture", 2D) = "white" {}
		_Normal ("Normal", 2D) = "bump" {}	
		[PerRendererData] _Color ("Color", Color) = (1, 1, 1, 1)
	}
		
	SubShader 
	{
		Tags 
		{ 
			"RenderType"="Opaque" 
		}	
		
		CGPROGRAM

		#pragma surface surf Lambert

		sampler2D _MainTex;
		sampler2D _Normal;
		sampler2D _SecondTex;
		float4 _Color;

		struct Input 
		{			
			float2 uv_MainTex;
			float2 uv_SecondTex;
			float2 uv_Normal;
		};

		void surf (Input IN, inout SurfaceOutput o) 
		{					
			o.Albedo = (tex2D (_MainTex, IN.uv_MainTex)).rgb * _Color;
			o.Albedo *= (tex2D (_SecondTex, IN.uv_SecondTex)).rgb * 2;
			o.Normal = UnpackNormal(tex2D (_Normal, IN.uv_Normal));
		}

		ENDCG
	}
	FallBack "Diffuse"
}
