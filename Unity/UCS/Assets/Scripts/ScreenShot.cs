using UnityEngine;
using System.Collections;
using System.IO;

public class ScreenShot : MonoBehaviour {
	private int i = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("p")){
			if(i == 0){
			}
			Application.CaptureScreenshot(Application.dataPath + "/Resources/screenshot"+ i +".png");
			i = i + 1;
		}
		if(Input.GetKey("q")){
			Application.LoadLevel("check_screenshots");
		}
	}

	void OnApplicationQuit()
	{
		for(int j=0;;j++){
			var texture = Resources.Load("screenshot" + j)  as Texture2D;
			if(texture != null){
				File.Delete(Application.dataPath + "/Resources/screenshot"+ j +".png");
				Debug.Log("ok"+j);
			}
			else{
				break;
			}
		}
	}
}
