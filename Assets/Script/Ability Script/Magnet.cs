using UnityEngine;
using System.Collections;

public class Magnet : MonoBehaviour {

	public GameObject pacmanObject;
	public GameObject printerObject;
	public GameObject abilityMasterObject;
	public GameObject audioPlayerObject;

	AbilityMaster abilityMasterScript;
	Printer printerScript;
	AudioPlayer audioPlayerScript;


	void Start () {
		abilityMasterScript = abilityMasterObject.GetComponent<AbilityMaster>();
		printerScript = printerObject.GetComponent<Printer>();
		audioPlayerScript = audioPlayerObject.GetComponent<AudioPlayer>();
	}
	void OnTriggerEnter(Collider trigger){
		if(trigger.gameObject.tag == "Gold" || trigger.gameObject.tag == "Diamond"){
			trigger.gameObject.transform.parent.gameObject.GetComponent<capsuleRotation>().FlyToPacmanMethod(pacmanObject.gameObject);

		}else if(trigger.gameObject.tag == "GhostHunt"){
			if(abilityMasterScript.ReturnPoweredAbilityReady() == true){
				trigger.gameObject.transform.parent.gameObject.GetComponent<GhostDady>().SlowDown();
			}else{
				trigger.gameObject.transform.parent.gameObject.GetComponent<GhostDady>().SpeedUp();
				audioPlayerScript.MagnetHitGhostMethod();
				printerScript.PrintInfoText("Your Magnet Hit Ghost. They are now Faster!");
			}

		}else if(trigger.gameObject.tag == "Poison" && abilityMasterScript.ReturnPoweredAbilityReady() == true || trigger.gameObject.tag == "Explosive" && abilityMasterScript.ReturnPoweredAbilityReady() == true){
			audioPlayerScript.MagnetHitExplosiveMethod();
			trigger.gameObject.SetActive(false);
		}
	}


	void FixedUpdate () {


	}

}
