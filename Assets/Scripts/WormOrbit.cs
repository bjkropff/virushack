using UnityEngine;
using System.Collections;

public class WormOrbit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.GetComponent<WormOrbit>())
		{
			GameObject player = this.transform.parent.gameObject;
			transform.RotateAround(player.transform.position, Vector3.forward, 1.0f);
		}
	}
}
