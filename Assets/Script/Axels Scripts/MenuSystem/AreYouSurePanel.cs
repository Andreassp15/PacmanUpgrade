using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AreYouSurePanel : MonoBehaviour {

	private Text message;

	private int whatMessage;

	private List<string> messagesList;

	private GameObject questioner;
	private GameObject areUSurePanel;

	void Start () {

		message = transform.GetChild(2).transform.GetChild(0).GetComponent<Text>();
		areUSurePanel = transform.GetChild(2).gameObject;

		messagesList = new List<string>();

		messagesList.Add("Giving up? Believe in yourself and try again!"); // 											<--- 0
		messagesList.Add("Only dirt peasents return to Main Menu...");
		messagesList.Add("If you quit you will lose all your progress and your parents will be very disappointed...");
		messagesList.Add("Going back to Main Menu? But you were doing so good!The world needs you to collect coins!");
		messagesList.Add("May the coin collector force be with you, always...");
	
		messagesList.Add("Excellent work, but there is more coins to collect."); 										// <--- 5
		messagesList.Add("Wow! Never have I seen such good walking forward");
		messagesList.Add("Doth my eyes deceive me? You just collected does coins like'th it was nothing!");
		messagesList.Add("By Thors beard, you didn't care about the creature, you collected does coins like it was nobodies business");
		messagesList.Add("Perfect! You are here, I hope you are ready for an epic adventure!");

		messagesList.Add("The first task i give you is to walk to the end of this forest and collect a coin.");					//<-----10
		messagesList.Add("You move by using the W A S D keys on your keyboard");		
		messagesList.Add("Whoa! I almost forgot, you have a special ability, press SPACE and check it out!");
		messagesList.Add("Cool huh? You can throw that shield and pressing SPACE again will allow you to teleport to your shield!");
		messagesList.Add("What was that you may ask? The field in the bubble drags coins to you, an ancient power passed down for generations.");
		messagesList.Add("That, my humble coin collector, is a decoy! Place it with Space and than creatures will follow it instead of you!");

	}

	public void WhatMessage(string o, GameObject g)
	{

		questioner = g;

		if(o == "Game Over Quitting")
		{
			whatMessage = 0;
		}
		else if(o == "To Menu")
		{
			whatMessage = 1;
		}
		else if(o == "Quitting")
		{
			whatMessage = 2;
		}
		else if(o == "Victory Main Menu")
		{
			whatMessage = 3;
		}
		else if(o == "Game Over Main Menu")
		{
			whatMessage = 4;
		}
		else if(o == "Victory Continue")
		{
			whatMessage = 5;
		}
		else if(o == "First Tutorial") //
		{								//
			whatMessage = 6;			//	
		}								 //
		else if(o == "Second Tutorial")  // <--------tutorial victory messages.
		{								 //
			whatMessage = 7;			//
		}								//
		else if(o == "Third Tutorial")  //
		{
			whatMessage = 8;
		}
		else if(o == "Tutorial Message One")  //
		{										//
			whatMessage = 9;					  //
		}										    //
		else if(o == "Tutorial Message Two") 		 //
		{											  //
			whatMessage = 10;						  //
		}											  //
		else if(o == "Tutorial Message Three") 		  //
		{											  //
			whatMessage = 11;						  //
		}											  //
		else if(o == "Tutorial Message Four") 		  //
		{											  //
			whatMessage = 12;						  //
		}											  //
		else if(o == "Tutorial Message Four") 		  //
		{											  // <------ Skriv ability tutorials här Axel! bara en påminnelse.
			whatMessage = 12;
		}
		message.text = messagesList[whatMessage];	

	}
	public void AnswareIsNo()
	{
		WhoToReactivate().SetActive(true);
		areUSurePanel.SetActive(false);

	}
	public void AnswareIsYes()
	{
		if(whatMessage == 1 || whatMessage == 3 || whatMessage == 4)
		{
			LoadMainMenu();
		}
		else if(whatMessage == 0 || whatMessage == 2)
		{
			Quit();
		}
		else if(whatMessage >= 9 && whatMessage <= 15)
		{
			areUSurePanel.SetActive(false);

			GameObject tutorialScript = GameObject.Find("TutorialScript");

			tutorialScript.GetComponent<TutorialScript>().OneMessageShown();

		}
	}

	public GameObject WhoToReactivate()
	{
		return questioner;
	}
	public void LoadMainMenu()
	{
		SceneManager.LoadScene("Startmeny");
		Destroy(GameObject.Find("SelectionInfo"));
	}
	public void Quit()
	{
		Application.Quit();
	}

}
