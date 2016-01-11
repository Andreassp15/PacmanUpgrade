using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Results : MonoBehaviour {

	private GameObject victoryPanel;
	private GameObject gameOverPanel;
	private GameObject areUSurePanel;

	private GameObject connector;

	private GameObject score; //sammanlagda poäng;
	private GameObject time; //tiden det tog att spela banan.

	private GameObject storage;

	private AreYouSurePanel rUSure;

	private bool tutorialsDone;

	private int totalScore;

	void Start () {

		tutorialsDone = false;


		for(int i = 0; i < transform.childCount; i++)
		{
			if(transform.GetChild(i).name == "VictoryPanel")
			{
				victoryPanel = transform.GetChild(i).gameObject;
			}
			if(transform.GetChild(i).name == "GameOverPanel")
			{
				gameOverPanel = transform.GetChild(i).gameObject;
			}
		}

		areUSurePanel = transform.GetChild(2).gameObject;

		storage = GameObject.Find("SelectionInfo");
		rUSure = GetComponent<AreYouSurePanel>();
	
	}

	public void TurnOffVictoryPanel()
	{
		victoryPanel.SetActive(false);
	}
	public void TurnOffGameOverPanel()
	{
		gameOverPanel.SetActive(false);
	}
	public void TurnOnVictoryPanel(int bonusScoreTime, int score, int time)
	{
		Time.timeScale = 0;

		victoryPanel.SetActive(true);

		victoryPanel.transform.GetChild(1).GetComponent<Text>().text = score.ToString();

		victoryPanel.transform.GetChild(2).GetComponent<Text>().text = time.ToString();

		totalScore = score + storage.GetComponent<SelectionInfo>().WhatIsTheScore();

		 


		victoryPanel.transform.GetChild(3).GetComponent<Text>().text = "Time Bonus Score:" + bonusScoreTime.ToString() + "\n Total Score:" + totalScore.ToString();
	
	}
	public void TurnOnGameOverPanel(int score, int time)
	{
		totalScore = score + storage.GetComponent<SelectionInfo>().WhatIsTheScore();


		gameOverPanel.transform.GetChild(0).GetComponent<Text>().text = "Score:" + score.ToString() + "\nTime Survived:" + time.ToString() + 
			"\nTotal Score:" + totalScore.ToString();
	
		Time.timeScale = 0;

		gameOverPanel.SetActive(true);

	}
	public void ContinueButton()
	{
		Scene[] sceneList = new Scene[SceneManager.sceneCountInBuildSettings];
		sceneList = SceneManager.GetAllScenes();

		storage.GetComponent<SelectionInfo>().TotalScore(totalScore);

		Scene currentScene = SceneManager.GetActiveScene();

		for(int i = 0; i < sceneList.Length; i++)
		{
			if(sceneList[i].name == currentScene.name)
			{
				SceneManager.LoadScene(sceneList[i+1].name);
			}
		}
	



	}

	public void QuitingQuestion()
	{
		rUSure.WhatMessage("Game Over Quitting", gameOverPanel);
		areUSurePanel.SetActive(true);
		gameOverPanel.SetActive(false);
	}
	public void GameOverMainMenu()
	{
		rUSure.WhatMessage("Game Over Main Menu", gameOverPanel);

		areUSurePanel.SetActive(true);
		gameOverPanel.SetActive(false);
		areUSurePanel.transform.GetChild(2).gameObject.SetActive(false);
		areUSurePanel.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Teach me!";
	}
	public void VictoryPanelToMainMenu()
	{
		rUSure.WhatMessage("Victory Main Menu", victoryPanel);

		areUSurePanel.SetActive(true);
		victoryPanel.SetActive(false);
	}
	public void VictoryPanelContinue()
	{
		

		areUSurePanel.SetActive(true);
		victoryPanel.SetActive(false);
		areUSurePanel.transform.GetChild(2).gameObject.SetActive(false);

		if(tutorialsDone == false)
		{

						if(storage.GetComponent<SelectionInfo>().WhatLevelSelected() == "Map_1")
						{
							rUSure.WhatMessage("First Tutorial", victoryPanel);
							areUSurePanel.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Thank you, I was well trained.";
						}
						else if(storage.GetComponent<SelectionInfo>().WhatLevelSelected() == "Map_2")
						{
							rUSure.WhatMessage("Second Tutorial", victoryPanel);
							areUSurePanel.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Nice of you to notice!";


						}
						else if(storage.GetComponent<SelectionInfo>().WhatLevelSelected() == "Map_3")
						{
							rUSure.WhatMessage("Third Tutorial", victoryPanel);
							areUSurePanel.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Pff, I've seen scarier creatures.";
						}
		}
		else
		{
			rUSure.WhatMessage("Victory Continue", victoryPanel);
			areUSurePanel.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Bring'eth on!";
		}



	}
	public void TutorialsAreDone()
	{
		tutorialsDone = true;
	}
}
