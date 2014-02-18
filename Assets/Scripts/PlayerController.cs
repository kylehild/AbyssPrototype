using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float 		score = 0;
	public float		additions = 0;
	public float		frequency = 50f;
	public float		frequency2 = 10f;
	public float		frequency3 = 8f;
	public float		numFrames = -1f;
	public float		numFrames2 = 0f;
	public float		numFrames3 = 0f;
	public GameObject	bomb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(score < 25f) frequency = 50f;
		else if(score < 100f) frequency = 40f;
		else if(score < 200f) frequency = 30f;

		if(score < 75f) frequency2 = 10f;
		if(score < 150f) frequency2 = 7f;

		if(numFrames < frequency && numFrames >= 0f) numFrames++;
		else if(numFrames == frequency){
			numFrames = 0f;
			Instantiate(bomb);
			if(score > 50f){
				numFrames2++;
				if(numFrames2 == frequency2){
					numFrames2 = 0f;
					Instantiate(bomb);
				}
			}

			if(score > 125f){
				numFrames3++;
				if(numFrames3 == frequency3){
					numFrames3 = 0f;
					Instantiate(bomb);
				}
			}
		}

		score = (int) transform.position.y / (-10) + additions;

		float xAxisValue = Input.GetAxis("Horizontal");
		rigidbody2D.velocity = new Vector2 (xAxisValue*20, rigidbody2D.velocity.y);
	}
}
