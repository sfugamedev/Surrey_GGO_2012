Shader "Custom/World Map Simple" {
    Properties {
      _MainTex ("Texture", 2D) = "surface" {}
    }
    SubShader {
      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
		  float3 worldPos;
      };
      sampler2D _MainTex;
      void surf (Input IN, inout SurfaceOutput o) {
		float3 worlduv = IN.worldPos;
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		//o.Albedo = tex2D (_MainTex, worlduv.xz/10);
		o.Albedo = c.rgb;
		o.Alpha = c.a;
      }
      ENDCG
    } 
  }