using UnityEngine;
using System.Collections;

public class AttackAnimation : MonoBehaviour {

	//determines if player attacked
	bool attacking = false;

	//timer that triggers after player attacks
	float attackTimer = 0f;

	//amount of time that passes until the player can attack again
	float attackTimeLimit = 0.1f;
	
	//animation states
	const int STATE_IDLE = 0;
	const int STATE_ATTACK = 1;

	//current animation state
	int currentState = STATE_IDLE;

	Animator animator; //animator

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();

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
				changeState(STATE_IDLE);
				attackTimer = 0f;
			}
		}
	}

	void OnMouseRelease(){
		
		if(Input.GetMouseButtonUp(0)){
			
			//player is attacking
			attacking = true;
			changeState(STATE_ATTACK);
		}
	}

	void changeState(int state){
		
		if(currentState == state)
			return;
		
		switch (state){
			
		case STATE_IDLE:
			animator.SetInteger("state", STATE_IDLE);
			break;
		case STATE_ATTACK:
			animator.SetInteger("state", STATE_ATTACK);
			break;
		}
		
		currentState = state;
		
	}
}
