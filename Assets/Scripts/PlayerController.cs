using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	static float 		highScore = 0;
	static float 		score = 0;
	public float		additions = 0;
	public bool			started = false;

	public float		itemFrequency = 1000f;
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

	// Update is called once per frame
	void Update () {

		//Change bomb frequencies
		if(score < 25f) frequency = 50f;
		else if(score < 100f) frequency = 40f;
		else if(score < 300f) frequency = 35f;
		else if(score < 500f) frequency = 30f;
		else if(score < 750f) frequency = 25f;

		if(score < 100f) frequency2 = 10f;
		else if(score < 350f) frequency2 = 7f;
		else if(score < 600f) frequency2 = 5f;

		if(score < 300) frequency3 = 8f;
		else if(score < 1000) frequency3 = 6f;

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
			//sometimes 3 bombs
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
			Instantiate(items[Random.Range (0, items.Length)]);
		}

		//do item stuff
		if(itemGotten != null){
			if(itemTime == 300f){
				additions += 50;
				if(itemGotten == "Clock(Clone)")
					rigidbody2D.gravityScale = 0.5f;
				else if(itemGotten == "Star(Clone)")
					GetComponent<BoxCollider2D>().enabled = false;
			}
			else if(itemTime == 0f){
				itemGotten = null;
				GetComponent<BoxCollider2D>().enabled = true;
				rigidbody2D.gravityScale = 1f;
			}

			itemTime--;
		}

		if(!GetComponent<BoxCollider2D>().enabled)
			GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;

		//set score equal to how far down youve gone
		if(started) score = (int) transform.position.y / (-10) + additions;

		//set high score
		if (score > highScore)
			highScore = score;

		//move left or right
		float xAxisValue = Input.GetAxis("Horizontal");
		rigidbody2D.velocity = new Vector2 (xAxisValue*20, rigidbody2D.velocity.y);
	}

	public float getScore(){
		return score;
	}

	public void setScore(float newScore){
		score = newScore;
	}
	
	public float getHighScore(){
		return highScore;
	}
	
	public void setHighScore(float newScore){
		highScore = newScore;
	}
}
