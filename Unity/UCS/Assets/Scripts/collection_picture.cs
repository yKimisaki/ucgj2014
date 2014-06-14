using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;


public class collection_picture : MonoBehaviour {
	private Texture2D tex;
	private List <Texture2D> tex2;
	private int k = 0;

	// Use this for initialization
	void Start () {
		tex2 = new List<Texture2D>();
		//tex2[i] = Resources.Load("screenshot")  as Texture2D;
		for(int j=0;;j++){
			var texture = Resources.Load("screenshot" + j)  as Texture2D;
			if(texture != null){
				tex2.Add(texture);
			}
			else{
				break;
			}
		}

		for(k = 0; k!= 0; k++){
			tex = tex2[0];
			Shader.SetGlobalTexture("_Photo", tex);
			k = (k + 1)%tex2.Count;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
