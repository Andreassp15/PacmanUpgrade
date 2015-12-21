using UnityEngine;
using System.Collections;

public class AbilityMagnet : MonoBehaviour {

	public GameObject pacmanObject;
	public GameObject printerObject;
	Printer printerScript;
	float duration = 100f;
	int coolDown = 10;
	bool abilityReady = true;
	//bool enlarge = false;
	//Transform myTransform;

	void Start () {

		printerScript = printerObject.GetComponent<Printer>();
		//myTransform = new Transform (gameObject.GetComponent<Transform>());
	}
	

	void FixedUpdate () {/*
		if(enlarge == true){
			gameObject.transform.localScale = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(7, 7, 7), 100f / duration);
		}*/
		transform.position = new Vector3(pacmanObject.transform.position.x, pacmanObject.transform.position.y, pacmanObject.transform.position.z);				
	}
	void Update(){
		if(Input.GetKeyDown(KeyCode.E) && abilityReady == true){
			StartCoroutine(MagnetTimer());
			abilityReady = false;

		}
	}
	IEnumerator MagnetTimer(){
		//enlarge = true;
	/*	do{
			gameObject.transform.localScale = Vector3.Lerp(new Vector3(0, 0,0), new Vector3(7, 7, 7), Time.deltaTime * duration);
			yield return null;
			tag += Time.deltaTime;
		}while(Time.deltaTime < duration);
			gameObject.transform.localScale =
			yield break;*/
		

		gameObject.GetComponent<Transform>().localScale = new Vector3(8, 8, 8);
		//gameObject.GetComponent<Transform>().localScale = gameObject.GetComponent<Transform>().localScale.Lerp(new Vector3(0, 0,0), new Vector3(7, 7, 7), Time.deltaTime * duration);
		yield return new WaitForSeconds(3f);
		//enlarge = false;
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
