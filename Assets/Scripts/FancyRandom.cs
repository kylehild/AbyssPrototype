using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FancyRandom : MonoBehaviour {

	private float NextGaussian(){
		float first = Random.value;
		float second = Random.value;
		return Mathf.Sqrt(-2.0 * Mathf.Log(first)) * 
					Mathf.Sin(2.0 * Mathf.PI * second);
	}

	public float NextNormalInRange(){

	}

	public float NextNormalCentered(float mean, float stdev, 
	             	float min = float.MinValue, float max = float.MaxValue){
		float val = mean + stdev * NextGaussian();

		if(min > float.MinValue && val < min)
			val = min;
		else if(max > float.MaxValue && val > max)
			val = max;

		return val;
	}

	public float NextTriangular(){

	}

	public float NextUniform(){

	}

	public bool NextBool(){

	}

	public T NextInArray(T[] array){
		
	}
}
