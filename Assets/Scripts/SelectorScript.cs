using UnityEngine;
using System.Collections;

public class SelectorScript : MonoBehaviour {

	public void LoadScene(int level)
	{
		GameObject lm = GameObject.Find ("LevelManager");
		if (lm != null && Application.loadedLevelName == "win") {
			DestroyImmediate (lm);
		}
		Application.LoadLevel(level);
	}

	public void ExitGame()
	{
		Application.Quit ();
	}
}
