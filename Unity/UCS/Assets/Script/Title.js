//#pragma SystemCollections
#pragma strict

//var sound:AudioClip;

// ①GUIの描画
function OnGUI () {
	//audio.Play();
  
	// ②ボタンの作成
	if( GUI.Button(Rect (Screen.width / 2 -100, 200, 200, 30), "GAME START"))
	{
		// ③ボタンが押された後シーンを切り替え
		Application.LoadLevel( "main" );

	}
	
}