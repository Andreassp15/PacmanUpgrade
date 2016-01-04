using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	private GameObject sceneTag;
	private GameObject pausePanel;
	private GameObject rUSurePanel;
	private GameObject inGamePanel;

	private GameObject quitingText;
	private GameObject returningToMenuText;

	private bool imQuiting;
	private bool gamePaused;




		void Start () {

		imQuiting = false;

		inGamePanel = this.gameObject.transform.GetChild(0).gameObject;
		pausePanel = this.gameObject.transform.GetChild(1).gameObject;
		rUSurePanel = this.gameObject.transform.GetChild(2).gameObject;
		quitingText = this.gameObject.transform.GetChild(2).GetChild(3).gameObject;
		returningToMenuText = this.gameObject.transform.GetChild(2).GetChild(2).gameObject;




		//DontDestroyOnLoad(gameObject);
		//DontDestroyOnLoad(pauseCanvas);

		//sceneTag = GameObject.FindGameObjectWithTag("Startmeny");

	}

	void Update () {		





	
		if(Input.GetKeyDown(KeyCode.Escape)) 
	{
			
			if(gamePaused == false)
			{																											
			Time.timeScale = 0;

			inGamePanel.SetActive(false);
			pausePanel.SetActive(true);

			gamePaused = true;
			}


	
	}

	}

	public void AreYouSure()
	{
		pausePanel.SetActive(false);
		rUSurePanel.SetActive(true);

		if(imQuiting == true)
		{
			quitingText.SetActive(true);
			returningToMenuText.SetActive(false);
		}
		else{
			returningToMenuText.SetActive(true);
			quitingText.SetActive(false);
		}
	}

	public void Resumel()
	{
		Time.timeScale = 1;

		inGamePanel.SetActive(true);
		pausePanel.SetActive(false);

		gamePaused = false;
	}

	public void Quit()
	{
		Application.Quit();

	}
	public void MainMenu()
	{
		SceneManager.LoadScene("Startmeny");

		Destroy(gameObject);
	}
	public void ChangedMyMind()
	{
		rUSurePanel.SetActive(false);
		pausePanel.SetActive(true);

		imQuiting = false;

	}
	public void QuitingClick()
	{
		imQuiting = true;
	}
	public void LeavingTheGame()
	{
		if(imQuiting == true)
		{
			Quit();
		}
		else
		{
			MainMenu();
		}
	}
}
