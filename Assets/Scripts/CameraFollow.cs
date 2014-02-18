using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float		u;
	public Vector3		offset = new Vector3(0f, 0f, 0f);
	private GameObject	Player;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 poiV3 = Player.transform.position + offset;
		Vector3 currPos = transform.position;
		if(currPos.y > poiV3.y){
			Vector3 pos = (1 - u) * currPos + u * poiV3;
			pos.x = currPos.x;
			pos.z = currPos.z;
			transform.position = pos;
		}
	}
}
