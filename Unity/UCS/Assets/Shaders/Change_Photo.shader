Shader "Custom/Change_Photo" {
// http://marupeke296.com/UNI_S_No2_ShaderLab.html
    Properties {
    	_Photo ("Photo", 2D) = "" {}
    }
    SubShader {
        Pass {
			
//        	uniform float _Alpha;
            // ベーステクスチャを適用します。
            SetTexture [_Photo] {
                combine texture
            }
        }
    }
}