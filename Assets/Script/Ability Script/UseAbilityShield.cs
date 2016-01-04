using UnityEngine;
using System.Collections;

public class UseAbilityShield : MonoBehaviour {

	public GameObject abilityMasterObject;
	public GameObject throwShieldObject; 
	public GameObject handShiledObject;
	public GameObject pacmanMoveObject;
	public GameObject frontPoint;

	AbilityMaster abilityMasterScript;
	ThrowShiled throwShieldScript;
	pacmanMove pacmanMoveScript;

	float dX;
	float dZ;
	Vector3 direction;


	bool abilityReady;
	bool ownShield = true;
	bool canTeleport = false;

	void Start () {
		pacmanMoveScript = pacmanMoveObject.GetComponent<pacmanMove>();
		throwShieldScript = throwShieldObject.GetComponent<ThrowShiled>();
		abilityMasterScript = abilityMasterObject.GetComponent<AbilityMaster>();
	
	}
	

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
		}else if(Input.GetKeyDown(KeyCode.Space) && ownShield == false && canTeleport == true){
			pacmanMoveScript.DontMoveMethod();
			pacmanMoveObject.transform.position = throwShieldObject.transform.position;
			canTeleport = true;
		}
	
	}
	public void ShieldInWall(){
		canTeleport = false;
	}
	public void ShieldReturned(){
		ownShield = true;
		throwShieldObject.SetActive(false);
		handShiledObject.SetActive(true);
		canTeleport = false;
	}
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
}
