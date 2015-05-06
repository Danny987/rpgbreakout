using UnityEngine;
using System.Collections;

public class RandomWalk : MonoBehaviour {

	Vector3 targetPos;

	public float speed = 10;

	int r = 0;

	// Use this for initialization
	void Start () {
		pickLocation ();
	}
	
	// Update is called once per frame
	void Update () {
		r = Random.Range (0, 100);

		if(r == 1){
			pickLocation ();
		}
	}

	void FixedUpdate(){
		this.GetComponent<Rigidbody2D>().AddRelativeForce((targetPos - transform.position) * 0.1f);
	}

	void pickLocation(){
		targetPos = Random.insideUnitCircle * 5;
	}

	void OnCollisionEnter2D(Collision2D col){
		pickLocation ();
	}
}
