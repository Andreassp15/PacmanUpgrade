using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour {

	private int numberOfMessagesShown;

	private SelectionInfo storage;
	private GameObject pacman;
	private AreYouSurePanel messageBoard;
	private GameObject areUSurePanel;

	private string whatMap;
	private int characterSelected;

	private GameObject zoneOne;
	private bool zoneOneHit;
	private GameObject zoneTwo;
	private bool zoneTwoHit;

	private bool abilityPerformed;

	private float time;


	void Start () {

		numberOfMessagesShown = 0;

		messageBoard = GameObject.Find("Canvas").GetComponent<AreYouSurePanel>();
		storage = GameObject.Find("SelectionInfo").GetComponent<SelectionInfo>();
		pacman = GameObject.FindGameObjectWithTag("Pacman");
		whatMap = storage.WhatLevelSelected();
		areUSurePanel = GameObject.Find("AreYouSure?");

		characterSelected = storage.WhatCharacter();

		zoneOne = transform.GetChild(0).gameObject;
		zoneTwo = transform.GetChild(1).gameObject;

		abilityPerformed = false;

		time = 0.0f;
	}
	

	void Update () {

		if(whatMap == "Map_1")
		{
			if(zoneOneHit == true)
			{
				if(numberOfMessagesShown == 0)
				{
						TutorialMessages("Tutorial Message One");
				}
				else if(numberOfMessagesShown == 1)
				{
						TutorialMessages("Tutorial Message Two");
				}
				else if(numberOfMessagesShown == 2)
				{
						TutorialMessages("Tutorial Message Three");
				}
				else if(numberOfMessagesShown == 3)
				{
					Time.timeScale = 1;
				}
			}
			else if (zoneTwoHit == true)
			{

				if(numberOfMessagesShown == 3)
				{
					TutorialMessages("Tutorial Message Four");
				}
				if(abilityPerformed == true && numberOfMessagesShown == 4)
				{
					time += Time.deltaTime;
				}

				else if(numberOfMessagesShown == 4 && time == 3.0f)
				{
					if(characterSelected == 0)
					{
					TutorialMessages("Tutorial Message Five");
					}
					else if (characterSelected == 1)
					{
						TutorialMessages("Tutorial Message Six");
					}
				}
			}
		}

	
	}

	public void TutorialMessages(string tutorialMessage)
	{
		areUSurePanel.SetActive(true);
		messageBoard.WhatMessage(tutorialMessage, null);

		Time.timeScale = 0;

		string [] resposesList = new string[6] {"Aha.", "Really?", "Fine.", "I understand.", "All Right!", "Very well."};

		areUSurePanel.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = resposesList[Random.Range(0, resposesList.Length)];


	}
	public void OneMessageShown()
	{
		numberOfMessagesShown++;
	}
}
