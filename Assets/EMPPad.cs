using UnityEngine;
using System.Collections;

public class EMPPad : MonoBehaviour {

	GameObject levelManager;
	
	// Use this for initialization
	void Start () {
		levelManager = GameObject.Find ("LevelManager");	
	}
	
	// Update is called once per frame
	void Update () {
		if (levelManager.GetComponent<LevelManager>().isEMPActive)
		{
			this.GetComponent<SpriteRenderer>().color = Color.yellow;
		}
	}
}
