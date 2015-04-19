using UnityEngine;
using System.Collections;

public class ExitLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.name == "Player")
		{
			Application.LoadLevel(0); // load level select	
		}
	}
}
