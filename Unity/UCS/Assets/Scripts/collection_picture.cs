using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;


public class collection_picture : MonoBehaviour {
	private Texture2D tex;
	private List <Texture2D> tex2;
	private int k = 0;
	private GameObject obj;
	private GameObject [] obj2; 
	private int j = 0;

	// Use this for initialization
	void Start () {
		tex2 = new List<Texture2D>();
		//tex2[i] = Resources.Load("screenshot")  as Texture2D;
		for(j=0;;j++){
			var texture = Resources.Load("screenshot" + j)  as Texture2D;
			if(texture != null){
				tex2.Add(texture);
			}
			else{
				break;
			}
		}
		for(k=0;k<=9;k++){
			GameObject obj = GameObject.Find("/BigCube/Cube"+k);
			if(k>=j){
				obj.SetActiveRecursively(!obj.active);
				Debug.Log("okok");
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		for(k=0;k<=j;k++){
			GameObject obj = GameObject.Find("/BigCube/Cube"+k);
			obj.renderer.material.mainTexture = Resources.Load("screenshot"+k) as Texture2D;
		}
	}
}
