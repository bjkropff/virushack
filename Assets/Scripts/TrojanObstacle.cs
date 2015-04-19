using UnityEngine;
using System.Collections;

public class TrojanObstacle : MonoBehaviour {

	public Color obstacleColor = Color.green;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.name == "Player")
		{
			Color playerColor = coll.gameObject.GetComponent<Trojan>().currentColor;
			//Debug.Log ("I am: " + obstacleColor);
		//	Debug.Log ("Player is: " + playerColor);
			if (playerColor == obstacleColor)
			{
				this.GetComponent<BoxCollider2D>().isTrigger = true;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.name == "Player")
		{
			Color playerColor = coll.gameObject.GetComponent<Trojan>().currentColor;
			if (playerColor != obstacleColor)
			{
				this.GetComponent<BoxCollider2D>().isTrigger = false;
			}
		}
	}
}
