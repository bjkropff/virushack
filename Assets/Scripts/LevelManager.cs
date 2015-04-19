using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {
	
	public bool[] levelList; 
	public bool isWormActive = false;
	public bool isTrojanActive = false;
	public bool isShieldActive = false;
	public bool isEMPActive = false;
	public bool cheatsActive = true;

	void Awake()
	{
		levelList = new bool[]{false, false, false, false, false};
		isWormActive = false;
		isTrojanActive = false;
		isShieldActive = false;
		isEMPActive = false;
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
				isShieldActive = true;
			}

			if (levelList[1] == true)
			{
				GameObject.Find ("Level 2a").GetComponent<Image>().color = Color.green;
				isTrojanActive = true;
			}
			if (levelList[2] == true)
			{
				GameObject.Find ("Level 2b").GetComponent<Image>().color = Color.green;
				isWormActive = true;
			}
			if (levelList[3] == true)
			{
				GameObject.Find ("Level 2c").GetComponent<Image>().color = Color.green;
				isEMPActive = true;
			}

			if (levelList[1] && levelList[2] && levelList[3])
				GameObject.Find ("Level 3").GetComponent<Button>().interactable = true;
		}

		if (cheatsActive)
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				if(!isWormActive)
				{
					Debug.Log ("WORM UNLOCKED");
					isWormActive = true;
				}
			}
			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				if(!isTrojanActive)
				{
					Debug.Log ("TROJAN UNLOCKED");
					isTrojanActive = true;
				}
			}
			if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				if(!isShieldActive)
				{
					Debug.Log ("SHIELD UNLOCKED");
					isShieldActive = true;
				}
			}
			if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				if(!isEMPActive)
				{
					Debug.Log ("EMP UNLOCKED");
					isEMPActive = true;
				}
			}
		}
	}

	void OnLevelWasLoaded(int level)
	{
		if (level == 0)
		{
			levelList = new bool[]{false, false, false, false, false};
			isWormActive = false;
			isTrojanActive = false;
			isShieldActive = false;
			isEMPActive = false;
		}
	}
}
