using UnityEngine;
using System.Collections;

public class HitBall : MonoBehaviour {

	int ballState = 0;

	const int STATE_SLOW = 0;
	const int STATE_MED = 1;

	public int health = 1;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0){
			Destroy(gameObject);
		}
	}
	

	void OnCollisionEnter2D(Collision2D col){
		
		//on collision with the ball
		if(col.gameObject.name == "Ball"){
			ballState = col.gameObject.GetComponent<SpeedAnimation>().getCurrentState();

			if(ballState == STATE_SLOW){
				col.gameObject.GetComponent<BounceMovement>().EnemyHit();
			}
			else if(ballState == STATE_MED){
				health--;
			}
		}
	}
}
