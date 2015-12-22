using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

//Välkommen! Vad kul att du är här! Det här scriptets funktion är att pausa spelet. Det här scriptet är beroende av att den har rätt childs. Vi har satt scriptet på en Canvas som sen har panels under 
//sig. Scriptet aktiverar och inaktiverar Childs till gameobjectet den sitter på, vi sätter det på en Canvas. Olika panels aktiveras beroende på vilken knapp du trycker på.

public class Pause : MonoBehaviour {

	private GameObject pausePanel; //Dessa variabeler är de olika UIs som syns. Defult ser man inGamePanel. Den stängs av när man trycker på esc eller P. 
	private GameObject rUSurePanel; //<---Denna panel kommer upp för att fråga dig om du är säker på att du vill avsluta spelet. Den aktiverar två olika texter beroende på vilken knapp du tryckt.
	private GameObject inGamePanel;

	private GameObject quitingText; //det här är de två texterna som kan visas i rUSurePanel.
	private GameObject returningToMenuText;

	private bool imQuiting; //Denna bool variabeln är till för att berätta vilken knapp av quit och mainMenu du tryckt på. Beroende på vilken, kommer knappen sureYes att göra olika saker.
	private bool gamePaused; //Denna bool behövs bara för att inget ska hända under pausen när man tycker på esc och p.




		void Start () {

		imQuiting = false;

		inGamePanel = this.gameObject.transform.GetChild(0).gameObject; //Här deklarerar jag alla gameobjects så att scriptet hittar alla texter, panels och bottons.
		pausePanel = this.gameObject.transform.GetChild(1).gameObject;
		rUSurePanel = this.gameObject.transform.GetChild(2).gameObject;
		quitingText = this.gameObject.transform.GetChild(2).GetChild(3).gameObject;
		returningToMenuText = this.gameObject.transform.GetChild(2).GetChild(2).gameObject;

	}

	void Update () {		





	
		if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) //Här ser du att tiden stannar och pausePanel aktiveras och inGamePaneln inaktiveras. gamePaused boolen blir true.
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

	public void AreYouSure() //Denna metod körs när du klickar på en knapp som inte är resume. rUSurePanel aktiveras och frågar spelaren om den är säker på det val den gjort.
	{
		pausePanel.SetActive(false);
		rUSurePanel.SetActive(true);

		if(imQuiting == true) //Här kollar den om du klickade på quit eller inte. Den sätter på den texten som passar.
		{
			quitingText.SetActive(true);
			returningToMenuText.SetActive(false);
		}
		else{
			returningToMenuText.SetActive(true);
			quitingText.SetActive(false);
		}
	}

	public void Resumel() //Som du kanske förstår används denna när du klickar på resume knappen. Tiden sätts på och gamePause blir false och rätt panel visas.
	{
		Time.timeScale = 1;

		inGamePanel.SetActive(true);
		pausePanel.SetActive(false);

		gamePaused = false;
	}

	public void Quit() //stänger av spelet.
	{
		Application.Quit();

	}
	public void MainMenu() //laddar Scenen som heter Startmeny.
	{
		SceneManager.LoadScene("Startmeny");

		Destroy(gameObject);
	}
	public void ChangedMyMind() //När spelet frågar díg om du är säker och svarar nej sker denna metod.
	{
		rUSurePanel.SetActive(false);
		pausePanel.SetActive(true);

		imQuiting = false;

	}
	public void QuitingClick() // Om du trycker på quit ändras denna bool så att scriptet kan visa rätt text.	
	{
		imQuiting = true;
	}
	public void LeavingTheGame() //trycker du på yes när du blir frågad om du vill lämna spelet kommer denna metod att spelas. Beroende på vad imQuiting boolen är kommer det hända olika saker.
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
