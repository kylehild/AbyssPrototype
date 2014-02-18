using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float 		score = 0;
	public float		additions = 0;

	public float		itemFrequency = 750f;
	public float		frequency = 50f;
	public float		frequency2 = 10f;
	public float		frequency3 = 8f;
	public float		itemFrames = -1f;
	public float		numFrames = -1f;
	public float		numFrames2 = 0f;
	public float		numFrames3 = 0f;

	public string		itemGotten = null;
	public float		itemTime = 0f;
	public GameObject[]	items;
	public GameObject	bomb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//Change bomb frequencies
		if(score < 25f) frequency = 50f;
		else if(score < 100f) frequency = 40f;
		else if(score < 200f) frequency = 30f;

		if(score < 75f) frequency2 = 10f;
		if(score < 150f) frequency2 = 7f;

		//spawn bombs
		if(numFrames < frequency && numFrames >= 0f) numFrames++;
		else if(numFrames >= frequency){
			numFrames = 0f;
			Instantiate(bomb);

			//sometimes 2 bombs
			if(score > 50f){
				numFrames2++;
				if(numFrames2 == frequency2){
					numFrames2 = 0f;
					Instantiate(bomb);
				}
			}
			//sometime 3 bombs
			if(score > 125f){
				numFrames3++;
				if(numFrames3 == frequency3){
					numFrames3 = 0f;
					Instantiate(bomb);
				}
			}
		}

		//spawn items
		if(itemFrames < itemFrequency && itemFrames >= 0f) itemFrames++;
		else if(itemFrames >= itemFrequency){
			itemFrames = 0f;
			Instantiate(items[Random.Range (0, items.Length-1)]);
		}

		//do item stuff
		if(itemGotten != null){
			if(itemTime == 300f){
				if(itemGotten == "Clock(Clone)")
					rigidbody2D.gravityScale = 0.5f;
			}
			else if(itemTime == 0f){
				itemGotten = null;
				rigidbody2D.gravityScale = 1f;
			}

			itemTime--;
		}

		//set score equal to how far down youve gone
		score = (int) transform.position.y / (-10) + additions;

		//move left or right
		float xAxisValue = Input.GetAxis("Horizontal");
		rigidbody2D.velocity = new Vector2 (xAxisValue*20, rigidbody2D.velocity.y);
	}
}
