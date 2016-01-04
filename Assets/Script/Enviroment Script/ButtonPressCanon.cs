using UnityEngine;
using System.Collections;

public class ButtonPressCanon : MonoBehaviour {

	public GameObject canonDaddyObject;
	CanonDaddy canonDaddyScript;
	bool alreadyPressed = false;

	void Start () {
		canonDaddyScript = canonDaddyObject.GetComponent<CanonDaddy>();
	
	}
	void OnTriggerEnter(Collider trigger){
		if(trigger.gameObject.tag == "Pacman" && alreadyPressed == false){
			alreadyPressed = true;
			transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
			canonDaddyScript.ButtonPressed();
			StartCoroutine(ResetButton());
		}
	}
	IEnumerator ResetButton(){
		yield return new WaitForSeconds(10f);
		transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
		alreadyPressed = false;
	}

}
