using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		player.transform.position = GetComponent<Transform>().position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
