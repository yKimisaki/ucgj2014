#pragma strict

// deathCountは本来の名前に書き直して下さい
static var deathCount: int;

// ①文字のパラメータ
var style : GUIStyle ;

function Start () {
	deathCount = 0;
	
	style.fontSize=40;
	//style.normal.textColor.red;
}

function Update () {
	guiText.text = deathCount.ToString();
}

// ②条件を満たしたら「ＧＡＭＥ　ＯＶＥＲ」の文字を出す
function OnGUI () {
	if( deathCount >= 20 )
	{
	
		GUI.Label( Rect ( Screen.width / 2 -100, 250, 200, 80), "GAME OVER" , style );
		if( GUI.Button(Rect ( Screen.width / 2 -100, 200, 200, 30), "Go title" ))
		{
			Application.LoadLevel("title");
		}
	}
}