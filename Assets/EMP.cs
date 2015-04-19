using UnityEngine;
using System.Collections;

public class EMP : MonoBehaviour {
	
	GameObject levelManager;
	public bool pulseAvailable = false;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.Find("LevelManager");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.M))
		{
			if (pulseAvailable)
			{
				Debug.Log ("ZZZZAAAPPPPP!");
				pulseAvailable = false;
			}
			else {
				Debug.Log ("No EMP!");
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.name == "EMPPad")
		{
			if (levelManager.GetComponent<LevelManager>().isEMPActive)
			{
				Debug.Log("EMP active!");
				pulseAvailable = true;
								
				//activateWorms();
			}
		}
	}
}
