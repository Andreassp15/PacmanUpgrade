using UnityEngine;
using System.Collections;

public class UseShield : MonoBehaviour {

	public Transform theShield;
	public GameObject frontPoint;
	public GameObject printerObject;
	AbilityShield abibiltyShieldScript;
	Printer printerScript;
	int coolDown = 10;
	bool coolDownOK = true;
	bool canTeleport = false;
	bool ownShield = true;

	void Start () {
		printerScript = printerObject.GetComponent<Printer>();
		printerScript.AbilityCoolDownText(coolDown);
		abibiltyShieldScript = theShield.GetComponent<AbilityShield>();
	}
	

	void Update () {

	if(Input.GetKeyDown(KeyCode.Space) && coolDownOK == true && canTeleport == false && ownShield == true){
			ownShield = false;
			canTeleport = true;
			theShield.transform.position = frontPoint.transform.position;
			theShield.gameObject.SetActive(true);
			abibiltyShieldScript.StartDirection();
			coolDownOK = false;
			Timer();
		}else if(Input.GetKeyDown(KeyCode.Space) && canTeleport == true && ownShield == false){
			transform.position = theShield.gameObject.transform.position;
			canTeleport = false;
		}
	
	}
	void Timer(){
		InvokeRepeating("ShieldCounter",0 , 1);
	}
	void ShieldCounter(){
		if(coolDown < 1){
			canTeleport = false;
			CancelInvoke("ShieldCounter");
			coolDownOK = true;
			coolDown = 10;
		}else{
			coolDown = coolDown -1;
			printerScript.AbilityCoolDownText(coolDown);
		}
	}
	public void ShieldInWall(){
		canTeleport = false;
	}
	public void OwnShield(){
		ownShield = true;
	}
}
