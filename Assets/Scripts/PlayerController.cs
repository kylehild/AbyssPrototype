using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	static float 		highScore = 0f;
	static float 		score = 0f;
	public float		additions = 0f;
	public float 		multiplier = 1f;
	public bool			started = false;
	public bool			facingRight = true;

	public float		itemFrequency = 500f;
	public float		frequency = 50f;
	public float		frequency2 = 8f;
	public float		frequency3 = 5f;
	public float		meteorFrequency = 250f;
	public float		spikeFrequency = 325f;
	public float		itemFrames = -1f;
	public float		numFrames = -1f;
	public float		numFrames2 = 0f;
	public float		numFrames3 = 0f;
	public float		meteorFrames = -1f;
	public float		spikeFrames = -1f;

	public string		itemGotten = null;
	public float		itemTime = 0f;

	public GameObject[]	items;
	public GameObject	bomb;
	public GameObject	spikes;
	public GameObject	meteor;

	// Update is called once per frame
	void Update () {

		//Change bomb frequencies
		if(score < 15f) frequency = 50f;
		else if(score < 50f) frequency = 40f;
		else if(score < 150f) frequency = 35f;
		else if(score < 300f) frequency = 30f;
		else if(score < 750f) frequency = 25f;
		else frequency = 20f;

		if(score < 50f) frequency2 = 8f;
		else if(score < 200f) frequency2 = 6f;
		else if(score < 400f) frequency2 = 4f;
		else frequency2 = 2f;

		if(score < 200) frequency3 = 5f;
		else if(score < 550) frequency3 = 3f;
		else frequency3 = 1f;

		//spawn bombs
		if(numFrames < frequency && numFrames >= 0f) numFrames++;
		else if(numFrames >= frequency){
			numFrames = 0f;
			Instantiate(bomb);

			//sometimes 2 bombs
			if(score > 30f){
				numFrames2++;
				if(numFrames2 == frequency2){
					numFrames2 = 0f;
					Instantiate(bomb);
				}
			}
			//sometimes 3 bombs
			if(score > 100f){
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

		//spawn meteors
		if(meteorFrames < meteorFrequency && meteorFrames >= 0f) meteorFrames++;
		else if(meteorFrames >= meteorFrequency){
			meteorFrames = 0f;
			Instantiate(meteor);
		}

		//spawn spikes
		if(spikeFrames < spikeFrequency && spikeFrames >= 0f) spikeFrames++;
		else if(spikeFrames >= spikeFrequency){
			spikeFrames = 0f;
			Instantiate(spikes);
		}

		//do item stuff
		if(itemGotten != null){
			if(itemTime == 300f){
				additions += 50;
				if(itemGotten == "Random(Clone)")
					itemGotten = items[Random.Range (0, items.Length)].name + "(Clone)";

				if(itemGotten == "Clock(Clone)")
					rigidbody2D.gravityScale = 0.5f;
				else if(itemGotten == "Star(Clone)")
					GetComponent<BoxCollider2D>().enabled = false;
				else if(itemGotten == "Shrink(Clone)")
					transform.localScale = new Vector3(0.5f, 0.5f, 1f);
				else if(itemGotten == "Grow(Clone)")
					transform.localScale = new Vector3(2f, 2f, 1f);
				else if(itemGotten == "Reverse(Clone)")
					multiplier = -1f;
			}
			else if(itemTime == 0f){
				itemGotten = null;
				GetComponent<BoxCollider2D>().enabled = true;
				rigidbody2D.gravityScale = 1f;
				transform.localScale = new Vector3(1f, 1f, 1f);
				multiplier = 1f;
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
		rigidbody2D.velocity = new Vector2 (xAxisValue*20*multiplier, rigidbody2D.velocity.y);

		if (xAxisValue > 0 && !facingRight){
			Flip ();
		}
		else if(xAxisValue < 0 && facingRight){
			Flip ();
		}
	}
	
	public void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
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
