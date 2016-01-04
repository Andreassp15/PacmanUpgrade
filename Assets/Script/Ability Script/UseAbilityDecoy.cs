using UnityEngine;
using System.Collections;

public class UseAbilityDecoy : MonoBehaviour {

	public GameObject abilityMasterObject;
	public GameObject pointGhostHuntingObject;
	public GameObject decoyObject;
	public GameObject pacmanObject;

	AbilityMaster abilityMasterScript;
	PointGhostsHunting pointGhostHuntingScript;
	pacmanMove pacmanScript;

	void Start () {
		abilityMasterScript = abilityMasterObject.GetComponent<AbilityMaster>();
		pointGhostHuntingScript = pointGhostHuntingObject.GetComponent<PointGhostsHunting>();
		pacmanScript = pacmanObject.GetComponent<pacmanMove>();
	}
	

	void Update () {
		if(Input.GetKeyDown(KeyCode.Space) && abilityMasterScript.ReturnAbilityReady() == true){
			decoyObject.SetActive(true);
			StartCoroutine(DecoyAliveTimer());
			abilityMasterScript.StartAbility();
			pointGhostHuntingScript.DecoyPositionMethod();
			decoyObject.transform.position = pacmanObject.gameObject.transform.position;
			GetDirectionForVisual();
			pointGhostHuntingObject.transform.position = decoyObject.transform.position;
			abilityMasterScript.FindObjectVisual(decoyObject.gameObject);
		}
	
	}
	IEnumerator DecoyAliveTimer(){
		yield return new WaitForSeconds(6f);
		abilityMasterScript.StartAbilityCooldown();
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
