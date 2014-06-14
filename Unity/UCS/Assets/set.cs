using UnityEngine;
using System.Collections;


public class set : MonoBehaviour {
	public Camera Cam_A;
	public Camera Cam_B;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.C) && Cam_A.enabled){ //「D」キーを押した時に、カメラAが生きていたら
			Cam_A.enabled = false; //停止
			Cam_B.enabled = true; //生かす
		}
		
		else if (Input.GetKeyDown(KeyCode.C) && Cam_B.enabled){ //「D」キーを押した時に、カメラBが生きていたら
			Cam_A.enabled = true; //停止
			Cam_B.enabled = false; //停止
		}
		



	}
}
