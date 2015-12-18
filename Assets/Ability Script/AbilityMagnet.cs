using UnityEngine;
using System.Collections;

public class AbilityMagnet : MonoBehaviour {

	public GameObject pacmanObject;
	public GameObject printerObject;
	Printer printerScript;
	int coolDown = 10;
	bool abilityReady = true;

	void Start () {

		printerScript = printerObject.GetComponent<Printer>();
	
	}
	

	void FixedUpdate () {
		transform.position = new Vector3(pacmanObject.transform.position.x, pacmanObject.transform.position.y, pacmanObject.transform.position.z);
	
	}
	void Update(){
		if(Input.GetKeyDown(KeyCode.E) && abilityReady == true){
			StartCoroutine(MagnetTimer());
			abilityReady = false;

		}
	}
	IEnumerator MagnetTimer(){
		gameObject.GetComponent<Transform>().localScale = new Vector3(7, 7, 7);
		yield return new WaitForSeconds(3f);
		gameObject.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
		InvokeRepeating("coolDownTimer", 0, 1);
	}
	void OnTriggerEnter(Collider trigger){
		if(trigger.gameObject.tag == "Gold" || trigger.gameObject.tag == "Diamond"){
			trigger.gameObject.transform.position = transform.position;
		}else if(trigger.gameObject.tag == "GhostHunt"){
			Debug.Log("hit Ghost");
			trigger.gameObject.transform.parent.gameObject.GetComponent<GhostDady>().SpeedUp();
			printerScript.PrintInfoText("Your Magnet Hit Ghost. They are now Faster!");
		}
	}
	void coolDownTimer(){
		if(coolDown < 1){
			CancelInvoke("coolDownTimer");
			coolDown = 10;
			abilityReady = true;
		}else{
			coolDown = coolDown -1;
			printerScript.AbilityCoolDownText(coolDown);
		}
	}
}
