﻿using UnityEngine;
using System.Collections;

public class TrojanPad : MonoBehaviour {

	public Color padColor = Color.red;
	GameObject levelManager;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.Find ("LevelManager");	
	}

	// Update is called once per frame
	void Update () {
		if (levelManager.GetComponent<LevelManager>().isTrojanActive)
		{
			this.GetComponent<SpriteRenderer>().color = padColor;
		}
	}
}
