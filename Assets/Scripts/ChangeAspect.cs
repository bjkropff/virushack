using UnityEngine;
using System.Collections;

public class ChangeAspect : MonoBehaviour {
	
	public float baseAspect = 16f / 9f;

	// Use this for initialization
	void Start () {
		Camera cam = GetComponent<Camera> ();
		float aspect = baseAspect / cam.aspect;
		cam.orthographicSize *= aspect;
		Resolution res = Screen.currentResolution;
		Debug.Log ("Height: " + res.height);
		Debug.Log ("Width: " + res.width);
		Debug.Log ("Aspect: " + aspect);
		Debug.Log ("Size: " + cam.orthographicSize);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
