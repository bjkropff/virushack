using UnityEngine;
using System.Collections;

public class SentryPatrol : MonoBehaviour {

	public GameObject target;
	public float maxSpeed = 5.0f;
	public float moveHorizontal = 1.0f;
	float moveVertical = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2 (moveHorizontal * maxSpeed, moveVertical * maxSpeed);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		moveHorizontal = -moveHorizontal;
	}


}
