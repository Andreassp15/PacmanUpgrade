﻿using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {

	Vector3 direction;
	float moveSpeed;
	float meteorSpeed = 0.05f;
	float stopSpeed = 0f;
	public GameObject explode;

	void Start () {
		moveSpeed = meteorSpeed;
	}
	

	void Update () {
		direction = new Vector3(0, 0, -1); 
		transform.Translate(direction * moveSpeed);
	}
	void OnTriggerEnter(Collider trigger){
		gameObject.GetComponent<SphereCollider>().radius = 2;
		gameObject.GetComponent<Renderer>().enabled = false;
		moveSpeed = stopSpeed;
		explode.gameObject.SetActive(true);
		StartCoroutine(ExplosiveTime());
		//gameObject.SetActive(false);
	}
	IEnumerator ExplosiveTime(){
		yield return new WaitForSeconds(2f);
		explode.gameObject.SetActive(false);
		gameObject.SetActive(false);
	}
	public void ActivateSpeed(){
		moveSpeed = meteorSpeed;
	}
}
