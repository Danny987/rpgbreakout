using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	bool attacking = false; //attacking state
	float attackTimer = 0f;
	float attackTimeLimit = 0.1f;
	
	//animation states
	//const int STATE_IDLE = 0;
	//const int STATE_ATTACK = 1;
	//current animation state
	//int currentState = STATE_IDLE;

	public float weakHit = 1f;
	public float medHit = 1f;
	public float strongHit = 300f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		OnMouseRelease ();
		
		//if player is attacking
		if(attacking){
			//increment attack timeer
			attackTimer += Time.deltaTime;
			
			//whent he attack has reached it's max duration
			if(attackTimer >= attackTimeLimit){
				
				//stop attacking and reset timer
				attacking = false;
				attackTimer = 0f;
			}
		}
	}

	void OnMouseRelease(){
		
		if(Input.GetMouseButtonUp(0)){		
			//player is attacking
			attacking = true;
		}
	}

	void OnTriggerStay2D(Collider2D col){

		//if the player hit zone is colliding with the ball
		if(col.gameObject.name == "Ball"){

			//if the player is attacking
			if(attacking){
				col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
				//col.gameObject.rigidbody2D.AddForce(new Vector2(0, 250.0f));
				Vector3 dir = col.gameObject.transform.position - transform.position;
				
				dir = dir.normalized;
				//Debug.Log(dir.ToString());
				if(dir.x >= -0.3f && dir.x <= 0.3f){
					//dir = Vector2.up;
					
					//stop x movement of the ball
					Vector2 ballVel = col.gameObject.GetComponent<Rigidbody2D>().velocity;
					//ballVel.x = 0;
					col.gameObject.GetComponent<Rigidbody2D>().velocity = ballVel;
					
					col.gameObject.GetComponent<Rigidbody2D>().AddForce(dir * strongHit);
					//Debug.Log(dir.ToString() + " " + "Strong Hit");
				}
				else if(dir.x >= -0.8f && dir.x <= 0.8f){
					col.gameObject.GetComponent<Rigidbody2D>().AddForce(dir * strongHit);
					//Debug.Log(dir.ToString() + " " + "Med Hit");
				}
				else{
					col.gameObject.GetComponent<Rigidbody2D>().AddForce(dir * strongHit);
					//Debug.Log(dir.ToString() + " " + "Weak Hit");
				}


				//attack ended, no longer attacking
				attacking = false;
			}

		}
	}
}
