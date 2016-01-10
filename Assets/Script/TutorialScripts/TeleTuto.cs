using UnityEngine;
using System.Collections;

public class TeleTuto : MonoBehaviour {

	public GameObject exitKai;
	public GameObject exitJon;
	public GameObject exitNicklas;
	public GameObject coinsTutoObject;
	CoinsTuto coinsTutoScript;

	void Start () {
		coinsTutoScript = coinsTutoObject.GetComponent<CoinsTuto>();
	
	}
	void OnTriggerEnter(Collider trigger){
		if(trigger.gameObject.tag == "Pacman"){
			Debug.Log("1");
			coinsTutoScript.WhatPacman(trigger.gameObject);

			if(trigger.gameObject.transform.parent.gameObject.name == "PacmanKai"){
				trigger.gameObject.transform.parent.gameObject.transform.position = exitKai.gameObject.transform.position;
			}else if(trigger.gameObject.transform.parent.gameObject.name == "PacmanJon"){
				trigger.gameObject.transform.parent.gameObject.transform.position = exitJon.gameObject.transform.position;
			}else if(trigger.gameObject.transform.parent.gameObject.name == "PacmanNicklas"){
				trigger.gameObject.transform.parent.gameObject.transform.position = exitNicklas.gameObject.transform.position;
			}
		}



	}

}
