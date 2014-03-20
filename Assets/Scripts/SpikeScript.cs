using UnityEngine;
using System.Collections;

public class SpikeScript : MonoBehaviour {

	public GameObject	player;
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		float rand = Random.Range (0, 2);
		if(rand == 1)
			rand = 11.5f;
		else rand = -11.5f;

		transform.position = new Vector3 (rand, player.transform.position.y - 20f, 10f);
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
