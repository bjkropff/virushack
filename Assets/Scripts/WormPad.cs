using UnityEngine;
using System.Collections;

public class WormPad : MonoBehaviour {

	GameObject levelManager;
	public int wormsGranted = 2;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.Find ("LevelManager");	
	}
	
	// Update is called once per frame
	void Update () {
		if (levelManager.GetComponent<LevelManager>().isWormActive)
		{
			this.GetComponent<SpriteRenderer>().color = Color.white;
		}
	}
}
