using UnityEngine;
using System.Collections;
//************************************************************************************************************
//Scriptet activerar vilen visuell verson av spökerna som ska vara framme och ser till att dem beter sig därefter
//**************************************************************************************************************
public class GhostDady : MonoBehaviour {

	public GameObject[] ghostForms;
	public GameObject pacman;
	public Transform pacmanPosition;
	public GameObject nest;
	public GameObject pointObject;

	public bool followTarget;
	public bool randomDestination;
	public bool followAndRandom;
	//public bool patrol;
	bool newRandom;
	bool findPoint;
	
	bool imHunting = false;
	bool imEscaping = false;
	bool imDead = false;
	NavMeshAgent theAgent;

	float distance = 20f;
	float mySpeed = 3f;

	Vector3 escapeVector;

	void Start () {
		theAgent = GetComponent<NavMeshAgent>();
	}
//-----------------Hunt----------------------
	public void ActivateHunt(){
		if(imDead != true){
			imHunting = true;
			imEscaping = false;
			imDead = false;
			mySpeed = 3f;
			newRandom = true;
			findPoint = true;
			ghostForms[0].SetActive(true);
			ghostForms[1].SetActive(false);
			ghostForms[2].SetActive(false);
		}
	}
//--------------------Escape------------------
	public void ActivateEscape(){
		if(imDead != true){
			imHunting = false;
			imEscaping = true;
			imDead = false;
			ghostForms[0].SetActive(false);
			ghostForms[1].SetActive(true);
			ghostForms[2].SetActive(false);
		}
	}
//--------------------Dead---------------------
	public void ActivateDead(){
		imHunting = false;
		imEscaping = false;
		imDead = true;
		ghostForms[0].SetActive(false);
		ghostForms[1].SetActive(false);
		ghostForms[2].SetActive(true);

	}
//---------------------teleport to nest---------------
	public void TeleportToNest(){
		transform.position = nest.gameObject.transform.position;
	}
//-------------------Deactivate Forms----------------
	public void DeactivateAll(){
		imHunting = false;
		imEscaping = false;
		imDead = false;
		for(int i = 0; i < ghostForms.Length; i++){
			ghostForms[i].SetActive(false);
		}
		//Debug.Log("hunt " + imHunting + " escape " + imEscaping + "dead " + imDead);
	}
//-----------------Movement in uppdate---------
	void Update () {
		if(imHunting == true){
			//gameObject.GetComponent<NavMeshAgent>().SetDestination (pacman.transform.position);
			gameObject.GetComponent<NavMeshAgent>().speed = mySpeed;
			//Debug.Log("hunt.." + imHunting);
			//placera in script här !!!
			if(followTarget == true){
				FollowTargetMethod();
			}else if(randomDestination == true){
				RandomDestinationMethod();
			}else if(followAndRandom == true){
				FollowAndRandomMethod();
			}
		}else if(imEscaping == true){
			escapeVector = (pacmanPosition.position - transform.position).normalized;
			theAgent.destination = transform.position - escapeVector * distance;
			gameObject.GetComponent<NavMeshAgent>().speed = 2.5f;
			//Debug.Log("esca.." + imEscaping);
		}else if(imDead == true){
			gameObject.GetComponent<NavMeshAgent>().radius = 0;
			gameObject.GetComponent<NavMeshAgent>().SetDestination (nest.transform.position);
			gameObject.GetComponent<NavMeshAgent>().speed = 4.5f;
			//Debug.Log("dead.." + imDead);
		}else{
			gameObject.GetComponent<NavMeshAgent>().speed = 0;
			//Debug.Log ("speed 0");
			//gameObject.GetComponent<NavMeshAgent>().SetDestination (nest.transform.position);
		}
	}
//--------------------Arrived at Nest------------
	void OnTriggerEnter(Collider trigger){
		if(trigger.gameObject.tag == "Nest" && imDead == true){
			StartCoroutine(huntAgainTimer());
			//Debug.Log("Dead at nest");
		}

	}
	IEnumerator huntAgainTimer(){
		yield return new WaitForSeconds(5f);
		gameObject.GetComponent<NavMeshAgent>().radius = 0.3f;  //startRadius!
		imDead = false;
		ActivateHunt();
	}
//------------------------Increase Ghost Speed---------------------
	public void SpeedUp(){
		//used by scripts like AbilityMagnet
		mySpeed = 5f;
	}
//-------------------Diffrent Hunt Methods---------------------------
	void FollowTargetMethod(){
		gameObject.GetComponent<NavMeshAgent>().SetDestination (pacman.transform.position);
		gameObject.GetComponent<NavMeshAgent>().speed = mySpeed;
	}
	void RandomDestinationMethod(){
		Debug.Log("in destMethod");
		gameObject.GetComponent<NavMeshAgent>().SetDestination (pointObject.transform.position);
		if(newRandom == true){
			newRandom = false;
			float x = Random.Range(-12, 12);
			float z = Random.Range(-12, 12);
			Vector3 point = new Vector3( x, 0, z);
			pointObject.transform.position = point;
			StartCoroutine(NewRandom());
		}		
	}
	IEnumerator NewRandom(){
		yield return new WaitForSeconds(3);
		newRandom = true;
	}
	void FollowAndRandomMethod(){
		if(newRandom == true){
			newRandom = false;
			float x = Random.Range(-12, 12);
			float z = Random.Range(-12, 12);
			Vector3 point = new Vector3( x, 0, z);
			pointObject.transform.position = point;
			StartCoroutine(RandomAgain());
		}
		if(findPoint == true){
			gameObject.GetComponent<NavMeshAgent>().SetDestination (pointObject.transform.position);
		}else{
			gameObject.GetComponent<NavMeshAgent>().SetDestination (pacman.transform.position);
		}	
		if(transform.position == pointObject.transform.position && findPoint == true){
			findPoint = false;

		}
	}
	IEnumerator RandomAgain(){
		yield return new WaitForSeconds(10f);
		newRandom = true;
		findPoint = true;
	}

}
