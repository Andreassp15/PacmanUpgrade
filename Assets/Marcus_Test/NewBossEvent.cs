using UnityEngine;
using System.Collections.Generic;

//*******//Main Boss Script//*******// kanske

public class NewBossEvent : MonoBehaviour {


	//--------Bomb------//
	public GameObject bomb;// själva bomben.
	BombForceStart ballSpawn; // Scriptet som sätter på bomben.
	public Rigidbody bombStop;
	public float bombGoBoom;
	public GameObject killZoneOne;
	public GameObject killZoneTwo;
	public GameObject killZoneThree;
	public GameObject killZoneFour;
	public GameObject killZoneFive;
	public GameObject killZoneSix;
	public GameObject killZoneSeven;
	public GameObject killZoneEight;




	//------------Bombzones och SpawnsZones---------------//
	public GameObject[] bZones;//Alla zoner som pacman kan gå in i och triggra att bossen ska kasta bomber.
	public Transform ballReturn;// possitionen som bomben spawnar på samt där den återvänder till efteråt.




	public void Start()
	{
		ballSpawn = bomb.GetComponent<BombForceStart> ();
		bomb.SetActive (false);
		killZoneOne.SetActive (false);
		killZoneTwo.SetActive (false);
		killZoneThree.SetActive (false);
		killZoneFour.SetActive (false);
		killZoneFive.SetActive (false);
		killZoneSix.SetActive (false);
		killZoneSeven.SetActive (false);
		killZoneEight.SetActive (false);
	}

	public void ZoneActivated(GameObject theObject)
	{
		GameObject existBomb = GameObject.FindWithTag ("Bomb");


		for(int i = 1; i <= bZones.Length;i++)
		{
			if (existBomb == null && bZones[0] == theObject) 
			{
				transform.localEulerAngles = new Vector3 (0f, 135f, 0f);
				Invoke ("BombActivate", 0.25f);
				Invoke ("BombReturn", bombGoBoom);
				Invoke ("ExplosionOne", 5f);
			}
			else if(existBomb == null && bZones[1] == theObject)
			{
				transform.localEulerAngles = new Vector3 (0f, 180f, 0f);
				Invoke ("BombActivate", 0.25f);
				Invoke ("BombReturn", bombGoBoom);
				Invoke ("ExplosionTwo", 5f);
			}
			else if(existBomb == null && bZones[2] == theObject)
			{
				transform.localEulerAngles = new Vector3 (0f, -135f, 0f);
				Invoke ("BombActivate", 0.25f);
				Invoke ("BombReturn", bombGoBoom);
				Invoke ("ExplosionThree", 5f);
			}
			else if(existBomb == null && bZones[3] == theObject)
			{
				transform.localEulerAngles = new Vector3 (0f, -90f, 0f);
				Invoke ("BombActivate", 0.25f);
				Invoke ("BombReturn", bombGoBoom);
				Invoke ("ExplosionFour", 5f);
			}
			else if(existBomb == null && bZones[4] == theObject)
			{
				transform.localEulerAngles = new Vector3 (0f, -45f, 0f);
				Invoke ("BombActivate", 0.25f);
				Invoke ("BombReturn", bombGoBoom);
				Invoke ("ExplosionFive", 5f);
			}
			else if(existBomb == null && bZones[5] == theObject)
			{
				transform.localEulerAngles = new Vector3 (0f, 0f, 0f);
				Invoke ("BombActivate", 0.25f);
				Invoke ("BombReturn", bombGoBoom);
				Invoke ("ExplosionSix", 5f);
			}
			else if(existBomb == null && bZones[6] == theObject)
			{
				transform.localEulerAngles = new Vector3 (0f, 45f, 0f);
				Invoke ("BombActivate", 0.25f);
				Invoke ("BombReturn", bombGoBoom);
				Invoke ("ExplosionSeven", 5f);
			}
			else if(existBomb == null && bZones[7] == theObject)
			{
				transform.localEulerAngles = new Vector3 (0f, 90f, 0f);
				Invoke ("BombActivate", 0.25f);
				Invoke ("BombReturn", bombGoBoom);
				Invoke ("ExplosionEight", 5f);
			}
	
		}
	}

	public void BombActivate()
	{
		bomb.transform.position = ballReturn.transform.position;
		bomb.transform.rotation = ballReturn.transform.rotation;
		ballSpawn.PowerOn ();
		bomb.SetActive (true);
	}


	public void BombReturn ()
	{
		bomb.transform.position = ballReturn.transform.position;
		bomb.SetActive (false);
		bombStop.GetComponent<Rigidbody> ();
		bombStop.velocity = bombStop.velocity = new Vector3 (0f, 0f, 0f);
		Debug.Log ("Stop");
	}
		
	public void ExplosionOne()
	{
		killZoneOne.SetActive (true);
		Invoke ("ExplosionOff", 5f);
	}

	public void ExplosionTwo()
	{
		killZoneTwo.SetActive (true);
		Invoke ("ExplosionOff", 5f);
	}

	public void ExplosionThree()
	{
		killZoneThree.SetActive (true);
		Invoke ("ExplosionOff", 5f);
	}

	public void ExplosionFour()
	{
		killZoneFour.SetActive (true);
		Invoke ("ExplosionOff", 5f);
	}

	public void ExplosionFive()
	{
		killZoneFive.SetActive (true);
		Invoke ("ExplosionOff", 5f);
	}

	public void ExplosionSix()
	{
		killZoneSix.SetActive (true);
		Invoke ("ExplosionOff", 5f);
	}

	public void ExplosionSeven()
	{
		killZoneSeven.SetActive (true);
		Invoke ("ExplosionOff", 5f);
	}

	public void ExplosionEight()
	{
		killZoneEight.SetActive (true);
		Invoke ("ExplosionOff", 5f);
	}

	public void ExplosionOff()
	{
		killZoneOne.SetActive (false);
		killZoneTwo.SetActive (false);
		killZoneThree.SetActive (false);
		killZoneFour.SetActive (false);
		killZoneFive.SetActive (false);
		killZoneSix.SetActive (false);
		killZoneSeven.SetActive (false);
		killZoneEight.SetActive (false);
	}

}