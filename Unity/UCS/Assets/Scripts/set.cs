using UnityEngine;
using System.Collections;
using System.IO;



public class set : MonoBehaviour {
	public Camera Cam_A;
	public Camera Cam_B;
	private int i = 0;
	// Use this for initialization
	void Start () {
		Cam_A.enabled = true; //停止
		Cam_B.enabled = false; //生かす
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.C) && Cam_A.enabled){ //「D」キーを押した時に、カメラAが生きていたら
			Cam_A.enabled = false; //停止
			Cam_B.enabled = true; //生かす
		}
		else if(Input.GetKeyDown("p") && Cam_B.enabled){
			Debug.Log("ok");
			if(i == 0){
			}
			Application.CaptureScreenshot(Application.dataPath + "/Resources/screenshot"+ i +".png");
			i = i + 1;
		}
		else if (Input.GetKeyDown(KeyCode.C) && Cam_B.enabled){ //「D」キーを押した時に、カメラBが生きていたら
			Cam_A.enabled = true; //停止
			Cam_B.enabled = false; //停止
		}

		if(Input.GetKey("t")){
			Application.LoadLevel("check_screenshots");
		}
	}

	void OnApplicationQuit(){
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
