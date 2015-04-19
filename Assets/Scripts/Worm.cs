using UnityEngine;
using System.Collections;

public class Worm : MonoBehaviour {

	public GameObject levelManager;
	public GameObject wormDecoy;
	public int numWorms = 0;
	public int activeWorms = 0;
	public int maxWorms = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (numWorms > 0)
			{
				launchDecoy();
			}
			else {
				Debug.Log ("No worms!");
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.name == "WormPad")
		{
			if (levelManager.GetComponent<LevelManager>().isWormActive)
			{
				Debug.Log("Worms replenished: " + numWorms);
				numWorms += coll.gameObject.GetComponent<WormPad>().wormsGranted;
				if (numWorms > maxWorms)
				{
					numWorms = maxWorms;
				}

				activateWorms();
			}
		}
	}

	void activateWorms()
	{
		Debug.Log ("Worms activated.");
		activeWorms = numWorms;

		// delete any existing worms
		int deleteAmount = transform.childCount;
		int d = 0;
		while (d < deleteAmount)
		{
			if (transform.GetChild(d).gameObject.tag == "wormOrbit")
			{
				GameObject.Destroy(this.transform.GetChild (d).gameObject);
			}
			else
			{
				deleteAmount--;
			}
			d++;
		}
			
		for (int i = 0; i < activeWorms; i++) {
			float angle = i * Mathf.PI * 2 / activeWorms;
			Vector3 pos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * 1;
			Vector3 pos2 = pos + transform.position;
			GameObject temp = Instantiate(wormDecoy, pos2, Quaternion.identity) as GameObject;
			temp.tag = "wormOrbit";
			temp.AddComponent<WormOrbit>();
			temp.transform.parent = transform;
		}

	}

	void launchDecoy()
	{
		Debug.Log ("Worm deposited.");
		activeWorms--;
		numWorms--;
			
		// remove an orbiting worm
		int i = 0;
		int toDelete = -1;
		while ((toDelete < 0) && (i < transform.childCount))
		{
			if (transform.GetChild (i).gameObject.tag == "wormOrbit")
				toDelete = i;
			else
				i++;
		}
		GameObject.Destroy(transform.GetChild(toDelete).gameObject);
			
		// plant a worm
		GameObject.Instantiate(wormDecoy, this.transform.position, Quaternion.identity);  // as GameObject;
		
	}
}
