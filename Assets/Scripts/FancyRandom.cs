using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FancyRandom : MonoBehaviour {

	//returns a value along a normal gaussian distribution with a 
	//mean of 0 and standard deviation of 1
	private static float NextGaussian(){
		float first = Random.value;
		float second = Random.value;
		return Mathf.Sqrt(-2.0f * Mathf.Log(first)) * 
					Mathf.Sin(2.0f * Mathf.PI * second);
	}

	//returns a value with a mean centered directly between min and max and a standard deviation
	//of 1/6 the distance between min and max to fit the Normal almost completely between min and max
	//Also sets values outside range to bound values
	public static float NextNormalInRange(float min, float max){
		if(min > max) max = min;

		float mean = (max - min) / 2;
		float stdev = (max - mean) / 3;

		float val = mean + stdev * NextGaussian();

		if(val < min) val = min;
		else if(val > max) val = max;
		
		return val;
	}

	//returns a value that follows a normal distribution with the mean and stdev set
	//If min and max are set, the function takes any value lower than min and sets it to min
	//while anything higher than max gets set to max
	public static float NextNormalCentered(float mean, float stdev, 
	             	float min = float.MinValue, float max = float.MaxValue){
		if(min > max) max = min;

		float val = mean + stdev * NextGaussian();

		if(min > float.MinValue && val < min)
			val = min;
		else if(max < float.MaxValue && val > max)
			val = max;

		return val;
	}

	//returns a value along a triangular curve with min and max set and the peak
	//of the distribution set at mode
	public static float NextTriangular(float min, float max, float mode){
		if(min > max) max = min;

		float val = Random.value;
		float bound = (mode - min) / (max - min);
		if (val <= bound)
			return min + Mathf.Sqrt(val * (max - min) * (mode - min));
		else
			return max - Mathf.Sqrt((1 - val) * (max - min) * (max - mode));
	}

	//returns a float with equal probability along a uniform distribution with the smallest
	//possible value of min and largest of max inclusive
	public static float NextUniform(float min, float max){
		return Random.Range (min, max);
	}

	//returns an int with equal probability along a uniform distribution with the smallest
	//possible value of min and largest of max inclusive
	public static int NextUniform(int min, int max){
		return Random.Range (min, max+1);
	}

	//returns a random boolean value with equal chance true and false
	public static bool NextBool(){
		float rand = NextUniform (0, 1);
		return rand == 1;
	}

	//returns a random entry in an array with equal chance for any entry to be picked
	public static T NextInArray<T>(T[] array){
		return array [Random.Range (0, array.Length)];
	}
}
