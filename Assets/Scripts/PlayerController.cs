using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float 		score = 0;
	public float		additions = 0;
	public float		frequency = 5f;
	public float		numFrames = -1f;
	public GameObject	bomb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(score < 25f) frequency = 50f;
		else if(score < 50f) frequency = 40f;
		else if(score < 100f) frequency = 30f;

		if(numFrames < frequency && numFrames >= 0f) numFrames++;
		else if(numFrames == frequency){
			numFrames = 0f;
			Instantiate(bomb);
			if(score > 75f)
				Instantiate(bomb);
		}

		score = (int) transform.position.y / (-10) + additions;

		float xAxisValue = Input.GetAxis("Horizontal");
		rigidbody2D.velocity = new Vector2 (xAxisValue*20, rigidbody2D.velocity.y);
	}
}
