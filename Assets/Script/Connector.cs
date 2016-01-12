using UnityEngine;
using System.Collections;
//------------------Programmerare Sp15 Ludvig Emtås-------------------
//*****************************************************************************
//scriptet tar imot alla object pacman colliderar med, räknar poäng, liv, tider, och säger åt spöken vad
//dem ska göra via GhostMaster.
//************************************************************************************
public class Connector : MonoBehaviour {

	GameObject[] goldArray;
	public GameObject abilityMasterObject;
	public GameObject[] diamondsArray;
	public GameObject GhostMasterObject;
	public GameObject audioPlayerObject;
	GameObject pacmanObject;
	public GameObject MeteorMasterObject;
	public GameObject teleportOneWayObject;
	public GameObject pacmanKaiObject;
	public GameObject pacmanJonObject;
	public GameObject pacmanNicklasObject;
	public GameObject resultsObject;
	Results resultsScript;
	MeteorMaster meteorMasterScript;
	TeleportOneWay teleportOneWayScript;
	GhostMaster ghostMasterScript;
	pacmanMove PacmanMoveScript;
	AbilityMaster abilityMasterScript;
	AudioPlayer audioPlayerScript;
	int poisonCount = 4;
	int maxGold;
	int gold;
	int score;
	int lifeNeedScore;
	int courageCounter = 0;
	int pacmanLives = 3;
	int respawnTime = 5;
	int ghostKillScore = 5;
	int mapTime;
	public int startMapTime;

	bool courageActive = false;

	public GameObject PrinterObject;
	Printer PrinterScript;
	/*void Awake(){
		GameObject selectObject = GameObject.Find("SelectionInfo");
		int pacmanNumber = selectObject.gameObject.GetComponent<SelectionInfo>().WhatCharacter();
		if(pacmanNumber == 1){
			pacmanKaiObject.SetActive(true);
		}else if(pacmanNumber == 2){
			pacmanNicklasObject.SetActive(true);
		}else if(pacmanNumber == 3){
			pacmanJonObject.SetActive(true);

		}
	}*/

	void Start () {
		mapTime = startMapTime;
		resultsScript = resultsObject.GetComponent<Results>();
		audioPlayerScript = audioPlayerObject.GetComponent<AudioPlayer>();
		abilityMasterScript = abilityMasterObject.GetComponent<AbilityMaster>();
		meteorMasterScript = MeteorMasterObject.GetComponent<MeteorMaster>();
		pacmanObject = GameObject.FindGameObjectWithTag("FindPacmanObject");
		ghostMasterScript = GhostMasterObject.GetComponent<GhostMaster>();
		PrinterScript = PrinterObject.GetComponent<Printer>();
		PacmanMoveScript = pacmanObject.GetComponent<pacmanMove>();
		teleportOneWayScript = teleportOneWayObject.GetComponent<TeleportOneWay>();

		FindGoldAmount();
		maxGold = goldArray.Length;
		InvokeRepeating("SpawnDiamonds", 30, 30);
		InvokeRepeating("MapTimer", 0, 1);
		StartPrint();
	
	}


	public void pacmanHitSomething(GameObject trigger){
//-----------------------Hit Gold------------------------------
		if(trigger.gameObject.tag == "Gold"){
			trigger.gameObject.SetActive(false);
			audioPlayerScript.EatGoldMethod();
			AddGoldMethod(1);
//-----------------------Hit Courage--------------------------
		}else if(trigger.gameObject.tag == "Courage"){
			courageCounter = 10;
			trigger.gameObject.transform.parent.gameObject.SetActive(false);
			audioPlayerScript.EatCourageMethod();
			int courageBonus = 10;
			if(courageActive == false){
				courageActive = true;
				InvokeRepeating("CourageActiveTimer", 0, 1);
			}else{
				courageCounter = courageCounter + courageBonus;
			}
			ghostMasterScript.EscapeGhost();//activate escape i GhostMaster

//------------------------Hit Diamonds-------------------------
		}else if(trigger.gameObject.tag == "Diamond"){
			AddScoreMethod(10);
			audioPlayerScript.EatDiamondMethod();
			trigger.gameObject.transform.parent.gameObject.SetActive(false);
			//add coins for buying extra powertime/hp/speed

//------------------------Hit Ghost Hunt-----------------------
		}else if(trigger.gameObject.tag == "GhostHunt"){
			PacmanLoseLife(trigger.gameObject.transform.parent.gameObject.name);
			//InvokeRepeating("RespawnTimer",0, 1);

//------------------------Hit Ghost Flee------------------------
		}else if(trigger.gameObject.tag == "GhostFlee"){
			ghostMasterScript.DeadGhost(trigger); // activate dead ghost send trigger ghost
			audioPlayerScript.GhostDiedMethod();
			GhostKillScoreMethod();

//------------------------Explosives--------------------------
		}else if(trigger.gameObject.tag == "Explosives"){
			PacmanLoseLife(trigger.gameObject.name);
			//PrinterScript.PrintInfoText("You been killed by " + trigger.gameObject.name);
		}else if (trigger.gameObject.tag == "Teleport"){
			teleportOneWayScript.TeleportPacman(trigger);
//-----------------------Poison----------------------------
		}else if (trigger.gameObject.tag == "Poison"){
			trigger.gameObject.SetActive(false);
			PoisonCounter(trigger.gameObject.name);
			audioPlayerScript.PacmanHitPoison();
//----------------------PowerCharge-------------------------
		}else if( trigger.gameObject.tag == "PowerCharge"){
			abilityMasterScript.IncreasePoweredAbility(1);
			trigger.gameObject.transform.parent.gameObject.SetActive(false);
			audioPlayerScript.EatPowerChargeMethod();
//-----------------------DropZone--------------------------------
		}else if(trigger.gameObject.tag == "DropZone"){
			PacmanMoveScript.ActivatePacmanFalling();
		}
	}
//------------------------Courage Active Timer-----------------
	void CourageActiveTimer(){
		if(courageCounter < 1){		
			courageActive = false;
			ghostKillScore = 5;
			courageCounter = 0;
			CancelInvoke("CourageActiveTimer");
			ghostMasterScript.HuntGhost();//activates hunt ghost in ghost master
		}else{
			courageCounter = courageCounter -1;
			//change light when times neraly up
			//ghostcontroll.chage material.
		}
		PrinterScript.PrintCourageTime(courageCounter);
	}
//-------------------------Find Amount of Gold------------------
	void FindGoldAmount(){
		goldArray = GameObject.FindGameObjectsWithTag("Gold");
	}
//--------------------------Spawn Diamonds-------------------
	void SpawnDiamonds(){
		//text a diamond has spawned!
		int randomDiamond = Random.Range(0, diamondsArray.Length);
		diamondsArray[randomDiamond].SetActive(true);
		StartCoroutine(deactivateDiamond(randomDiamond));
	}
	IEnumerator deactivateDiamond(int theDiamond){
		yield return new WaitForSeconds(10);
		diamondsArray[theDiamond].SetActive (false);
	}
//---------------------------Add Gold-----------------------------
	void AddGoldMethod(int amount){
		gold = gold + amount;
		AddScoreMethod(amount);
		FindGoldAmount();
		int goldLeft = goldArray.Length;
		PrinterScript.PrintGoldLeft(goldLeft);//send goldLeft to printer for print

		if(gold == maxGold){
			VictoryMethod();
		}
	}
//---------------------------Add Score---------------------------
	void AddScoreMethod(int amount){
		score = score + amount;
		lifeNeedScore = lifeNeedScore + amount;
		PacmanGainLife();
		PrinterScript.PrintScore(score);//sends score to printer for print
	}
//-------------------------Pacman Lose Life------------------
	void PacmanLoseLife(string killer){
		if(pacmanLives <= 1){
			GameOverMethod();
		}else{
			meteorMasterScript.ResetMeteors();
			PacmanMoveScript.gameObject.SetActive(false);
			PacmanMoveScript.TeleportToSpawnPoint();
			ResetPoisonCount();
			abilityMasterScript.PacmanLoseLife();
			ghostMasterScript.ResetGhost();//teleports ghost to nest
			PrinterScript.PrintInfoText("You been killed by " + killer);
			InvokeRepeating("RespawnTimer",0, 1);
		}
		PacmanMoveScript.DeactivatePacmanFalling();
		audioPlayerScript.PacmanDiedMethod();
		pacmanLives = pacmanLives -1;
		PrinterScript.PrintPacmanLives(pacmanLives);//send pacmanLives to Printer for print
	}
//----------------Pacman Gain Life------------------------
	void PacmanGainLife(){
		int gainLifeAt = 100;
		if(lifeNeedScore >= gainLifeAt){
			lifeNeedScore = lifeNeedScore - gainLifeAt;
			PacmanAddLife(1);
			PrinterScript.PrintInfoText("You collected 100 score point. you gain 1 bonus life");
		}
	}
//--------------------Pacman add Life----------------------
	void PacmanAddLife(int amount){
		pacmanLives = pacmanLives + amount;
		PrinterScript.PrintPacmanLives(pacmanLives);//send pacmanLives to Printer for print
	}
//----------------Respawn Timer----------------------------
	void RespawnTimer(){

		if(respawnTime <= 1){
			PacmanMoveScript.gameObject.SetActive(true);
			audioPlayerScript.PacmanRespawnMethod();
			ghostMasterScript.HuntGhost();
			PrinterScript.PrintImportantInfoNothing();//Print Nothing in Info Text
			CancelInvoke("RespawnTimer");
			respawnTime = 5;
		}else{
			respawnTime = respawnTime -1;
			PrinterScript.PrintImportantInfoRespawn(respawnTime);//send respawnTime to Printer for print

		}
	}
//-------------Player Lost--------------------
	void GameOverMethod(){
		string gameOver = "GAME OVER";
		PrinterScript.PrintImportantInfo(gameOver);//send text to Printer for print
		audioPlayerScript.GameOverMethod();
		int scoreTime = startMapTime -mapTime;
		resultsScript.TurnOnGameOverPanel(score, scoreTime);
	}
//-----------Player Won-----------------------
	void VictoryMethod(){
		string victory = "VICTORY";
		PrinterScript.PrintImportantInfo(victory);//send text to Printer for print
		AddScoreMethod(50);
		AddScoreMethod(mapTime);
		int scoreTime = startMapTime -mapTime;
		audioPlayerScript.VictoryMethod();
		resultsScript.TurnOnVictoryPanel(mapTime, score, scoreTime);

	}
//--------Bonusgold for Killing Ghost-------------------
	void GhostKillScoreMethod(){
		ghostKillScore = ghostKillScore * 2;
		AddScoreMethod(ghostKillScore);
	}
//------------Map Total Timer------------------
	void MapTimer(){
		if(mapTime < 1){
			GameOverMethod();
		}else{
			mapTime = mapTime -1;
			PrinterScript.PrintMapTime(mapTime); // send mapTime to printer to print
		}
	}
//-------------Printing start Numbers----------------
	void StartPrint(){
		PrinterScript.PrintScore(score);
		PrinterScript.PrintGoldLeft(maxGold);
		PrinterScript.PrintPacmanLives(pacmanLives);
		PrinterScript.PrintCourageTime(courageCounter);
		//PrinterScript.PrintMapTime();
	}
//---------------Poison Counter---------------
	void PoisonCounter(string killer){
		if(poisonCount == 1){
			PacmanLoseLife(killer);
			poisonCount = 4;	
		}
		else{
			poisonCount = poisonCount -1;
			PrinterScript.PrintInfoText("Aaoh! Arrows Hurts");
		}
	}
	void ResetPoisonCount(){
		poisonCount = 4;
	}


//-----------------Powered Ability Hit Something-----------------------------
	public void PoweredAbilityHitSomething(GameObject trigger){
		if(trigger.gameObject.tag == "GhostFlee" || trigger.gameObject.tag == "GhostHunt"){
			audioPlayerScript.GhostDiedMethod();
			ghostMasterScript.DeadGhost(trigger);
		}
	}
		
}
