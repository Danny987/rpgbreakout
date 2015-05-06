using UnityEngine;
using System.Collections;

public class Break : MonoBehaviour {

	//variables that represent the current animation state
	int state = 0;

	//current animation state, starts in the full state
	//int currentState = STATE_FULL;

	//ball speeds, obtained from the Speeds class
	//float speed_slow = Speeds.speed_slow;
	float speed_med = Speeds.speed_med;
	//float speed_fast = Speeds.speed_fast;

	//destructable animator
	Animator animator;

	//is the sprite animated?
	bool animated = false;

	//health of the destructable, defaults at 2
	public int health = 2;

	//ball gameobject
	public GameObject ball;

	//current speed of the ball
	float ballSpeed = 0;

	public bool hasDestroyedState = false;



	// Use this for initialization
	void Start () {
		//get the animator
		if(this.GetComponent<Animator> ()){
			animated = true;
			animator = this.GetComponent<Animator> ();
		}
	}
	
	// Update is called once per frame
	void Update () {

		//when the destructables health drops to 0
		if(health <= 0){

			//destroy this gameobject if it doesn't have a destroyed animation
			if(!hasDestroyedState){
				Destroy(gameObject);
			}
			//has a destroyed animation, only destroy collider
			else{
				gameObject.GetComponent<BoxCollider2D>().enabled = false;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col){

		//on collision with the ball
		if(col.gameObject.name == "Ball"){

			//get the current speed of ball
			ballSpeed = col.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;

			//subtract health depending on the speed of the ball
			if(ballSpeed > speed_med){
				health -= 2;
			}
			else {
				health -= 1;
			}

			//go to next animation state
			state++;
			if(animated)animator.SetInteger("state", state);
		}
	}
}
