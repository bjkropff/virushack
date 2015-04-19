using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	public bool level2aLock = false;
	public bool level2bLock = false;
	public bool level2cLock = false;
	//bool level3Lock = false;

	public bool[] levelList; 


	void Awake()
	{
		levelList = new bool[]{false, false, false, false, false};
		DontDestroyOnLoad(this);
	}

	void Start() 
	{

	}

	void Update()
	{
		if (GameObject.Find("LevelSelect"))
		{
			if (levelList[0] == true) 
			{
				GameObject.Find ("Level 2a").GetComponent<Button>().interactable = true;
			 	GameObject.Find ("Level 2b").GetComponent<Button>().interactable = true;
				GameObject.Find ("Level 2c").GetComponent<Button>().interactable = true;
				GameObject.Find ("Level 1").GetComponent<Image>().color = Color.green;
			}

			if (levelList[1] == true)
				GameObject.Find ("Level 2a").GetComponent<Image>().color = Color.green;
			if (levelList[2] == true)
				GameObject.Find ("Level 2b").GetComponent<Image>().color = Color.green;
			if (levelList[3] == true)
				GameObject.Find ("Level 2c").GetComponent<Image>().color = Color.green;

			if (levelList[1] && levelList[2] && levelList[3])
				GameObject.Find ("Level 3").GetComponent<Button>().interactable = true;
		}
	}

	void OnLevelWasLoaded(int level)
	{
		if (level == 0)
		{
			levelList = new bool[]{false, false, false, false, false};
		}
	}
}
