using UnityEngine;
using System.Collections;
//------------------Programmerare Sp15 Ludvig Emtås-------------------
//****************************************************************************
//Scriptet använder sig av en array med Arrows som blir activa i en bestämd riktning
//****************************************************************************
public class ArrowSpawn : MonoBehaviour {

	public GameObject[] arrowArray;
	public GameObject audioPlayerObject;
	AudioPlayer audioPlayerScript;
	int theArrow = 0;
	public float fireRate;
	public float waitTime;

	void Start () {
		audioPlayerScript = audioPlayerObject.GetComponent<AudioPlayer>();
		InvokeRepeating("FireArrow", waitTime, fireRate);
	
	}

	void FireArrow(){
		audioPlayerScript.FireArrowMethod();
		arrowArray[theArrow].gameObject.transform.position = transform.position;
		arrowArray[theArrow].gameObject.SetActive(true);
		if(theArrow < arrowArray.Length -1){
			theArrow = theArrow +1;
		}else{
			theArrow = 0;
		}


	}
	void Update () {
	
	}
}
