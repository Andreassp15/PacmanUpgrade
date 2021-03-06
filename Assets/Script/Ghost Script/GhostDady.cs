﻿using UnityEngine;
using System.Collections;
//************************************************************************************************************
//Scriptet activerar vilen visuell verson av spökerna som ska vara framme och ser till att dem beter sig därefter
//**************************************************************************************************************
public class GhostDady : MonoBehaviour {

	public GameObject[] ghostForms;
	//GameObject pacman;
	//Transform pacmanPosition;
	public GameObject nest;
	public GameObject pointObject;
	public GameObject PointGhostsHuntingObject;
	public GameObject patrollObjectOne;
	public GameObject patrollObjectTwo;
	Transform PointGhostsHuntingPosition;

	GameObject[] goldArray;

	public bool followTarget;
	public bool randomDestination;
	public bool followAndRandom;
	public bool guardAreaMode;
	public bool patrollMode;
	public bool tutorialMode;

	bool guardThis = false;

	bool followPac = true;
	bool imHunting = false;
	bool imEscaping = false;
	bool imDead = false;
//	NavMeshAgent theAgent;

	bool firstDestination = true;


	float mySpeed = 3f;


	Vector3 escapeVector;

	void Start () {
		goldArray = GameObject.FindGameObjectsWithTag("Gold");

		PointGhostsHuntingPosition = PointGhostsHuntingObject.GetComponent<Transform>();
		//pacman = GameObject.FindGameObjectWithTag("FindPacmanObject");
		//pacmanPosition = pacman.gameObject.GetComponent<Transform>();

		InvokeRepeating("RandomDestinationCounter", 0, 10);
		InvokeRepeating("SwitchPacOrPoint", 0, 30);
	//	theAgent = GetComponent<NavMeshAgent>();
	}
//-----------------Hunt----------------------
	public void ActivateHunt(){
		if(imDead != true){
			imHunting = true;
			imEscaping = false;
			imDead = false;
			mySpeed = 3f;
			//newRandom = true;
			//findPoint = true;
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
		if(tutorialMode != true){
			transform.position = nest.gameObject.transform.position;
		}

	}
//-------------------Deactivate Forms----------------
	public void DeactivateAll(){
		imHunting = false;
		imEscaping = false;
		imDead = false;
		guardThis = false;
		for(int i = 0; i < ghostForms.Length; i++){
			ghostForms[i].SetActive(false);
		}
	}
//-----------------Movement in Update---------
	void FixedUpdate () {
		if(imHunting == true){
			gameObject.GetComponent<NavMeshAgent>().speed = mySpeed;
			if(followTarget == true){
				FollowTargetMethod();
			}else if(randomDestination == true){
				RandomDestinationMethod();
			}else if(followAndRandom == true){
				FollowAndRandomMethod();
			}else if(guardAreaMode == true){
				if(guardThis == true){
					GuardAreaMethod();
				}else{
					GuardReturnToNest();
				}

			}else if(patrollMode == true){
				PatrollMethod();
			}
		}else if(imEscaping == true){
			if(tutorialMode == true){
				
			}else{
				RandomDestinationMethod();
			}

			//escapeVector = (pacmanPosition.position - transform.position).normalized;
			//theAgent.destination = transform.position - escapeVector * distance;
			//gameObject.GetComponent<NavMeshAgent>().speed = 3.5f;
		}else if(imDead == true){
			gameObject.GetComponent<NavMeshAgent>().radius = 0;
			gameObject.GetComponent<NavMeshAgent>().SetDestination (nest.transform.position);
			gameObject.GetComponent<NavMeshAgent>().speed = 4.5f;
		}else{
			gameObject.GetComponent<NavMeshAgent>().speed = 0;
		}
	}
//--------------------Arrived at Nest------------
	void OnTriggerEnter(Collider trigger){
		if(trigger.gameObject.tag == "Nest" && imDead == true){
			StartCoroutine(huntAgainTimer());
		}else if(trigger.gameObject == pointObject && imHunting == true && (randomDestination == true || followAndRandom == true)){
			RandomDestinationCounter();
		}else if(trigger.gameObject.tag == "patrollObjectOne" && patrollMode == true){
			firstDestination = false;
		}else if(trigger.gameObject.tag == "patrollObjectTwo" && patrollMode == true){
			firstDestination = true;
		}
	}
	IEnumerator huntAgainTimer(){
		yield return new WaitForSeconds(5f);
		gameObject.GetComponent<NavMeshAgent>().radius = 0.1f;  //startRadius!
		imDead = false;
		ActivateHunt();
	}
//------------------------Increase Ghost Speed---------------------
	public void SpeedUp(){
		//used by scripts like AbilityMagnet
		mySpeed = 5f;
	}
	public void SlowDown(){
		mySpeed = 3.5f;
	}
//-------------------Diffrent Hunt Methods---------------------------
	void FollowTargetMethod(){
		gameObject.GetComponent<NavMeshAgent>().SetDestination (PointGhostsHuntingPosition.transform.position);
		gameObject.GetComponent<NavMeshAgent>().speed = mySpeed;
	}
	void RandomDestinationMethod(){
		gameObject.GetComponent<NavMeshAgent>().SetDestination (pointObject.transform.position);	
	}
	void FollowAndRandomMethod(){
		if(followPac == true){
			gameObject.GetComponent<NavMeshAgent>().SetDestination (PointGhostsHuntingPosition.transform.position);
		}else{
			gameObject.GetComponent<NavMeshAgent>().SetDestination (pointObject.transform.position);
		}
	}
	void SwitchPacOrPoint(){
		if(followPac == true){
			followPac = false;
		}else{
			followPac = true;
		}
	}
	void RandomDestinationCounter(){
		int randomCoin = Random.Range(0, goldArray.Length);
		pointObject.transform.position = goldArray[randomCoin].gameObject.transform.position;
	}
	void GuardAreaMethod(){
		gameObject.GetComponent<NavMeshAgent>().SetDestination(PointGhostsHuntingPosition.transform.position);
	}
	void GuardReturnToNest(){
		gameObject.GetComponent<NavMeshAgent>().SetDestination(nest.transform.position);
	}
	void PatrollMethod(){
		if(firstDestination == true){
			gameObject.GetComponent<NavMeshAgent>().SetDestination (patrollObjectOne.transform.position);
		}else if(firstDestination == false){
			gameObject.GetComponent<NavMeshAgent>().SetDestination (patrollObjectTwo.transform.position);
		}
	}
	public void PacmanInGuardArea(){
		guardThis = true;
	}
}
