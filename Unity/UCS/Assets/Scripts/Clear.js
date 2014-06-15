#pragma strict

static var clear: boolean;
clear = false;

function OnTriggerEnter( col : Collider){
	if(col.tag == "Player"){
		clear = true;
	}
	if(clear == true){
		Application.LoadLevel("check_screenshots");
	}
}