using UnityEngine;
using System;

public class timerimit : MonoBehaviour {
	public float startTime = 30.0f; // seconds
	public float timer;
	public bool paused = true;
		
	private void Start()
	{
		reset();
	}
		
	private void reset()
	{
		timer = startTime;
	}
		
	private void Update()
	{
//		if (paused) return;
			timer -= Time.deltaTime;
			if (timer <= 0.0f)
			{
				timer = 0.0f;
				paused = true;
					
					// 何かの処理
			}
		}
		
	private void OnGUI()
	{
		GUILayout.BeginVertical(GUILayout.Width(200));
		GUILayout.Box(String.Format("{0:00}:{1:00}:{2:00}:{3:00}", Math.Floor(timer / 3600f), Math.Floor(timer / 60f), Math.Floor(timer % 60f), timer % 1 * 100), GUILayout.Width(200));
		GUILayout.BeginHorizontal();		
//		if (GUILayout.Button("Start")) paused = false;
//		if (GUILayout.Button("Stop")) paused = true;
//		if (GUILayout.Button("Reset")) reset();
		GUILayout.EndHorizontal();
		GUILayout.EndVertical();
	}
}
