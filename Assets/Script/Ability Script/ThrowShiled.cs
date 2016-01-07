using UnityEngine;
using System.Collections;

public class ThrowShiled : MonoBehaviour {

	public GameObject abilityMasterObject;
	public GameObject useAbilityShieldObject;
	public GameObject rotateShiledObject;
	public GameObject inWallShiledObject;
	public GameObject connectorObject;

	Connector connectorObjectScript;
	AbilityMaster abilityMasterScript;
	UseAbilityShield useAbilityShieldScript;

	Vector3 direction;
	float moveSpeed = 0.1f;
	float xyzInWall = 0.5f;
	bool willReturn;
	bool poweredAbility = false;


	void Start () {
		connectorObjectScript = connectorObject.GetComponent<Connector>();
		useAbilityShieldScript = useAbilityShieldObject.GetComponent<UseAbilityShield>();
		abilityMasterScript = abilityMasterObject.GetComponent<AbilityMaster>();
	
	}
	public void StartDirections(Vector3 theDirection){
		rotateShiledObject.SetActive(true);
		direction = theDirection;
		willReturn = true;
		StartCoroutine(ReturnToPacman());
	}
	IEnumerator ReturnToPacman(){
		yield return new WaitForSeconds(2.5f);
		if(willReturn == true){
			direction = -direction;
		}
	}
	void OnTriggerEnter(Collider trigger){
		if(trigger.gameObject.tag == "GhostHunt" || trigger.gameObject.tag == "GhostFlee"){
			Debug.Log("hit ghost");
			if(abilityMasterScript.ReturnPoweredAbilityReady() == true){
				Debug.Log("ghostslayed");
				connectorObjectScript.PoweredAbilityHitSomething(trigger.gameObject);
				//Connector(abilityhitGhost)....
			}
		}else if(trigger.gameObject.tag == "Wall"){
			rotateShiledObject.SetActive(false);
			inWallShiledObject.SetActive(true);
			useAbilityShieldScript.ShieldInWall();
			PushShieldIntoWall();
			direction = new Vector3(0, 0, 0);
			willReturn = false;

		}else if(trigger.gameObject.tag == "Pacman"){
			abilityMasterScript.StartAbilityCooldown();
			inWallShiledObject.SetActive(false);
			useAbilityShieldScript.ShieldReturned();
			if(abilityMasterScript.ReturnPoweredAbilityReady() == true){
				abilityMasterScript.PoweredAbilityEnd();
			}
		}
	}
	void PushShieldIntoWall(){
		if(direction == new Vector3(0, 0, 1.2f)){
			inWallShiledObject.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + xyzInWall);
		}else if(direction == new Vector3(0, 0, -1.2f)){
			inWallShiledObject.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - xyzInWall);
		}else if(direction == new Vector3(1.2f, 0, 0)){
			inWallShiledObject.gameObject.transform.position = new Vector3(transform.position.x + xyzInWall, transform.position.y, transform.position.z);
		}else if(direction == new Vector3(-1.2f, 0, 0)){
			inWallShiledObject.gameObject.transform.position = new Vector3(transform.position.x - xyzInWall, transform.position.y, transform.position.z);
		}
	}
	

	void FixedUpdate () {
		transform.Translate(direction * moveSpeed);
	}

}
