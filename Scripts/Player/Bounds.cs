using UnityEngine;
using System.Collections;

public class Bounds : MonoBehaviour {

	//player bounds
	private float minX, maxX, minY, maxY;

	// Use this for initialization
	void Start () {
		float height = 2f * Camera.main.orthographicSize;
		float width = height * Camera.main.aspect;
		
		minX = -width / 2f;
		maxX = width / 2f;
		
		minY = -height / 2f;
		maxY = height / 2f;
	}
	
	// Update is called once per frame
	void Update () {
		//keep player in bounds
		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, minX, maxX),
		                                  Mathf.Clamp (transform.position.y, minY, maxY),
		                                  transform.position.z);
	}
}
