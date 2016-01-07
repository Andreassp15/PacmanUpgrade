using UnityEngine;
using System.Collections;
//------------------Programmerare Sp15 Ludvig Emtås-------------------
//*****************************************************************'*
//Scriptet används av AbilityMaster som tilldelar objectet till DecoyoPacman
//Lägger ut ett Decoy som spökerna jagar istället för pacaman
//***********************************************************************

public class UseAbilityDecoy : MonoBehaviour {

	public GameObject abilityMasterObject;
	public GameObject pointGhostHuntingObject;
	public GameObject decoyObject;
	public GameObject pacmanObject;
	public GameObject audioPlayerObject;

	AudioPlayer audioPlayerScript;
	AbilityMaster abilityMasterScript;
	PointGhostsHunting pointGhostHuntingScript;
	pacmanMove pacmanScript;

	bool alreadyActive = false;

	void Start () {
		audioPlayerScript = audioPlayerObject.GetComponent<AudioPlayer>();
		abilityMasterScript = abilityMasterObject.GetComponent<AbilityMaster>();
		pointGhostHuntingScript = pointGhostHuntingObject.GetComponent<PointGhostsHunting>();
		pacmanScript = pacmanObject.GetComponent<pacmanMove>();

	}
	

	void Update () {
		if(Input.GetKeyDown(KeyCode.Space) && abilityMasterScript.ReturnAbilityReady() == true){
			audioPlayerScript.DecoyUsedMethod();
			decoyObject.SetActive(true);
			StartCoroutine(DecoyAliveTimer());
			abilityMasterScript.StartAbility();
			pointGhostHuntingScript.DecoyPositionMethod();
			decoyObject.transform.position = pacmanObject.gameObject.transform.position;
			GetDirectionForVisual();
			pointGhostHuntingObject.transform.position = decoyObject.transform.position;
			abilityMasterScript.FindObjectVisual(decoyObject.gameObject);
		}else if(Input.GetKeyDown(KeyCode.Space) && abilityMasterScript.ReturnAbilityReady() == false){
			audioPlayerScript.AbilityNotReadyMethod();
		}
	
	}
	IEnumerator DecoyAliveTimer(){
		yield return new WaitForSeconds(6f);
		if(alreadyActive != true){
			abilityMasterScript.StartAbilityCooldown();
			Debug.Log("1");
			decoyObject.SetActive(false);
			pointGhostHuntingScript.PacmanPositionMethod();
			abilityMasterScript.PoweredAbilityEnd();
		}else{
			SetAlreadyActiveFalse();
		}

	}
	public void SetAlreadyActiveTrue(){
		alreadyActive = true;
	}
	public void SetAlreadyActiveFalse(){
		alreadyActive = false;
	}
	public void decoyGone(){
		abilityMasterScript.StartAbilityCooldown();
		Debug.Log("2");
		decoyObject.SetActive(false);
		pointGhostHuntingScript.PacmanPositionMethod();
		abilityMasterScript.PoweredAbilityEnd();
	}
	void GetDirectionForVisual(){
		float dX = pacmanScript.ReturnDirectionX();
		float dZ = pacmanScript.ReturnDirectionZ();
		VisualPacmanMethod(dX, dZ);
	}
	void VisualPacmanMethod(float x, float z){
		//roterar pacmans visuella gamobject i spelerens valda riktning
		if(x == 0 && z == 1){
			decoyObject.transform.localEulerAngles = new Vector3(0, 0, 0);
		}else if(x == 0 && z == -1){
			decoyObject.transform.localEulerAngles = new Vector3(0, 180, 0);
		}else if(x == -1 && z == 0){
			decoyObject.transform.localEulerAngles = new Vector3(0, 270, 0);
		}else if(x == 1 && z == 0){
			decoyObject.transform.localEulerAngles = new Vector3(0, 90, 0);
		}
	}
}
