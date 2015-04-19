using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour {

	public GameObject player;

	public AudioSource playerSpawnSound;

	// Use this for initialization
	void Start () {
		playerSpawnSound.Play ();
		player.transform.position = GetComponent<Transform>().position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
