using UnityEngine;
using System.Collections;

public class DampenX : MonoBehaviour {

	public float dampenFactor = 40f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){

		//if the ball is moving horizontally and downward
		if((GetComponent<Rigidbody2D>().velocity.x > 0.0f || GetComponent<Rigidbody2D>().velocity.x < 0.0f) && GetComponent<Rigidbody2D>().velocity.y < 0.0f){

			//reduce it's velocity in the x direction
			Vector2 newVel = new Vector2(GetComponent<Rigidbody2D>().velocity.x - GetComponent<Rigidbody2D>().velocity.x/dampenFactor,
			                             GetComponent<Rigidbody2D>().velocity.y);

			//apply the new reduced velocity
			GetComponent<Rigidbody2D>().velocity = newVel;
		}
	}
}
