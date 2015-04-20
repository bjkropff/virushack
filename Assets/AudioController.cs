using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

	public AudioSource playerDeath;
	public AudioSource playerSpawn;
	public AudioSource playerDamage;
	public AudioSource mainMusic;

	// Use this for initialization
	void Start () {
		playerDeath = GameObject.Find ("AudioManager/PlayerDeathSound").GetComponent<AudioSource>();
		playerDamage = GameObject.Find ("AudioManager/PlayerDamageSound").GetComponent<AudioSource>();
		playerSpawn = GameObject.Find ("AudioManager/PlayerSpawnSound").GetComponent<AudioSource>();
		mainMusic = GameObject.Find ("AudioManager/MainMusic").GetComponent<AudioSource> ();
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
