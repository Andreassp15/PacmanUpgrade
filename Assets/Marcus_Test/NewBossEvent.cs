using UnityEngine;
using System.Collections.Generic;

//*******//Main Boss Script//*******// kanske

public class NewBossEvent : MonoBehaviour {


	//--------Bomb and Force---------//
	public Rigidbody bombPrefab;
	public float power;
	public float delay = 1.2f;



	//------------Bombzones och SpawnsZones---------------//
	public GameObject[] bZones;//Alla zoner som pacman kan gå in i och triggra att bossen ska kasta bomber.
	public Transform[] sZones;//Alla zoner som bomberna kommer att spawna från.



	//--------Zonerna är av i start--------------//
	public bool zone = false;


	public void FixedUpdate()
	{
		GameObject existBomb = GameObject.FindWithTag ("Bomb");

		if (existBomb == null && zone == true) 
		{
			Rigidbody bomb;
			bomb = Instantiate (bombPrefab, sZones [0].position, sZones [0].rotation) as Rigidbody;
			bomb.AddForce (250f, 250f, 1f * power);
			zone = false;
			Invoke ("destroyBomb", delay);
			Debug.Log("Funkar");
		}
			



	}

	//----------Sätter zonerna som activa och tillåter bossen att skjuta bomber----------//
	public void ZoneActivated()
	{
		 zone = true;

		Debug.Log ("hej");
	}

	public void destroyBomb()
	{
		Destroy(GameObject.FindWithTag("Bomb"));

	}
}