Shader "Unlit/Smooth"
{
	Properties
	{
		_Color ("Color", COLOR) = (1,1,1,1)
	}
	SubShader
	{
		Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
		
		LOD 100
		
		Blend SrcAlpha OneMinusSrcAlpha //SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
		
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float3 normal : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			float4 _Color;
			float _Factor;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.normal = normalize(UnityObjectToViewPos(v.normal));
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				float4 col = _Color;
				
				col.a = saturate(i.normal.z) * (_SinTime.w * 0.5 + 0.5);

				return col;
			}
			ENDCG
		}
	}
}
