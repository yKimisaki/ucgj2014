using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
   	public const int SPEED = 5;
	private float AngH = 0.0f;
	private float AngV = 0.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//controll left and right button a or d ...
    	float HaxisValue = Input.GetAxis("Horizontal");
	   	transform.Translate(Vector3.right * HaxisValue * SPEED * Time.deltaTime);
		//controll forward and back. button w or s ...
		float VaxisValue = Input.GetAxis("Vertical");
      	transform.Translate(Vector3.forward * VaxisValue * SPEED * Time.deltaTime);
		//controll up. button space.
		float UJumpValue = Input.GetAxis("Jump");
        transform.Translate(Vector3.up * UJumpValue * SPEED * Time.deltaTime);
		//controll down. button control key.
		float DJumpValue = Input.GetAxis("Fire1");
        transform.Translate(Vector3.down * DJumpValue * SPEED * Time.deltaTime);
		
		
		//rotate axisY. button q or e.
		if(Input.GetKey("q")){
			transform.Rotate(0,AngH,0);
			AngH = AngH - 0.1f;
		}
		else if(Input.GetKeyUp("q")){
				AngH = 0.0f;
			}
		if(Input.GetKey("e")){
			transform.Rotate(0,AngH,0);
			AngH = AngH + 0.1f;
		}
		else if(Input.GetKeyUp("e")){
			AngH = 0.0f;
		}


		if(Input.GetKey("r")){
			transform.Rotate(AngV,0,0);
			AngV = AngV - 0.1f;
		}
		else if(Input.GetKeyUp("r")){
			AngV = 0.0f;
		}
		if(Input.GetKey("f")){
			transform.Rotate(AngV,0,0);
			AngV = AngV + 0.1f;
		}
		else if(Input.GetKeyUp("f")){
			AngV = 0.0f;
		}

	}  
}
