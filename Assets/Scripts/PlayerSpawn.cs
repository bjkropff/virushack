using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour {

	GameObject player;
	public AudioSource playerSpawn;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		player.transform.position = GetComponent<Transform>().position;
		playerSpawn = GameObject.Find ("AudioManager/PlayerSpawnSound").GetComponent<AudioSource>();
		playerSpawn.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
