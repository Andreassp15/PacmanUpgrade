using UnityEngine;
using System.Collections;
//------------------------Programmerare Ludvig Emtås SP15----------
//******************************************************************
//kontrollerar vilken pacman som är aktiv och activerar där efter rätt ability
//håller koll på ability cooldown och hur många PowerCharges spelaren har
//placerar även ut de lila visuella power objecten till abilies.
//************************************************************************
public class AbilityMaster : MonoBehaviour {

	public GameObject connectorObject;
	public GameObject poweredVisualPacman;
	public GameObject poweredVisualAbility;
	public GameObject useShieldAbilityObject;
	public GameObject printeObject;
	public GameObject useMagnetAbilityObject;
	public GameObject useDecoyAbilityObject;
	public GameObject audioPlayerObject;

	Printer printerScript;
//	Connector connectorScript;
	AudioPlayer audioPlayerScript;

	GameObject abilityObject;
	GameObject pacmanObject;

	int abilityCooldown;
	int poweredAbility = 0; 

	bool abilityReady = true;
	bool poweredAbilityReady = false;
	bool poweredAbilityUsed = false;


	void Start () {
		
		audioPlayerScript = audioPlayerObject.GetComponent<AudioPlayer>();
		printerScript = printeObject.GetComponent<Printer>();
		//connectorScript = connectorObject.GetComponent<Connector>();
		pacmanObject = GameObject.FindGameObjectWithTag("FindPacmanObject");
		printerScript.PrintPowerCharges(poweredAbility);
		printerScript.AbilityCoolDownText(abilityCooldown);

		ActivateAbility();
	
	}
//----------------------Activates Visual Power Objects--------------------------
	void FixedUpdate(){
		poweredVisualPacman.transform.position = pacmanObject.gameObject.transform.position;
		if(poweredAbilityUsed == true){
			poweredVisualAbility.SetActive(true);
			PoweredVisualFollow();
		}
	}
//----------------Activate Pacmans Ability-----------------------------
	void ActivateAbility(){
		if(pacmanObject.gameObject.name == "PacmanKai"){
			useShieldAbilityObject.SetActive(true);
			
		}else if(pacmanObject.gameObject.name == "PacmanJon"){
			useMagnetAbilityObject.SetActive(true);
			
		}else if(pacmanObject.gameObject.name == "PacmanNicklas"){
			useDecoyAbilityObject.SetActive(true);
		}
	}
//--------------Visual Power Object Follows the ability Object------
	void PoweredVisualFollow(){
		poweredVisualAbility.transform.position = abilityObject.transform.position;
	}
//----------------Finds the current Ability Object-----------------------------
	public void FindObjectVisual(GameObject theObject){
		abilityObject = theObject;
		if(poweredAbilityReady == true){
			poweredAbilityUsed = true;
		}

	}
//---------------Ability has been used-----------------------
	public void StartAbility(){
		abilityReady = false;
	}
//--------------Starts the Abilities Cooldown--------------------
	public void StartAbilityCooldown(){
		abilityCooldown = 10;
		InvokeRepeating("CooldownCounter", 0, 1);
	}
//---------------Cooldown Counter------------------------
	void CooldownCounter(){
		if(abilityCooldown < 1){
			audioPlayerScript.AbilityReadyMethod();
			abilityCooldown = 10;
			CancelInvoke("CooldownCounter");
			abilityReady = true;
			Debug.Log(abilityReady);
		}else{
			abilityCooldown = abilityCooldown -1;
			printerScript.AbilityCoolDownText(abilityCooldown);

		}
	}
//------PowerCharges is increased from Connector script-----------------
	public void IncreasePoweredAbility(int i){
		poweredAbility = poweredAbility + i;
		printerScript.PrintPowerCharges(poweredAbility);
	}
//------PowerCharges has been used------------------------------
	public void DecreasePoweredAbility(int i){
		if(poweredAbility >= 1){
			poweredAbility = poweredAbility -i;
			printerScript.PrintPowerCharges(poweredAbility);
		}
	}
//-------Press E to activate PowerCharges---------------------------
	void Update () {
		if(Input.GetKeyDown(KeyCode.E) && poweredAbility >= 1 && abilityReady == true){
			audioPlayerScript.PacmanActivatePowerMethod();
			DecreasePoweredAbility(1);
			poweredAbilityReady = true;
			ActivatePowerVisual();
		}else if (Input.GetKeyDown(KeyCode.E) && poweredAbility >= 1 && abilityReady == false){
			printerScript.PrintInfoText("Your ability must be ready");
			audioPlayerScript.AbilityNotReadyMethod();
		}else if(Input.GetKeyDown(KeyCode.E) && poweredAbility == 0){
			printerScript.PrintInfoText("You must aquire a Power Charge to power your ability");
			audioPlayerScript.AbilityNotReadyMethod();
		}
	}
//---------Activates PowerCharge Visual---------------------------
	void ActivatePowerVisual(){
		poweredVisualPacman.SetActive(true);
		//poweredVisualAbility.SetActive(true);
	}
//-------Deactivates Power Charge visual----------------------
	void DeactivatePoweredVisual(){
		poweredVisualPacman.SetActive(false);
		poweredVisualAbility.SetActive(false);
	}
//--------------Return Ability Ready---------------------------
	public bool ReturnAbilityReady(){
		return abilityReady;
	}
//--------------Return PoweredAbility ready------------------
	public bool ReturnPoweredAbilityReady(){
		return poweredAbilityReady;
	}
//--------------Powered Ability ends--------------------------
	public void PoweredAbilityEnd(){
		poweredAbilityReady = false;
		poweredAbilityUsed = false;
		DeactivatePoweredVisual();
	}
	public void TutorialModeOne(){
		
	}
//-------Pacman Died---------------------------
	public void PacmanLoseLife(){
		if(pacmanObject.gameObject.name == "PacmanKai"){
			useShieldAbilityObject.gameObject.GetComponent<UseAbilityShield>().PacmanDied();
		}
	}
}
