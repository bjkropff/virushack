using UnityEngine;
using System.Collections;

public class ExitLevel : MonoBehaviour {

	GameObject manager;
	public int nextLevel = 0;
	public int completeLevel;

	// Use this for initialization
	void Start () {
		manager = GameObject.Find("LevelManager");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.name == "Player")
		{
			if (completeLevel > 0)
			{
				manager.GetComponent<LevelManager>().levelList[completeLevel-1] = true;
			}
			Application.LoadLevel(nextLevel); // load level select	
		}
	}
}
