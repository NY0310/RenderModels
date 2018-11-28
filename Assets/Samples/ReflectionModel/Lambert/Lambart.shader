Shader "Hidden/Lambart"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		// No culling or depth
		Cull Back  ZTest Always

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
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				//拡散反射
				float diffuse : COLOR0;
			};

			v2f vert (appdata v)
			{
				v2f o;
				//頂点をクリップ空間座標に変換
				o.vertex = UnityObjectToClipPos(v.vertex);
				//uv座標
				o.uv = v.uv;

				float3 normal = v.normal;
				//ライト方向ベクトル
				float3 lightDir = ObjSpaceLightDir(v.vertex);
				//法線-ライトのcosθ
				float NdotL = dot(normal, lightDir);
				//拡散反射量の決定
				o.diffuse = max(0, NdotL);
				return o;
			}
			
			sampler2D _MainTex;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 texCol = tex2D(_MainTex, i.uv);
				// just invert the colors
				//サンプリングしたカラー値に拡散反射量を乗算する
				return i.diffuse * texCol;
			}
			ENDCG
		}
	}
}
