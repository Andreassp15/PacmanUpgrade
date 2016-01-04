using UnityEngine;
using System.Collections;

public class PointGhostsHunting : MonoBehaviour {

	GameObject pacmanObject;
	Transform pacmanTransform;
	bool pacmanPosition = true;

	//GameObject DecoyObject;

	void Start () {
		pacmanObject = GameObject.FindGameObjectWithTag("FindPacmanObject");
		pacmanTransform = pacmanObject.GetComponent<Transform>();
	}
	void FixedUpdate () {
		if(pacmanPosition == true){
			transform.position = pacmanTransform.transform.position;
		}
	}
	/*void OnTriggerEnter(Collider trigger){
		if(trigger.gameObject.tag == "GhostHunt" && pacmanPosition == false){
			PacmanPositionMethod();
			//DecoyObject = GameObject.FindGameObjectWithTag("Decoy");
			DecoyObject.SetActive(false);
		}
	}
	public void GhostFoundMe(){
		DecoyObject = GameObject.FindGameObjectWithTag("Decoy");
	}*/
	public void DecoyPositionMethod(){
		pacmanPosition = false;
	}
	public void PacmanPositionMethod(){
		pacmanPosition = true;
	}
}
