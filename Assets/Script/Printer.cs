﻿using UnityEngine;
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

	float timer;
	bool fadyeActive = false;
	Text currentText;
	
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
		infoText.text = s.ToString();
		CurrentTextMethod(infoText);
	}
	public void PrintInfoArrows(string s1, int i, string s2){
		infoText.text = s1 + " " + i + " " + s2.ToString();
		CurrentTextMethod(infoText);
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
		if(timer >= 3){
			currentText.text = "".ToString();
			fadyeActive = false;
		}
	}
	void CurrentTextMethod(Text theText){
		timer = 0;
		fadyeActive = true;
		currentText = theText;
	}


}
