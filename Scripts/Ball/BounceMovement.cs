using UnityEngine;
using System.Collections;

public class BounceMovement : MonoBehaviour {

	//float minSpeed = 10.0f;
	float maxSpeed = 40.0f;
	//float bounceSpeed = 30.0f;


	Vector3 targetPos;

	int defaultLayer = 0;

	float hitTimer = 0f;

	// Use this for initialization
	void Start () {
		defaultLayer = gameObject.layer;
		targetPos = new Vector3 (0, -Camera.main.orthographicSize, -1);
	}
	
	// Update is called once per frame
	void Update () {

		//if the speed of the ball is greater than the max speed
		if(GetComponent<Rigidbody2D>().velocity.magnitude > maxSpeed){

			//set the balls speed to the max speed
			GetComponent<Rigidbody2D>().velocity = maxSpeed * (GetComponent<Rigidbody2D>().velocity.normalized);
        }

		if(gameObject.layer != defaultLayer){
			hitTimer += Time.deltaTime;
		}
		if(hitTimer >= 0.2f){
			gameObject.layer = defaultLayer;
			hitTimer = 0;
		}



	}

	/*
	 * Applies a random directional force on the ball depending on which direction
	 * it's moving.
	 */
	void LaunchBall(){

		//get ball velocity vector
		Vector3 ballVel = GetComponent<Rigidbody2D>().velocity;

		//random variable that determines direction of the force (left or right, up or down)
		float rand = Random.Range (0, 100.0f);

		//random force to apply to the ball
		float force = Random.Range (0, 20.0f);

		//if ball is moving horizontally
		if(Mathf.Abs(ballVel.x) > Mathf.Abs(ballVel.y)){

			//aply random vertical force
			if(rand > 50.0f){
				ballVel.y += force;
			}
			else{
				ballVel.y -= force;
			}

		}

		//if ball is moving vertically
		else{
			//apply random horizontal force
			if(rand > 50.0f){
				ballVel.x += force;
			}
			else{
				ballVel.x -= force;
			}

		}

		//apply the new velocity as a force to the ball
		GetComponent<Rigidbody2D>().AddForce(ballVel * 0.05f);
	}

	void OnCollisionEnter2D(Collision2D col){

		//on collision with a block
		if(col.gameObject.layer == LayerMask.NameToLayer("Block")){
			//launch the ball
			LaunchBall ();
		}
	}

	public void EnemyHit(){
		//change ball to Ball_Enemy_Hit layer
		gameObject.layer = 18;
		gameObject.GetComponent<Rigidbody2D>().AddForce((targetPos - transform.position) * 0.25f);
	}
}
