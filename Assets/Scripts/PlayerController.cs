using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 10;
	public GameObject deathParticle;

	private bool isAlive = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		if (isAlive) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveHorizontal * maxSpeed, moveVertical * maxSpeed);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "lazerbeam") {
			StartCoroutine("reloadLevel");
		}
		if (col.gameObject.tag == "sentry") {
			Debug.Log ("Hit a sentry");
		}

	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "sentry") {
			StartCoroutine("reloadLevel");
		}
	}

	IEnumerator reloadLevel() {

		isAlive = false;

		deathParticle.transform.position = gameObject.transform.position;
		deathParticle.GetComponent<ParticleSystem>().Play ();

		gameObject.transform.position = new Vector2(100, 100);
		GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);

		yield return new WaitForSeconds(2.0f);
		Application.LoadLevel(Application.loadedLevel);
	}
}
