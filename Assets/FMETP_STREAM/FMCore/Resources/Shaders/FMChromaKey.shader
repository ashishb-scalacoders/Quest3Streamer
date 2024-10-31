Shader "Unlit/FMChromaKey"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}

		[MaterialToggle(_TOPBOTTOM_ON)] _Toggle_TOPBOTTOM_ON("Enable Top-Bottom", Float) = 0
		[MaterialToggle(_KEYCOLOR_ON)] _Toggle_KEYCOLOR("Enable Key Color", Float) = 1
        _keyingColor ("Key Colour", Color) = (0,1,0,1)
		_thresh ("Threshold", Range (0, 16)) = 0.8
        _slope ("Slope", Range (0, 1)) = 0.2

		_VerticalFlip("VerticalFlip", Range(0,1)) = 0
		_MaskTop("MaskTop", Range(0,1)) = 0
		_MaskBottom("MaskBottom", Range(0,1)) = 0
	}
	SubShader
	{
		Tags {"RenderType"="Transparent" "Queue"="Transparent"}
        Blend SrcAlpha OneMinusSrcAlpha
		
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile _KEYCOLOR_OFF _KEYCOLOR_ON
			#pragma multi_compile _TOPBOTTOM_OFF _TOPBOTTOM_ON
			
			//#include "UnityCG.cginc"

			sampler2D _MainTex;

			float3 _keyingColor;
            float _thresh;
            float _slope;

			float _VerticalFlip;
			float _MaskTop;
			float _MaskBottom;

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

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;

				#if UNITY_UV_STARTS_AT_TOP
                if(_ProjectionParams.x>0){ }
                #else
                if(_ProjectionParams.x<0){ o.uv.y = 1-o.uv.y; }
                #endif

				return o;
			}

			fixed4 frag (v2f i) : SV_Target
			{
				float2 uv = i.uv;
				if (_VerticalFlip > 0.5) uv.y = 1.0 - uv.y;

				float2 uvTex = uv;
				float2 uvAlpha = uv;

				float4 col = float4(1,1,1,1);
#if _TOPBOTTOM_ON
				uvTex.y /= 2.0;
				if (_VerticalFlip < 0.5) uvTex.y += 0.5;

				uvAlpha.y /= 2.0;
				if (_VerticalFlip > 0.5) uvAlpha.y += 0.5;

				col.a = tex2D(_MainTex, uvAlpha).r;
#endif
				col.rgb = tex2D(_MainTex, uvTex).rgb;


#if _KEYCOLOR_ON
				float d = abs(length(abs(_keyingColor.rgb -  col.rgb)));
				float edge0 = _thresh * (1.0 - _slope);

				col.a *= smoothstep(edge0, _thresh, d);
#endif

				if (uvTex.y > (1.0-_MaskBottom))
				{
					col.a = 0;
                }
				if (uvTex.y < _MaskTop)
				{
					col.a = 0;
                }
				return col;
			}
			ENDCG
		}
	}
}
