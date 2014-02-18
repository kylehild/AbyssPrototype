using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
		GameObject.Find ("Player").GetComponent<PlayerController> ().numFrames = 0f;
		GameObject.Find ("Player").GetComponent<PlayerController> ().itemFrames = 0f;

		GameObject.Find ("Player").GetComponent<PlayerController> ().started = true;
	}
}
