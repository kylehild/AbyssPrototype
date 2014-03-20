using UnityEngine;
using System.Collections;

public class MeteorScript : MonoBehaviour {

	public GameObject	player;
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		transform.position = new Vector3 (FancyRandom.NextNormalInRange(-14, 14), 
		                                  		player.transform.position.y + 15f, 10f);
	}
	
	void Update(){
		if(transform.position.y+20 < player.transform.position.y)
			Destroy(gameObject);
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject.tag == "Player"){
			Application.LoadLevel ("Scene_0");
		}
	}
}
