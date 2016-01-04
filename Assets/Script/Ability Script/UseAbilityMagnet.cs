using UnityEngine;
using System.Collections;

public class UseAbilityMagnet : MonoBehaviour {

	public GameObject abilityMasterObject;
	public GameObject magnetObject;
	public GameObject pacmanObject;
	public GameObject poweredVisualOther;

	bool enlarge;
	float enlargeSpeed = 4f;

	AbilityMaster abilityMasterScript;

	void Start () {
		poweredVisualOther.GetComponent<ParticleSystem>().startLifetime = 4;
		abilityMasterScript = abilityMasterObject.GetComponent<AbilityMaster>();
	}
	void FixedUpdate(){
		magnetObject.transform.position = pacmanObject.transform.position;
	}
	

	void Update () {
		if(Input.GetKeyDown(KeyCode.Space) && abilityMasterScript.ReturnAbilityReady() == true){
			magnetObject.SetActive(true);
			abilityMasterScript.FindObjectVisual(magnetObject.gameObject);
			abilityMasterScript.StartAbility();
			enlarge = true;
			StartCoroutine(MagnetTimer());
		}
		if(enlarge == true){
			magnetObject.GetComponent<Transform>().localScale = Vector3.Lerp(magnetObject.transform.localScale, new Vector3(8, 8, 8), enlargeSpeed  * Time.deltaTime);
		}else if(enlarge == false){
			magnetObject.GetComponent<Transform>().localScale = Vector3.Lerp(magnetObject.transform.localScale, new Vector3(0, 0, 0), enlargeSpeed  * Time.deltaTime);
		}

	
	}
	IEnumerator MagnetTimer(){
		yield return new WaitForSeconds(4);
		enlarge = false;
		yield return new WaitForSeconds(1);
		abilityMasterScript.PoweredAbilityEnd();
		abilityMasterScript.StartAbilityCooldown();
		magnetObject.SetActive(false);

	}
}
