using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

	AudioSource playerDeath;
	AudioSource playerSpawn;
	AudioSource playerDamage;

	// Use this for initialization
	void Start () {
		playerDeath = GameObject.Find ("AudioManager/PlayerDeathSound").GetComponent<AudioSource>();
		playerDamage = GameObject.Find ("AudioManager/PlayerDamageSound").GetComponent<AudioSource>();
		playerSpawn = GameObject.Find ("AudioManager/PlayerSpawnSound").GetComponent<AudioSource>();
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void playerDeathPlay() {
		playerDeath.Play ();
	}

	public void playerDamagePlay() {
		playerDamage.Play ();
	}

	public void playerSpawnPlay() {
		playerSpawn.Play ();
	}
}
