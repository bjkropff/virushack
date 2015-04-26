using UnityEngine;
using System.Collections;

public class WormDecoy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject[] sentryList = GameObject.FindGameObjectsWithTag("sentry");
		foreach (GameObject go in sentryList)
		{
			go.gameObject.GetComponent<SentryPatrol>().target = this.gameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
