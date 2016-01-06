using UnityEngine;
using System.Collections;
//------------------Programmerare Sp15 Luvdvig Emtås-------------------
//**********************************************************************
//Scriptet sitter på varje Arrow. och skjuter dem frammot i bestämd riktning.
//**********************************************************************

public class ArrowProjectile : MonoBehaviour {

	public GameObject audioPlayerObject;
	AudioPlayer audioPlayerScript;

	Vector3 direction;
	float moveSpeed = 0.1f;
	public float x;
	public float y;
	public float z;

	void Start () {
		audioPlayerScript = audioPlayerObject.GetComponent<AudioPlayer>();
	}
	

	void FixedUpdate () {
		direction = new Vector3(x, y, z); 
		transform.Translate(direction * moveSpeed);
	}
	void OnTriggerEnter(Collider trigger){
		if(trigger.gameObject.tag == "Wall"){
			audioPlayerScript.ArrowHItMethod();
			gameObject.SetActive(false);
		}

	}
}
