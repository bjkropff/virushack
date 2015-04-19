using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 10;
	public bool hasWorm = true;
	public GameObject wormDecoy;
	public int numWorms = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		GetComponent<Rigidbody2D>().velocity = new Vector2 (moveHorizontal * maxSpeed, moveVertical * maxSpeed);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			if(hasWorm)
			{
				Debug.Log ("DECOY LAUNCH");
				hasWorm = false;
				launchDecoy();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "lazerbeam") {
			Debug.Log("Hit a lazerbeam");
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "sentry") {
			Debug.Log ("Hit a sentry");
		}
	}

	void launchDecoy()
	{
		Rigidbody2D decoy;
		//decoy = Instantiate(wormDecoy, transform.position, transform.rotation) as Rigidbody2D;

		for (int i = 0; i < numWorms; i++) {
			float angle = i * Mathf.PI * 2 / numWorms;
			Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * 1;
			Vector3 pos2 = pos + transform.position;
			GameObject temp = Instantiate(wormDecoy, pos2, Quaternion.identity) as GameObject;
			temp.transform.parent = transform;
		}
	}
}
