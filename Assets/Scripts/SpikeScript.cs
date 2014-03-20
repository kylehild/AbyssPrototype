using UnityEngine;
using System.Collections;

public class SpikeScript : MonoBehaviour {

	public GameObject	player;
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		float loc;
		if(FancyRandom.NextBool())
			loc = 11.5f;
		else loc = -11.5f;

		transform.position = new Vector3 (loc, player.transform.position.y - 20f, 10f);
	}
	
	void Update(){
		if(transform.position.y-10 > player.transform.position.y)
			Destroy(gameObject);
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject.tag == "Player"){
			Application.LoadLevel ("Scene_0");
		}
	}
}
