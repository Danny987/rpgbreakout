using UnityEngine;
using System.Collections;

public class MouseMovement : MonoBehaviour {
	
	float moveSpeedMobileY = 2.0f;
	float moveSpeedMobileX = 2.0f;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		OnMouseClick ();
	}

	void OnMouseClick(){
		if(Input.touchCount > 0){

			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

			if(touchDeltaPosition.magnitude > 0.2){
				transform.GetComponent<Rigidbody2D>().velocity = new Vector2(touchDeltaPosition.x*moveSpeedMobileX, touchDeltaPosition.y*moveSpeedMobileY);
			}
			else{
				transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			}

		}
		else if(Input.GetMouseButton(0)){


			Vector2 p = transform.GetComponent<Rigidbody2D>().position;

			p.x += Input.GetAxis("Mouse X");
			p.y += Input.GetAxis("Mouse Y");


			transform.GetComponent<Rigidbody2D>().MovePosition(p);
		}
		else{
			transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}
	}

}
