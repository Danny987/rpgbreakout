using UnityEngine;
using System.Collections;

public class SpeedAnimation : MonoBehaviour {

	//variables that represent the current animation state
	const int STATE_SLOW = 0;
	const int STATE_MED = 1;

	//current animation state, starts in the slow state
	int currentState = STATE_SLOW;

	//ball speeds, obtained from the Speeds class
	float speed_slow = Speeds.speed_slow;
	float speed_med = Speeds.speed_med;
	//float speed_fast = Speeds.speed_fast;

	//speed of the ball
	float ballSpeed = 0;

	//ball animator
	Animator animator;

	// Use this for initialization
	void Start () {

		animator = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		//get the ball speed
		ballSpeed = transform.GetComponent<Rigidbody2D>().velocity.magnitude;

		//change the animation state depening on the ball speed
		if(ballSpeed <= speed_slow){
			changeState(STATE_SLOW);
		}else if(ballSpeed <= speed_med){
			changeState(STATE_MED);
		}
	}

	/*
	 * Given a state, changes the animator to that state.
	 */ 
	void changeState(int state){
		
		if(currentState == state)
			return;
		
		switch (state){
			
		case STATE_SLOW:
			animator.SetInteger("state", STATE_SLOW);
			break;
		case STATE_MED:
			animator.SetInteger("state", STATE_MED);
			break;
		}
		
		currentState = state;
		
	}

	public int getCurrentState(){
		return currentState;
	}
}
