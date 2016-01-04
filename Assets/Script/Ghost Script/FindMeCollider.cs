using UnityEngine;
using System.Collections;

public class FindMeCollider : MonoBehaviour {

	bool inWall = false;
	void Start () {

	}
	void OnTriggerEnter(Collider trigger){
		if(trigger.gameObject.tag == "Wall"){
			inWall = true;
	
		}
	}
	public void ResetInWall(){
		inWall = false;
	}
	public bool ReturnInWall(){
		return inWall;
	}


}