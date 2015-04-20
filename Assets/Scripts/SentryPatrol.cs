using UnityEngine;
using System.Collections;

public class SentryPatrol : MonoBehaviour {

	public string patrolType = "stationary";
	public string fallback = "stationary";
	public float maxSpeed = 5.0f;
	public float moveHorizontal = 0.0f;
	public float moveVertical = 0.0f;
	public GameObject target;
	public float stopTime = 10.0f;
	string oldPatrolType;
	float Timer;

	void Awake()
	{
		Timer = Time.time + stopTime;
	}

	// Use this for initialization
	void Start () {
		oldPatrolType = patrolType;
	}
	
	// Update is called once per frame
	void Update () {
		if (Timer < Time.time)
		{
			resetMovement();
			Timer  = Time.time + stopTime;
		}

		if (patrolType == "stationary")
		{
			// do nothing
		} else if (patrolType == "chase")
			this.transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, maxSpeed * Time.deltaTime);
		else
			GetComponent<Rigidbody2D>().velocity = new Vector2 (moveHorizontal * maxSpeed, moveVertical * maxSpeed);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "wall") {
			switch (patrolType) {
			case "leftright":
				moveHorizontal = -moveHorizontal;
				break;

			case "updown":
				if (coll.gameObject.tag == "wall") {
					moveVertical = -moveVertical;
				}
				break;

			case "clockwise":
				if (moveHorizontal != 0) {	
					moveVertical = -moveHorizontal;
					moveHorizontal = 0;
				} else {
					moveHorizontal = moveVertical;
					moveVertical = 0;
				}

				break;
			
			case "counterclockwise":
				if (moveHorizontal != 0) {	
					moveVertical = moveHorizontal;
					moveHorizontal = 0;
				} else {
					moveHorizontal = -moveVertical;
					moveVertical = 0;
				}
				break;

			case "stationary":
			default:
				break;

			}
		}
	}

	void pauseMovement()
	{
		Debug.Log("I'm stopping!");
		patrolType = "stationary";
	}

	void resetMovement()
	{
		Debug.Log ("I'm moving again...");
		patrolType = oldPatrolType;
	}

}
