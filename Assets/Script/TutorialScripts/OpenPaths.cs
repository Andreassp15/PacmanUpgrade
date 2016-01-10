using UnityEngine;
using System.Collections;

public class OpenPaths : MonoBehaviour {


	public GameObject tutorialObject;
	Tutorial tutorialScript;

	void Start () {
		tutorialScript = tutorialObject.GetComponent<Tutorial>();
	}
	void OnTriggerEnter(Collider trigger){
		if(trigger.gameObject.tag == "Pacman"){
			tutorialScript.StartTimerForPath();
		}
	}

	void Update () {

	}
}