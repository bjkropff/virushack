using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		GetComponent<Rigidbody2D>().velocity = new Vector2 (moveHorizontal * maxSpeed, moveVertical * maxSpeed);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "lazerbeam") {
			Debug.Log("Hit a lazerbeam");
		}
	}
}
