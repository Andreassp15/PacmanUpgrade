﻿using UnityEngine;
using System.Collections;

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
	Connector connectorScript;
	AudioPlayer audioPlayerScript;

	GameObject abilityObject;
	GameObject pacmanObject;

	int abilityCooldown = 10;
	int poweredAbility = 0; 

	bool abilityReady = true;
	bool poweredAbilityReady = false;
	bool poweredAbilityUsed = false;






	void Start () {
		audioPlayerScript = audioPlayerObject.GetComponent<AudioPlayer>();
		printerScript = printeObject.GetComponent<Printer>();
		connectorScript = connectorObject.GetComponent<Connector>();
		pacmanObject = GameObject.FindGameObjectWithTag("FindPacmanObject");

		ActivateAbility();
	
	}
	void FixedUpdate(){
		poweredVisualPacman.transform.position = pacmanObject.gameObject.transform.position;
		if(poweredAbilityUsed == true){
			poweredVisualAbility.SetActive(true);
			PoweredVisualFollow();
		}
	}
	void ActivateAbility(){


		if(pacmanObject.gameObject.name == "PacmanKai"){
			useShieldAbilityObject.SetActive(true);
			
		}else if(pacmanObject.gameObject.name == "PacmanJon"){
			useMagnetAbilityObject.SetActive(true);
			
		}else if(pacmanObject.gameObject.name == "PacmanNicklas"){
			useDecoyAbilityObject.SetActive(true);
		}
	}
	void PoweredVisualFollow(){
		poweredVisualAbility.transform.position = abilityObject.transform.position;
	}
	public void FindObjectVisual(GameObject theObject){
		abilityObject = theObject;
		if(poweredAbilityReady == true){
			poweredAbilityUsed = true;
		}

	}
	public void StartAbility(){
		abilityReady = false;
	}
	public void StartAbilityCooldown(){
		InvokeRepeating("CooldownCounter", 0, 1);
	}
	void CooldownCounter(){
		if(abilityCooldown < 1){
			abilityCooldown = 10;
			CancelInvoke("CooldownCounter");
			abilityReady = true;
			Debug.Log(abilityReady);
		}else{
			abilityCooldown = abilityCooldown -1;
			printerScript.AbilityCoolDownText(abilityCooldown);

		}
	}

	public void IncreasePoweredAbility(int i){
		poweredAbility = poweredAbility + i;
	}
	public void DecreasePoweredAbility(int i){
		if(poweredAbility >= 1){
			poweredAbility = poweredAbility -i;
		}
	}
	void Update () {
		if(Input.GetKeyDown(KeyCode.E) && poweredAbility >= 1){
			audioPlayerScript.PacmanActivatePowerMethod();
			DecreasePoweredAbility(1);
			poweredAbilityReady = true;
			ActivatePowerVisual();

		}
	}
	void ActivatePowerVisual(){
		poweredVisualPacman.SetActive(true);
		//poweredVisualAbility.SetActive(true);
	}
	void DeactivatePoweredVisual(){
		poweredVisualPacman.SetActive(false);
		poweredVisualAbility.SetActive(false);
	}
	public bool ReturnAbilityReady(){
		return abilityReady;
	}
	public bool ReturnPoweredAbilityReady(){
		return poweredAbilityReady;
	}
	public void PoweredAbilityEnd(){
		poweredAbilityReady = false;
		poweredAbilityUsed = false;
		DeactivatePoweredVisual();
	}
}
