using UnityEngine;
using System.Collections;

public class LazerController : MonoBehaviour {

	public float beamDelay = 1f; //amt of time before beam activites
	public float timeOff = 3f; //amt of time beam will be on
	public float timeOn = 3f; //amt of time beam will be off
	public GameObject thisBeam; //this lazer's child


	private float timeSinceSwitch;
	private bool isActive = false;

	// Use this for initialization
	void Start () {
		thisBeam.SetActive (false);
		timeSinceSwitch = timeOn - beamDelay;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		timeSinceSwitch += Time.fixedDeltaTime;

		if (isActive) {

			if(timeSinceSwitch > timeOn) {
				isActive = false;
				timeSinceSwitch = 0;
				thisBeam.SetActive(false);
			}
		} else {

			if(timeSinceSwitch > timeOff) {
				isActive = true;
				timeSinceSwitch = 0;
				thisBeam.SetActive(true);
			}
		}
	}
}
