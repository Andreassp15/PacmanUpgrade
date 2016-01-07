using UnityEngine;
using System.Collections;

public class GuardArea : MonoBehaviour {

	bool pacmanEnter = false;

	void Start () {
	
	}
	void OnTriggerEnter(Collider trigger){
		if(trigger.gameObject.tag == "Pacman"){
			pacmanEnter = true;
		}
	}
	public bool ReturnPacmanEnter(){
		return pacmanEnter;
	}

	
}
