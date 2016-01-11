using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//--------------------Programmerare Ludvig Emtås SP15-----------------------------
//*******************************************************************************
//Scriptet aanvänds för att printa ut timers och events
//*************************************************************************************'
public class Printer : MonoBehaviour {

	public Text scoreText;
	public Text goldLeftText;
	public Text pacmanLivesText;
	public Text courageTimeText;
	public Text mapTimeText;
	public Text powerChargesText;
	public Text infoText;
	public Text abilityColdownText;
	public Text importantInfo;
	public Text tutoInfoText;
	public Transform tutorialPanel;
	public Transform infoPanel;

	public float infoTextVisible;

	float timer;
	bool fadyeActive = false;
	Text currentText;

	float panelTimer;
	bool closePanel = false;

	bool scaleTutoPanelUp = false;
	float scaleSpeed = 3f;

	bool scaleInfoPanel = false;
	
	void Start () {	
		
	}
//--------------Score-------------------------
	public void PrintScore(int i){
		scoreText.text = i.ToString();
	}
//--------------Gold Left-----------------
	public void PrintGoldLeft(int i){
		goldLeftText.text = i.ToString();
	}
//-------------Pacman Lives----------
	public void PrintPacmanLives(int i){
		pacmanLivesText.text = i.ToString();
	}
//--------------Courage--------------------------
	public void PrintCourageTime(int i){
		courageTimeText.text = i.ToString();
	}
	public void PrintCourageNothing(){
		courageTimeText.text = "" .ToString();
	}
//-------------Map Timer-----------------------
	public void PrintMapTime(int i){
		mapTimeText.text = i.ToString();
	}
	public void PrintPowerCharges(int i){
		powerChargesText.text = i.ToString();
	}
//-----------------Info--------------------------
	public void PrintInfoText(string s){
		//infoText.text = s.ToString();
		CloseInfoMethod();
		infoPanel.gameObject.SetActive(true);
		infoPanel.gameObject.GetComponent<RectTransform>().localScale = new Vector2(0.1f, 0.1f);
		infoText.text = s.ToString();
		scaleInfoPanel = true;
		//CurrentTextMethod(infoText);
	}
//---------------Important Info------------------
	public void PrintImportantInfo(string s){
		PrintImportantInfoNothing();
		importantInfo.text = s.ToString();
	}
	public void PrintImportantInfoRespawn(int i){
		PrintImportantInfoNothing();
		importantInfo.text = "Respawning in: " + i.ToString();
	}

//-------------Print Nothing-------------------------
	public void PrintInfoNotingText(){
		infoText.text = "".ToString();
	}
	public void PrintImportantInfoNothing(){
		importantInfo.text = "".ToString();
	}
//-------------Print Ability CD--------------------
	public void AbilityCoolDownText(int i){
		abilityColdownText.text = i.ToString();
	}
//----------Fadye Counter / Fixed Update-------
	void FixedUpdate(){
		if(fadyeActive == true){
			timer += Time.deltaTime;			
		}
		if(timer >= infoTextVisible){
			//currentText.text = "".ToString();
			infoPanel.gameObject.SetActive(false);
			fadyeActive = false;
		}
		if(scaleTutoPanelUp == true){
			tutorialPanel.gameObject.GetComponent<RectTransform>().localScale = Vector2.Lerp(tutorialPanel.transform.localScale, new Vector2(1, 1), scaleSpeed * Time.deltaTime);
		}if(scaleInfoPanel == true){
			infoPanel.gameObject.GetComponent<RectTransform>().localScale = Vector2.Lerp(infoPanel.transform.localScale, new Vector2(1, 1), scaleSpeed * Time.deltaTime);
		}

		if(closePanel == true){
			panelTimer += Time.deltaTime;
		}
		if(panelTimer >= 10f){
			tutorialPanel.gameObject.SetActive(false);
			closePanel = false;
		}
		/*if(Input.GetKeyDown(KeyCode.L)){
			PrintInfoText("hello");
		}*/
	}
	/*void CurrentTextMethod(Text theText){
		timer = 0;
		fadyeActive = true;
		currentText = theText;
	}*/
	void CloseInfoMethod(){
		timer = 0;
		fadyeActive = true;
	}
	void ClosePanelMethod(){
		panelTimer = 0;
		closePanel = true;

	}
//-----------TutorialPanel--------------------
	public void PrintTutorialPanel(string s){
		ClosePanelMethod();
		tutorialPanel.gameObject.SetActive(true);
		tutorialPanel.gameObject.GetComponent<RectTransform>().localScale = new Vector2(0.1f, 0.1f);
		tutoInfoText.text = s.ToString();
		scaleTutoPanelUp = true;

	}




}
