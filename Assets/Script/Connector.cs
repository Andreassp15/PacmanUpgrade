using UnityEngine;
using System.Collections;
//**************************************************************************
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
	int courageCounter = 15;
	int pacmanLives = 3;
	int respawnTime = 5;
	int ghostKillScore = 5;
	int mapTime = 180;

	bool courageActive = false;

	public GameObject PrinterObject;
	Printer PrinterScript;
	/*void Awake(){
		pacmanNumber = heroPickScript.ReturnPacmanNumber();
		if(pacmanNumber == 1){
			pacmanKaiObject.SetActive(true);
		}else if(pacmanNumber == 2){
			pacmanJonObject.SetActive(true);
		}else if(pacmanNumber == 3){
			pacmanNicklasObject.SetActive(true);
		}
	}*/

	void Start () {
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
			trigger.gameObject.transform.parent.gameObject.SetActive(false);
			audioPlayerScript.EatCourageMethod();
			int courageBonus = 15;
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
			PacmanLoseLife();
			//InvokeRepeating("RespawnTimer",0, 1);

//------------------------Hit Ghost Flee------------------------
		}else if(trigger.gameObject.tag == "GhostFlee"){
			ghostMasterScript.DeadGhost(trigger); // activate dead ghost send trigger ghost
			GhostKillScoreMethod();

//------------------------Explosives--------------------------
		}else if(trigger.gameObject.tag == "Explosives"){
			PacmanLoseLife();
			Debug.Log("hit by Explosive");
		}else if (trigger.gameObject.tag == "Teleport"){
			//teleportScript.teleportPacman(trigger, pacmanObject);
			//teleporterScript.TeleportPacman(trigger);
			teleportOneWayScript.TeleportPacman(trigger);
//-----------------------Poison----------------------------
		}else if (trigger.gameObject.tag == "Poison"){
			trigger.gameObject.SetActive(false);
			PoisonCounter();
			Debug.Log("hit by Poison");
		}else if( trigger.gameObject.tag == "PowerCharge"){
			abilityMasterScript.IncreasePoweredAbility(1);
			trigger.gameObject.transform.parent.gameObject.SetActive(false);
			audioPlayerScript.EatPowerChargeMethod();
		}
	}
//------------------------Courage Active Timer-----------------
	void CourageActiveTimer(){
		if(courageCounter < 1){		
			courageActive = false;
			ghostKillScore = 5;
			courageCounter = 15;
			CancelInvoke("CourageActiveTimer");
			PrinterScript.PrintCourageNothing();
			ghostMasterScript.HuntGhost();//activates hunt ghost in ghost master
		}else{
			courageCounter = courageCounter -1;
			PrinterScript.PrintCourageTime(courageCounter); //send courageCounter to Printer for print
			//change light when times neraly up
			//ghostcontroll.chage material.
		}
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
	void PacmanLoseLife(){
		if(pacmanLives <= 1){
			GameOverMethod();
		}else{
			meteorMasterScript.ResetMeteors();
			PacmanMoveScript.gameObject.SetActive(false);
			PacmanMoveScript.TeleportToSpawnPoint();
			ResetPoisonCount();
			ghostMasterScript.ResetGhost();//teleports ghost to nest
			InvokeRepeating("RespawnTimer",0, 1);
		}
		pacmanLives = pacmanLives -1;
		PrinterScript.PrintPacmanLives(pacmanLives);//send pacmanLives to Printer for print
	}
//----------------Pacman Gain Life------------------------
	void PacmanGainLife(){
		int gainLifeAt = 200;
		if(lifeNeedScore >= gainLifeAt){
			lifeNeedScore = lifeNeedScore - gainLifeAt;
			PacmanAddLife(1);
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
			ghostMasterScript.HuntGhost();
			PrinterScript.PrintInfoNotingText();//Print Nothing in Info Text
			CancelInvoke("RespawnTimer");
			respawnTime = 5;
		}else{
			respawnTime = respawnTime -1;
			PrinterScript.PrintInfoRespawnText(respawnTime);//send respawnTime to Printer for print
		}
	}
//-------------Player Lost--------------------
	void GameOverMethod(){
		string gameOver = "GAME OVER";
		PrinterScript.PrintInfoText(gameOver);//send text to Printer for print
		//pause game
		//in game menu
		//highscore?
		//Application.LoadLevel(Menu);   
	}
//-----------Player Won-----------------------
	void VictoryMethod(){
		string victory = "VICTORY";
		PrinterScript.PrintInfoText(victory);//send text to Printer for print
		AddScoreMethod(50);
		AddScoreMethod(mapTime);
		//highscore
		//Application.LoadLevel(next Level);
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
		PrinterScript.PrintCourageNothing();
		//PrinterScript.PrintMapTime();
	}
//---------------Poison Counter---------------
	void PoisonCounter(){
		if(poisonCount == 1){
			PacmanLoseLife();
			poisonCount = 4;	
		}
		else{
			poisonCount = poisonCount -1;
			PrinterScript.PrintInfoArrows("You been poisoned, take ", poisonCount, " more arrows and you are done");
		}
	}
	void ResetPoisonCount(){
		poisonCount = 4;
	}


//-----------------Powered Ability Hit Something-----------------------------
	public void PoweredAbilityHitSomething(GameObject trigger){
		if(trigger.gameObject.tag == "GhostFlee" || trigger.gameObject.tag == "GhostHunt"){
			ghostMasterScript.DeadGhost(trigger);
		}
	}
		
}
