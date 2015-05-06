using UnityEngine;
using System.Collections;

public class Speeds : MonoBehaviour {

	public static float speed_slow = 20.0f;
	public static float speed_med = 50.0f;
	public static float speed_fast = 70.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static float getSpeedSlow(){
		return speed_slow;
	}

	public static float getSpeedMed(){
		return speed_med;
	}

	public static float getSpeedFast(){
		return speed_fast;
	}


}
