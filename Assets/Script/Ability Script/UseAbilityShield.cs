using UnityEngine;
using System.Collections;
//-------------------Programmerare Ludvig Emtås SP15-------------
//********************************************************************************************
//Scriptet används av AbilityMaster som tilldelar objectet till ShildoPacman
//pacman kan kasta sin sköld och sedan teleportera till den genom att trycka på samma knapp
//********************************************************************************************

public class UseAbilityShield : MonoBehaviour {

	public GameObject abilityMasterObject;
	public GameObject throwShieldObject; 
	public GameObject handShiledObject;
	public GameObject pacmanMoveObject;
	public GameObject frontPoint;
	public GameObject audioPlayerObject;
	public GameObject printerObject;

	AudioPlayer audioPlayerScript;
	AbilityMaster abilityMasterScript;
	ThrowShiled throwShieldScript;
	pacmanMove pacmanMoveScript;
	Printer printerScript;

	float dX;
	float dZ;
	Vector3 direction;

	bool abilityReady;
	bool ownShield = true;
	bool canTeleport = false;

	void Start () {
		printerScript = printerObject.GetComponent<Printer>();
		audioPlayerScript = audioPlayerObject.GetComponent<AudioPlayer>();
		pacmanMoveScript = pacmanMoveObject.GetComponent<pacmanMove>();
		throwShieldScript = throwShieldObject.GetComponent<ThrowShiled>();
		abilityMasterScript = abilityMasterObject.GetComponent<AbilityMaster>();
	
	}
	
//--------------Throw Shield / Teleport to Shield--------------------------------------
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space) && abilityMasterScript.ReturnAbilityReady() == true && ownShield == true && canTeleport == false){
			ownShield = false; 
			canTeleport = true;
			throwShieldObject.SetActive(true);
			abilityMasterScript.FindObjectVisual(throwShieldObject.gameObject);
			handShiledObject.SetActive(false);
			throwShieldObject.transform.position = frontPoint.transform.position;
			abilityMasterScript.StartAbility();
			GetDirectionForShield();
			throwShieldScript.StartDirections(direction);
			audioPlayerScript.ShieldTossMethod();
		}else if(Input.GetKeyDown(KeyCode.Space) && ownShield == false && canTeleport == true){
			pacmanMoveScript.DontMoveMethod();
			pacmanMoveObject.transform.position = throwShieldObject.transform.position;
			canTeleport = true;
			audioPlayerScript.ShieldTeleportMethod();
		}else if(Input.GetKeyDown(KeyCode.Space) && abilityMasterScript.ReturnAbilityReady() == false && canTeleport == false){
			printerScript.PrintInfoText("Your ability is on cooldown");
			audioPlayerScript.AbilityNotReadyMethod();
		}
	
	}
//---------------Shield Stuck in Wall-----------------------
	public void ShieldInWall(){
		canTeleport = false;
	}
//---------------Shield Returned to Pacman-------------------
	public void ShieldReturned(){
		ownShield = true;
		throwShieldObject.SetActive(false);
		handShiledObject.SetActive(true);
		canTeleport = false;
		audioPlayerScript.ShieldReturnedMethod();
	}
//----------Sends Pacmans current direction to shield----------
	void GetDirectionForShield(){
		dX = pacmanMoveScript.ReturnDirectionX();
		dZ = pacmanMoveScript.ReturnDirectionZ();
		if(dX == 0 && dZ == 1){
			direction = new Vector3(0, 0, 1.2f);
		}else if(dX == 0 && dZ == -1){
			direction = new Vector3(0, 0, -1.2f);
		}else if(dX == 1 && dZ == 0){
			direction = new Vector3(1.2f, 0, 0);
		}else if(dX == -1 && dZ == 0){
			direction = new Vector3(-1.2f, 0, 0);
		}
	}
	public void PacmanDied(){
		throwShieldObject.gameObject.transform.position = pacmanMoveObject.transform.position;
	}
}
