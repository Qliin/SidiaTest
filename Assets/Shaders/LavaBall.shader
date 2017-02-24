Shader "Custom/LavaBall" 
{
	Properties 
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_SecondTex ("SecondTex", 2D) = "white" {}
		_tintAmount ("Tint Amount", Range(0,1)) = 0.5
		[PerRendererData] _Color ("Color A", Color) = (1,1,1,1)
		_Speed ("Wave Speed", Range(0.1, 80)) = 5
		_Frequency ("Wave Frequency", Range(0, 5)) = 2
		_Amplitude ("Wave Amplitude", Range(-1, 1)) = 1
	}

	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Lambert vertex:vert

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _SecondTex;

		struct Input {
			float2 uv_MainTex;
			float2 uv_SecondTex;
			float3 vertexColor;
		};

		float4 _Color;
		float _tintAmount;
		float _Speed;
		float _Frequency;
		float _Amplitude;
		float _OffsetVal;

		void vert(inout appdata_full v, out Input o)
		{
			UNITY_INITIALIZE_OUTPUT(Input, o);
			float time = _Time * _Speed;
			float waveValueA = sin(time + v.vertex.x * _Frequency) * _Amplitude;

			v.vertex.xyz = float3(v.vertex.x, v.vertex.y + waveValueA, v.vertex.z);
			v.normal = normalize(float3(v.normal.x + waveValueA, v.normal.y, v.normal.z));
			o.vertexColor = float3(waveValueA, waveValueA, waveValueA);
		}

		void surf (Input IN, inout SurfaceOutput o) 
		{	
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			half4 s = tex2D (_SecondTex, IN.uv_SecondTex);

			//TODO: Remove if-else statement
			if(s.a != 0)
			{
				o.Albedo = s.rgb;
			}
			else
			{
				o.Albedo = c.rgb * (_Color * _tintAmount);
			}

			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
