using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

}
