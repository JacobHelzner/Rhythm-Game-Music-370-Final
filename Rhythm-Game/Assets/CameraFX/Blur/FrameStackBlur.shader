Shader "Custom/FrameStackBlur"
{
    Properties
    {
        _MainTex("Current Frame", 2D) = "white" {}
        _AccumTex("Accumulated Texture", 2D) = "black" {} // Stores previous frames
        _Opacity("Blend Opacity", Range(0, 1)) = 0.9
    }
        SubShader
        {
            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                sampler2D _MainTex; // Current frame texture
                sampler2D _AccumTex; // Previous accumulated frames
                float _Opacity; // Blending strength

                struct v2f
                {
                    float4 pos : SV_POSITION;
                    float2 uv : TEXCOORD0;
                };

                v2f vert(appdata_full v)
                {
                    v2f o;
                    o.pos = UnityObjectToClipPos(v.vertex);
                    o.uv = v.texcoord;
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    fixed4 currentFrame = tex2D(_MainTex, i.uv);
                    fixed4 previousFrame = tex2D(_AccumTex, i.uv);

                    // Improved blending formula: Gradually mix previous frames with the current one
                    fixed4 accumulatedBlur = previousFrame * (1.0 - _Opacity) + currentFrame * _Opacity;

                    return accumulatedBlur;
                }
                ENDCG
            }
        }
}
