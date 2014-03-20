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

	public float NextNormalInRange(float min, float max){
		if(min > max) max = min;

		float mean = (max - min) / 2;
		float stdev = (max - mean) / 3;

		float val = mean + stdev * NextGaussian();

		if(val < min) val = min;
		else if(val > max) val = max;
		
		return val;
	}

	public float NextNormalCentered(float mean, float stdev, 
	             	float min = float.MinValue, float max = float.MaxValue){
		if(min > max) max = min;

		float val = mean + stdev * NextGaussian();

		if(min > float.MinValue && val < min)
			val = min;
		else if(max > float.MaxValue && val > max)
			val = max;

		return val;
	}

	public float NextTriangular(float min, float max, float mode){
		if(min > max) max = min;

		float val = Random.value;
		float bound = (mode - min) / (max - min);
		if (val <= bound)
			return min + Mathf.Sqrt(val * (max - min) * (mode - min));
		else
			return max - Mathf.Sqrt((1 - val) * (max - min) * (max - mode));
	}

	public float NextUniform(float min, float max){
		return Random.Range (min, max);
	}

	public int NextUniform(int min, int max){
		return Random.Range (min, max);
	}

	public bool NextBool(){
		float rand = Random.Range (0, 2);
		return rand == 1;
	}

	public T NextInArray<T>(T[] array){
		return array [Random.Range (0, array.Length)];
	}
}
