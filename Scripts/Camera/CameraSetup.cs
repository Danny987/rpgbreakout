using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CameraSetup : MonoBehaviour {
	
	float targetWidth = 1440.0f;
	float targetHeight = 2560.0f;
	public int pixelsPerUnit = 80; // ratio of pixels to units
	
	// Use this for initialization
	void Start () {
		adjustCameraSize ();
		
	}
	
	// Update is called once per frame
	void Update () {
		//adjustCameraSize ();
	}
	
	void adjustCameraSize(){
		float targetRatio = targetWidth / targetHeight;
		float actualRatio = (float)Screen.width/(float)Screen.height;
		
		if(actualRatio >= targetRatio)
		{
			Camera.main.orthographicSize = targetHeight / 2 / pixelsPerUnit;
		}
		else
		{
			float differenceInSize = targetRatio / actualRatio;
			Camera.main.orthographicSize = targetHeight / 2 / pixelsPerUnit * differenceInSize;
		}
	}
}
