using UnityEngine;
using System.Collections;

public class Trojan : MonoBehaviour {

	public Color currentColor = Color.white;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.name == "TrojanPad")
		{
			Color padColor = coll.gameObject.GetComponent<TrojanPad>().padColor;
			currentColor = padColor;
			this.gameObject.GetComponent<SpriteRenderer>().color = padColor;
		}
	}
}
