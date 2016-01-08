using UnityEngine;
using System.Collections;

public class InfoBox : MonoBehaviour {

	public GameObject tutorialObject;
	Tutorial tutorialScript;

	void Start () {
		tutorialScript = tutorialObject.GetComponent<Tutorial>();
	}
	void OnTriggerEnter(Collider Trigger){
		if(Trigger.gameObject.tag == "Pacman"){
			tutorialScript.PrintInfo(gameObject);
		}
	}
}
