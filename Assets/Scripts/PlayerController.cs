using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float maxSpeed = 10;
	public AudioClip damagedSound;
	public AudioClip deathSound;
	public AudioClip spawnSound;
	public ParticleSystem deathParticle;

	private int health = 2;
	private bool isAlive = true;

	Animator anim;


	//variables for global gameobject
	LevelManager levelScript;

	
	// Use this for initialization
	void Start () {
		GameObject lm = GameObject.Find ("LevelManger");
		levelScript = (lm != null) ? lm.GetComponent<LevelManager> () : null;

		if (levelScript != null && levelScript.isShieldActive) {
			health = 2;
		} else {
			health = 1;
		}
		anim = GetComponent<Animator> ();
		anim.SetBool ("damaged", false);

		PlaySound (spawnSound);
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

	//called when the player detects a collision with an unfriendly object
	//needs to be provided with the Collider2d of both the player and the enemy
	//to turn the player invulnerable for a short time.
	void takeDamage(Collider2D playerCol, Collider2D enemyCol) {

		health--;

		Debug.Log (health);

		if (health == 0) {
			PlaySound (deathSound);
			StartCoroutine ("reloadLevel");
		} else {
			PlaySound (damagedSound);
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

		Instantiate(deathParticle, gameObject.transform.position, Quaternion.identity);

		gameObject.GetComponent<SpriteRenderer> ().enabled = false;

		yield return new WaitForSeconds(2.0f);
		Application.LoadLevel(Application.loadedLevel);
	}

	//takes an audio sounds, creates a new object and plays the sound
	void PlaySound(AudioClip sound) {
		GameObject soundObject = new GameObject ("Temporary Game Object (Sound)");
		AudioSource soundSource = soundObject.AddComponent<AudioSource> ();
		soundSource.clip = sound;
		soundSource.volume = 1.0f;
		soundSource.pitch = 1.0f;
		soundSource.Play ();
		Destroy (soundObject, sound.length + 0.1f);
	}
}
