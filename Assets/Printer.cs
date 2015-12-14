using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//*******************************************************************************
//Scriptet aanvänds för att printa ut timers och events
//*************************************************************************************'
public class Printer : MonoBehaviour {

	public Text scoreText;
	public Text goldLeftText;
	public Text pacmanLivesText;
	public Text courageTimeText;
	public Text mapTimeText;
	public Text infoText;
	public Text abilityColdownText;
	
	void Start () {			
	}
//---------------------Score-------------------------
	public void PrintScore(int i){
		scoreText.text = "Score: " + i.ToString();
	}
//-------------------Gold Left-----------------
	public void PrintGoldLeft(int i){
		goldLeftText.text = "Gold Left: " + i.ToString();
	}
//-----------------Pacman Lives----------
	public void PrintPacmanLives(int i){
		pacmanLivesText.text = "Lives: " + i.ToString();
	}
//--------------Print Courage--------------------------
	public void PrintCourageTime(int i){
		courageTimeText.text = "Courage Time: " + i.ToString();
	}
	public void PrintCourageNothing(){
		courageTimeText.text = "Courage Time: ".ToString();
	}
//-------------Print MAp Timer-----------------------
	public void PrintMapTime(int i){
		mapTimeText.text = "Time: " + i.ToString();
	}
//-----------------Print Info--------------------------
	public void PrintInfoText(string s){
		infoText.text = s.ToString();
	}
	public void PrintInfoRespawnText(int i){
		infoText.text = "Respawning in: " + i.ToString();
	}
	public void PrintInfoNotingText(){
		infoText.text = "".ToString();
	}
//---------------------Print Ability CD
	public void AbilityCoolDownText(int i){
		abilityColdownText.text = "Ability CD: " + i.ToString();
	}

}
