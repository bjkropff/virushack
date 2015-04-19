using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 10;
	public GameObject deathParticle;

	private int health = 2;
	private bool isAlive = true;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		anim.SetBool ("damaged", false);
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
			Collider2D playerCol = GetComponent<Collider2D>();
			takeDamage (playerCol, col);
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "sentry") {
			//grab the Collider2D objects to pass to the Physics2D to ignore
			Collider2D playerCol = GetComponent<Collider2D>();
			Collider2D enemyCol = col.gameObject.GetComponent<Collider2D>();
			takeDamage (playerCol, enemyCol);
		}
	}

	void takeDamage(Collider2D playerCol, Collider2D enemyCol) {
		health--;
		Debug.Log (health);

		if (health == 0) {
			StartCoroutine ("reloadLevel");
		} else {
			anim.SetBool ("damaged", true);
			Physics2D.IgnoreCollision(playerCol, enemyCol, true);
			StartCoroutine (invincible(playerCol, enemyCol));
		}
	}

	IEnumerator invincible(Collider2D pCol, Collider2D eCol) {
		yield return new WaitForSeconds(1.0f);
		Debug.Log("Detect collisions again!");
		Physics2D.IgnoreCollision (pCol, eCol, false);
		anim.SetBool ("damaged", false);
		StopCoroutine("invincible");
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
