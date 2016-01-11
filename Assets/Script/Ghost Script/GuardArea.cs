using UnityEngine;
using System.Collections;

public class GuardArea : MonoBehaviour {

	bool pacmanEnter = false;
	public GameObject[] myGuardingGhosts;

	void Start () {
	
	}
	void OnTriggerEnter(Collider trigger){
		if(trigger.gameObject.tag == "Pacman"){
			pacmanHasEnter();
		}
	}
	void pacmanHasEnter(){
		for(int i = 0; i < myGuardingGhosts.Length; i++){
			myGuardingGhosts[i].gameObject.GetComponent<GhostDady>().PacmanInGuardArea();
		}
	}


	
}
