using UnityEngine;
using System.Collections;

public class MenuBarScript : MonoBehaviour {
	
	public GUISkin		fontSkin;
	public GameObject	player;
	
	private int		desiredWidth = 360;
	private int		desiredHeight = 315;
	private float	rW, rH;
	
	void OnGUI () {
		
		rW = (float) Screen.width / (float) desiredWidth;
		rH = (float) Screen.height / (float) desiredHeight;
		
		GUI.skin = fontSkin;
		GUI.Label (new Rect (rW*40, rH*0, 200, 100), "Score");
		GUI.Label (new Rect (rW*40, rH*10, 200, 100), player.GetComponent<PlayerController>().getScore().ToString("00000"));
	
		GUI.Label (new Rect (rW*300, rH*0, 200, 100), "High Score");
		GUI.Label (new Rect (rW*300, rH*10, 200, 100), player.GetComponent<PlayerController>().getHighScore().ToString("00000"));
	}
}

